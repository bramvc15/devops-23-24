using BlazorApp.Models;
using BlazorApp.Pages;

namespace BlazorApp.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {

            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any())
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


            context.Doctors.AddRange(doctors);
            context.HomeHeaders.Add(header);
            context.Blogs.AddRange(blogs);
            context.SaveChanges();

        }



    }

}