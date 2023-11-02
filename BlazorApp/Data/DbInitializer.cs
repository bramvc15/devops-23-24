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
                    Question = "Alles goed vandaag?",
                    Answer = "Zeker met u?",
                    FollowUpQuestion = 1,
                },
                    new ChatBotQuestion
                    {
                        FollowUpID = 1,
                        Question = "Zeer goed",
                        Answer = "Top!",
                    },
                    new ChatBotQuestion
                    {
                        FollowUpID = 1,
                        Question = "Nee",
                        Answer = "Oei!",
                    },


                new ChatBotQuestion
                {
                    Question = "Hoe maak ik een afspraak?",
                    Answer = "U kan een afspraak door rechtsboven op de knop 'Maak een afspraak' te klikken.",
                },

                
                new ChatBotQuestion
                {
                    Question = "Hoeveel kost een behandeling?",
                    Answer = "In welke behandeling bent u geïnteresseerd?",
                    FollowUpQuestion = 2,
                },
                    new ChatBotQuestion
                    {
                        FollowUpID = 2,
                        Question = "Ooglidcorrectie",
                        Answer = "Over welk soort ooglidcorrectie gaat het?",
                        FollowUpQuestion = 3,
                    },
                        new ChatBotQuestion
                        {
                            FollowUpID = 3,
                            Question = "Bovenooglidcorrectie",
                            Answer = "Een bovenooglidcorrectie kost 1250 euro.",
                        },
                        new ChatBotQuestion
                        {
                            FollowUpID = 3,
                            Question = "Onderooglidcorrectie",
                            Answer = "Een onderooglidcorrectie kost 1000 euro.",
                        },               
                    new ChatBotQuestion
                    {
                        FollowUpID = 2,
                        Question = "Cataractoperatie",
                        Answer = "Een cataractoperatie kost tussen de 800 en 1500 euro.",
                    },
                    new ChatBotQuestion
                    {
                        FollowUpID = 2,
                        Question = "Straaloperatie",
                        Answer = "Een straaloperatie kost tussen de 1250 en 2000 euro.",
                    },
                    
            };


            context.Doctors.AddRange(doctors);
            context.HomeHeaders.Add(header);
            context.Blogs.AddRange(blogs);
            context.ChatBotQuestions.AddRange(chatbotQuestions);
            context.SaveChanges();

        }



    }

}