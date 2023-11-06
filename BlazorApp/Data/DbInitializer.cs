using BlazorApp.Models;
using BlazorApp.Pages;

namespace BlazorApp.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {

            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.Locations.Any() && context.Contacts.Any())
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

             var location = new LocationM
            {

                Context = "Ergens in GENT, best via de E40 binnen rijden"

            };

               var contact = new ContactM
            {

                Context = "wij zijn mensen en geen ALiens ookal zijn we oogartsen"

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
            context.Locations.Add(location);
            context.Blogs.AddRange(blogs);
            context.Contacts.Add(contact);
            context.SaveChanges();

        }



    }

}