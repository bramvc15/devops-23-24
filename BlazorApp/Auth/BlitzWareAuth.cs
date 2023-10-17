﻿using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Text.Json;
using Newtonsoft.Json;
using static BlazorApp.Auth.BlitzWareAuth.API;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Auth;

public class BlitzWareAuth
{
    private class Security
    {
        internal static string CalculateResponseHash(string data)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sha256Hash.ComputeHash(bytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
        internal static string CalculateFileHash(string filename)
        {
            SHA256 sha256 = SHA256.Create();
            FileStream fileStream = File.OpenRead(filename);
            byte[] hashBytes = sha256.ComputeHash(fileStream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
    private class Utilities
    {
        internal static string HWID()
        {
            string hwid = string.Empty;

            try
            {
                ProcessStartInfo processStartInfo = new()
                {
                    FileName = "wmic",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = "diskdrive get serialnumber"
                };

                Process process = new() { StartInfo = processStartInfo };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length > 1)
                    {
                        hwid = lines[1].Trim().TrimEnd('.');
                    }
                }
            }
            catch (Exception ex)
            {
                hwid = "Error hwid: " + ex.Message;
            }

            return hwid;
        }
        internal static string IP()
        {
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            return externalIpString;
        }
    }
    public class API
    {
        public readonly string ApiUrl;
        public readonly string AppName;
        public readonly string AppSecret;
        public readonly string AppVersion;
        public bool Initialized;

        public class ErrorData
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }

        public ApplicationData appData = new();
        public class ApplicationData
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Status { get; set; }
            public int HwidCheck { get; set; }
            public int DeveloperMode { get; set; }
            public int IntegrityCheck { get; set; }
            public int FreeMode { get; set; }
            public int TwoFactorAuth { get; set; }
            public string ProgramHash { get; set; }
            public string Version { get; set; }
            public string DownloadLink { get; set; }
        }

        public UserData userData = new();
        public class UserData
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string ExpiryDate { get; set; }
            public string LastLogin { get; set; }
            public string LastIP { get; set; }
            public string HWID { get; set; }
            public string Token { get; set; }
        }

