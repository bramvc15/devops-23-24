using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

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

        public class Employee
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("expiryDate")]
            public DateTime ExpiryDate { get; set; }

            [JsonProperty("lastLogin")]
            public DateTime LastLogin { get; set; }

            [JsonProperty("lastIP")]
            public string LastIP { get; set; }

            [JsonProperty("hwid")]
            public string Hwid { get; set; }

            [JsonProperty("enabled")]
            public int Enabled { get; set; }

            [JsonProperty("twoFactorAuth")]
            public int TwoFactorAuth { get; set; }

            [JsonProperty("userSubId")]
            public int? UserSubId { get; set; }

            [JsonProperty("userSubLevel")]
            public int? UserSubLevel { get; set; }
        }

        public class RequestResult
        {
            public string Message { get; set; }
            public bool Success { get; set; }
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
                return new RequestResult { Message = "Application has not been initialized.", Success = false };
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
                    hwid = "N/A",
                    lastIP = "N/A",
                    id = "N/A"
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseHash = response.Headers.GetValues("X-Response-Hash").FirstOrDefault();
                    string recalculatedHash = Security.CalculateResponseHash(response.Content.ReadAsStringAsync().Result);
                    if (responseHash != recalculatedHash)
                    {
						return new RequestResult { Message = "Possible malicious activity detected.", Success = false };
					}

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    this.userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return new RequestResult { Message = "Registration successful.", Success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { Message = $"{errorData.Code}: {errorData.Message}", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { Message = $"An error occurred: {ex.Message}", Success = false };
            }
        }

        public RequestResult Login(string username, string password, string twoFactorCode)
        {
            if (!Initialized)
            {
                return new RequestResult { Message = "Application has not been initialized.", Success = false };
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
                    hwid = "N/A",
                    lastIP = "N/A",
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
						return new RequestResult { Message = "Possible malicious activity detected.", Success = false };
					}

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    this.userData = JsonConvert.DeserializeObject<UserData>(responseContent);
                    return new RequestResult { Message = "Login succesful.", Success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { Message = $"{errorData.Code}: {errorData.Message}", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { Message = $"An error occurred: {ex.Message}", Success = false };
            }
        }

        public RequestResult Log(string username, string action)
        {
            if (!Initialized)
            {
                return new RequestResult { Message = "Application has not been initialized.", Success = false };
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
                    ip = "N/A",
                    appId = appData.Id
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return new RequestResult { Message = "Log sent succesful.", Success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { Message = $"{errorData.Code}: {errorData.Message}", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { Message = $"An error occurred: {ex.Message}", Success = false };
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

        public RequestResult getAllUsers()
        {
            if (!Initialized)
            {
                return new RequestResult { Message = "Application has not been initialized.", Success = false };
            }
            try
            {
                HttpClient client = new();
                string url = ApiUrl + $"/users/fromApp/{appData.Id}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.Token);
                HttpResponseMessage response = client.GetAsync(url).Result;
                string outputPath = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(responseContent);
                    return new RequestResult { Message = responseContent, Success = true };
                }
                else
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    var errorData = JsonConvert.DeserializeObject<ErrorData>(errorContent);
                    return new RequestResult { Message = $"{errorData.Code}: {errorData.Message}", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new RequestResult { Message = $"An error occurred: {ex.Message}", Success = false };
            }
        }
    }
}
