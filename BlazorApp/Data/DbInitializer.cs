using BlazorApp.Models;
using BlazorApp.Pages;

namespace BlazorApp.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {

            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.ChatBotQuestions.Any())
            {
                return;
            }

            var doctors = new Doctor[]
            {
                new Doctor
                {
                    Name = "Guillaume",
                    Gender = "Male",
                    Specialization = "not a doctor",
                    InfoText = " hello world "
                },

                new Doctor
                {
                    Name = "Doctor Name",
                    Gender = "Male",
                    Specialization = "Specialty",
                    InfoText = "Additional Information"
                }

            };


            var header = new HomeHeader
            {

                Title = "Vision Oogcentrum Gent",
                Context = "Welkom bij Vision Oogcenter Gent - uw venster naar helder zicht en een wereld van visuele perfectie."

            };

            var blogs = new Blog[]
            {
                new Blog
                {
                    Title = "Guillaume",
                    Text = "Male",
                    Image = "not a doctor"
        
                },

               new Blog
                {
                    Title = "Guillaume",
                    Text = "Male",
                    Image = "not a doctor"
        
                }

            };

            var chatbotQuestions = new ChatBotQuestion[] 
            {
                new ChatBotQuestion
                {
                    Question = "Hoe plan ik een afspraak?",
                    Answer = "In de rechterbovenhoek van de website kan je op de knop 'Maak een afspraak' klikken. Daarna kan je een datum en tijdslot kiezen voor je afspraak.",
                },
                new ChatBotQuestion
                {
                    Question = "Hoe kan ik mijn afspraak annuleren?",
                    Answer = "In de bevestigingsmail van je afspraak kan je op de knop 'Afspraak annuleren' klikken. Daarna kan je je afspraak annuleren.",
                }
            };


            context.Doctors.AddRange(doctors);
            context.HomeHeaders.Add(header);
            context.Blogs.AddRange(blogs);
            context.ChatBotQuestions.AddRange(chatbotQuestions);
            context.SaveChanges();

        }



    }

}