        public class RequestResult
        {
            public string message { get; set; }
            public bool success { get; set; }
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "Username is required.")]
            [MinLength(length: 2, ErrorMessage = "Username must be at least 2 characters long.")]
            [MaxLength(length: 50, ErrorMessage = "Username must be at max 50 characters long.")]
            public string username { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [MinLength(length: 6, ErrorMessage = "Password must be at least 6 characters long.")]
            [MaxLength(length: 50, ErrorMessage = "Password must be at max 50 characters long.")]
            [DataType(DataType.Password)]
            public string password { get; set; }
        }
        public class RegisterModel : LoginModel
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Email address is not valid.")]
            public string email { get; set; }

            [Required(ErrorMessage = "Confirm password is required.")]
            [DataType(DataType.Password)]
            [Compare("password", ErrorMessage = "Password and confirm password do not match.")]
            public string confirmPassword { get; set; }
        }

        public API(string apiUrl, string appName, string appSecret, string appVersion)
        {
            ApiUrl = apiUrl;
            AppName = appName;
            AppSecret = appSecret;
            AppVersion = appVersion;
            Initialized = false;
        }
        public void Initialize()
        {
            if (Initialized)
            {
                Console.WriteLine("Application is already initialized!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/applications/initialize";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var requestData = new
                {
                    name = AppName,
                    secret = AppSecret,
                    version = AppVersion
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
                        Console.WriteLine("Possible malicious activity detected!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    appData = JsonConvert.DeserializeObject<ApplicationData>(responseContent);
                    Initialized = true;

                    if (appData.Status == 0)
                    {
                        Console.WriteLine("Looks like this application is offline, please try again later!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    if (appData.FreeMode == 1)
                        Console.WriteLine("Application is in Free Mode!");

                    if (appData.DeveloperMode == 1)
                    {
                        Console.WriteLine("Application is in Developer Mode, bypassing integrity and update check!");
                        File.Create(Environment.CurrentDirectory + "/integrity.txt").Close();
                        string hash = Security.CalculateFileHash(Process.GetCurrentProcess().MainModule.FileName);
                        File.WriteAllText(Environment.CurrentDirectory + "/integrity.txt", hash);
                        Console.WriteLine("Your application's hash has been saved to integrity.txt, please refer to this when your application is ready for release!");
                    }
                    else
                    {
                        if (appData.Version != AppVersion)
                        {
                            Console.WriteLine($"Update {appData.Version} available, redirecting to update!");
                            Thread.Sleep(3000);
                            Process.Start(appData.DownloadLink);
                            Environment.Exit(0);
                        }
                        if (appData.IntegrityCheck == 1)
                        {
                            if (appData.ProgramHash != Security.CalculateFileHash(Process.GetCurrentProcess().MainModule.FileName))
                            {
                                Console.WriteLine("File has been tampered with, couldn't verify integrity!");
                                Thread.Sleep(3000);
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    Console.WriteLine($"{errorData.Code}: {errorData.Message}");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        public RequestResult Register(string username, string password, string email, string license)
        {
            if (!Initialized)
            {
                return new RequestResult { message = "Application has not been initialized.", success = false };
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/users/register";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var requestData = new
                {
                    username,
                    password,
                    email,
                    license,
                    hwid = Utilities.HWID(),
                    lastIP = Utilities.IP(),
                    id = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
                        Console.WriteLine("Possible malicious activity detected!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    this.userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return new RequestResult { message = "Registration successful.", success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { message = $"{errorData.Code}: {errorData.Message}", success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { message = $"An error occurred: {ex.Message}", success = false };
            }
        }

        public RequestResult Login(string username, string password, string twoFactorCode)
        {
            if (!Initialized)
            {
                return new RequestResult { message = "Application has not been initialized.", success = false };
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/users/login";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var requestData = new
                {
                    username,
                    password,
                    twoFactorCode,
                    hwid = Utilities.HWID(),
                    lastIP = Utilities.IP(),
                    appId = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
                        Console.WriteLine("Possible malicious activity detected!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    this.userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return new RequestResult { message = "Login succesful.", success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { message = $"{errorData.Code}: {errorData.Message}", success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { message = $"An error occurred: {ex.Message}", success = false };
            }
        }
        public bool LoginLicenseOnly(string license)
        {
            if (!Initialized)
            {
                Console.WriteLine("Please initialize your application first!");
                Thread.Sleep(3000);
                return false;
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/licenses/login";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var requestData = new
                {
                    license,
                    hwid = Utilities.HWID(),
                    lastIP = Utilities.IP(),
                    appId = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
                        Console.WriteLine("Possible malicious activity detected!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return true;
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    Console.WriteLine($"{errorData.Code}: {errorData.Message}");
                    Thread.Sleep(3000);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Thread.Sleep(3000);
                return false;
            }
        }

        public bool Extend(string username, string password, string license)
        {
            if (!Initialized)
            {
                Console.WriteLine("Please initialize your application first!");
                Thread.Sleep(3000);
                return false;
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/users/upgrade";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                var requestData = new
                {
                    username,
                    password,
                    license,
                    hwid = Utilities.HWID(),
                    appId = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
                        Console.WriteLine("Possible malicious activity detected!");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return true;
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    Console.WriteLine($"{errorData.Code}: {errorData.Message}");
                    Thread.Sleep(3000);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Thread.Sleep(3000);
                return false;
            }
        }
        public void Log(string username, string action)
        {
            if (!Initialized)
            {
                Console.WriteLine("Please initialize your application first!");
                return;
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + "/appLogs/";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.Token);

                var requestData = new
                {
                    username,
                    action,
                    ip = Utilities.IP(),
                    appId = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    Console.WriteLine($"{errorData.Code}: {errorData.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DownloadFile(string fileId)
        {
            if (!Initialized)
            {
                Console.WriteLine("Please initialize your application first!");
                return;
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + $"/files/download/{fileId}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.Token);
                HttpResponseMessage response = client.GetAsync(url).Result;
                string outputPath = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    // Extract the file name and extension from the response headers
                    if (response.Content.Headers.TryGetValues("Content-Disposition", out var contentDispositionValues))
                    {
                        string contentDisposition = contentDispositionValues.FirstOrDefault();
                        if (!string.IsNullOrEmpty(contentDisposition))
                        {
                            string[] parts = contentDisposition.Split('=');
                            if (parts.Length == 2)
                            {
                                string fileName = parts[1].Trim('"');
                                outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                            }
                        }
                    }
                    // Save the file if outputPath is not empty
                    if (!string.IsNullOrEmpty(outputPath))
                    {
                        Stream contentStream = response.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = File.Create(outputPath);
                        contentStream.CopyToAsync(fileStream);
                    }
                    else
                    {
                        Console.WriteLine("Unable to determine the file name.");
                    }
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    Console.WriteLine($"{errorData.Code}: {errorData.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
