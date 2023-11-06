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
                    Name = "Dr. J. Van der Veken",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. J. Van der Veken is een ervaren oogarts met een passie voor het verbeteren van het gezichtsvermogen van zijn patiënten. Met jarenlange ervaring in de oogheelkunde, is hij toegewijd aan het bieden van hoogwaardige oogzorg.",
                    InfoOpleiding = "Dr. Van der Veken voltooide zijn medische opleiding aan de Universiteit van Amsterdam en behaalde zijn specialisatiediploma in oogheelkunde aan de Erasmus Universiteit Rotterdam. Hij heeft expertise in de behandeling van diverse oogaandoeningen.",
                    InfoPublicaties = "Dr. Van der Veken heeft bijgedragen aan oogheelkundig onderzoek en heeft diverse onderscheidingen ontvangen voor zijn toewijding aan oogzorg.",
                    Image = "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg",

                },
                new Doctor
                {
                    Name = "Dr. B. Van Coile",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. B. Van Coile is een gepassioneerde oogarts met een diepgaande kennis van oogzorg. Hij streeft naar het bieden van hoogwaardige oogzorg en het verbeteren van het gezichtsvermogen van zijn patiënten.",
                    InfoOpleiding = "Dr. Van Coile voltooide zijn medische opleiding aan de Universiteit van Gent en behaalde zijn specialisatiediploma in oogheelkunde aan de Katholieke Universiteit Leuven. Zijn specialisatie omvat diverse oogheelkundige aandoeningen.",
                    InfoPublicaties = "Hij heeft actief bijgedragen aan oogheelkundig onderzoek en heeft meerdere erkenningen en prijzen ontvangen voor zijn toewijding aan de oogheelkunde.",
                    Image = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*",
                }
            };



            var header = new HomeHeader
            {

                Title = "Vision Oogcentrum Gent",
                Context = "Van harte welkom bij Vision Oogcenter Gent, waar we met liefde en zorg voor uw ogen zorgen. Onze toegewijde oogartsen zijn hier om uw visuele behoeften te vervullen en uw gezichtsvermogen te optimaliseren. Bij ons vindt u de perfecte combinatie van expertise, geavanceerde technologie en persoonlijke aandacht. Stap binnen in een wereld waar dromen van helder zicht werkelijkheid worden. We kijken ernaar uit u te verwelkomen en samen te werken aan een scherpere toekomst."

            };

            var blogs = new Blog[]
            {
                new Blog
                {
                    Title = "Laseroperatie voor bijziendheid: de voor- en nadelen",
                    Text = "Bijziendheid is een veel voorkomende oogafwijking. Het is een "+
                    "refractieafwijking, wat betekent dat het oog niet in staat is om lichtstralen op de juiste manier te breken. Hierdoor ontstaat een wazig beeld. Bijziendheid kan worden gecorrigeerd met een bril of contactlenzen, "+
                    "maar ook met een laseroperatie. In dit artikel lees je meer over de voor- en nadelen van een laseroperatie voor bijziendheid.",
                    Image = "https://img.noordhollandsdagblad.nl/0C2g51q-JZ9mGU4zOu75QV09s_I=/731x411/smart/https://cdn-kiosk-api.telegraaf.nl/6e4b1200-ac99-11e7-9e19-111553951722.jpg"

                },

               new Blog
                {
                    Title = "Vision oogcenter ",
                    Text = "Een nieuwe oogarts in het Vision Oogcentrum Gent: Dr. J. Van der Veken. "+
                    "Dr. J. Van der Veken is een oogarts met een bijzondere interesse in de behandeling van glaucoom en cataract. "+
                    "Hij is een ervaren cataractchirurg en voert ook laserbehandelingen uit voor glaucoom. "+
                    "Daarnaast is hij ook gespecialiseerd in de behandeling van droge ogen. ",
                    Image = "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg"

                }

            };


            context.Doctors.AddRange(doctors);
            context.HomeHeaders.Add(header);
            context.Blogs.AddRange(blogs);
            context.SaveChanges();

        }



    }

}