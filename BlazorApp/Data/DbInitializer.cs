using BlazorApp.Models;
using BlazorApp.Pages;

namespace BlazorApp.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {

            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.Locations.Any() && context.Contacts.Any() && context.Treatments.Any() && context.ChatBotQuestions.Any() && context.Appointments.Any() && context.TimeSlots.Any() && context.Patients.Any())
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
                    InfoAbout = "Dr. J. Van der Veken is een ervaren oogarts met een passie voor het verbeteren van het gezichtsvermogen van zijn patiënten. Met jarenlange ervaring in de oogheelkunde, is hij toegewijd aan het bieden van hoogwaardige oogzorg.",
                    InfoEducation = "Dr. Van der Veken voltooide zijn medische opleiding aan de Universiteit van Amsterdam en behaalde zijn specialisatiediploma in oogheelkunde aan de Erasmus Universiteit Rotterdam. Hij heeft expertise in de behandeling van diverse oogaandoeningen.",
                    InfoPublications = "Dr. Van der Veken heeft bijgedragen aan oogheelkundig onderzoek en heeft diverse onderscheidingen ontvangen voor zijn toewijding aan oogzorg.",
                    Image = "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg",

                },
                new Doctor
                {
                    Name = "Dr. B. Van Coile",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoAbout = "Dr. B. Van Coile is een gepassioneerde oogarts met een diepgaande kennis van oogzorg. Hij streeft naar het bieden van hoogwaardige oogzorg en het verbeteren van het gezichtsvermogen van zijn patiënten.",
                    InfoEducation = "Dr. Van Coile voltooide zijn medische opleiding aan de Universiteit van Gent en behaalde zijn specialisatiediploma in oogheelkunde aan de Katholieke Universiteit Leuven. Zijn specialisatie omvat diverse oogheelkundige aandoeningen.",
                    InfoPublications = "Hij heeft actief bijgedragen aan oogheelkundig onderzoek en heeft meerdere erkenningen en prijzen ontvangen voor zijn toewijding aan de oogheelkunde.",
                    Image = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*",
                }
            };



            var header = new HomeHeader
            {

                Title = "Vision Oogcentrum Gent",
                Context = "Van harte welkom bij Vision Oogcenter Gent, waar we met liefde en zorg voor uw ogen zorgen. Onze toegewijde oogartsen zijn hier om uw visuele behoeften te vervullen en uw gezichtsvermogen te optimaliseren. Bij ons vindt u de perfecte combinatie van expertise, geavanceerde technologie en persoonlijke aandacht. Stap binnen in een wereld waar dromen van helder zicht werkelijkheid worden. We kijken ernaar uit u te verwelkomen en samen te werken aan een scherpere toekomst."

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

            var chatbotQuestions = new ChatBotQuestion[]
            {
                new ChatBotQuestion
                {
                    Question = "Hoeveel kost een behandeling?",
                    Answer = "In welke behandeling bent u geïnteresseerd?",
                    FollowUpQuestions = new List<ChatBotQuestion>
                    {
                        new ChatBotQuestion
                        {
                            IsFollowUp = true,
                            Question = "Ooglidcorrectie",
                            Answer = "Over welk soort ooglidcorrectie gaat het?",
                            FollowUpQuestions = new List<ChatBotQuestion>
                            {
                                new ChatBotQuestion
                                {
                                    IsFollowUp = true,
                                    Question = "Bovenooglidcorrectie",
                                    Answer = "Een bovenooglidcorrectie kost 1250 euro.",
                                },
                                new ChatBotQuestion
                                {
                                    IsFollowUp = true,
                                    Question = "Onderooglidcorrectie",
                                    Answer = "Een onderooglidcorrectie kost 1000 euro.",
                                },
                            }
                        },
                        new ChatBotQuestion
                        {
                            IsFollowUp = true,
                            Question = "Cataractoperatie",
                            Answer = "Een cataractoperatie kost tussen de 800 en 1500 euro.",
                        },
                        new ChatBotQuestion
                        {
                            IsFollowUp = true,
                            Question = "Straaloperatie",
                            Answer = "Een straaloperatie kost tussen de 1250 en 2000 euro.",
                        },
                    }
                },
                new ChatBotQuestion
                {
                    Question = "Waar is de vestiging gelegen?",
                    Answer = "Onze vestiging is gelegen in 9040 Gent, op de Antwerpsesteenweg 1022.",
                },
                new ChatBotQuestion
                {
                    Question = "Hoe maak ik een afspraak?",
                    Answer = "Rechtsbovenaan de pagina kan u op de knop 'Maak een afspraak' klikken. U wordt dan doorverwezen naar een pagina waar u een afspraak kan maken.",
                },
            };

            var treatments = new Treatment[]
            {
                new Treatment
                {
                    Name = "Ooglidcorrectie",
                    Description = "Een ooglidcorrectie, ook wel bekend als blepharoplastie, is een verfijnde cosmetische chirurgische procedure die tot doel heeft de jeugdige uitstraling van de ogen te herstellen en functionele problemen in verband met verslapte oogleden te verhelpen. Met het natuurlijke verouderingsproces of genetische factoren kunnen oogleden na verloop van tijd gaan hangen, wat kan resulteren in vermoeidheid, verminderd gezichtsvermogen en een verouderde uitstraling.\n\nBij een ooglidcorrectie verwijdert onze ervaren oogarts zorgvuldig overtollig huid- en vetweefsel rond de ogen. Hierdoor wordt niet alleen de esthetische aantrekkingskracht hersteld, maar ook eventuele gezondheidsproblemen zoals beperkt gezichtsvermogen als gevolg van hangende oogleden kunnen worden verlicht. Onze patiënten ervaren doorgaans minimale ongemakken en een snel herstel, met blijvende resultaten die de jeugdige uitstraling van de ogen herstellen en hun algehele zelfvertrouwen vergroten.\n\nEen ooglidcorrectie kan een levensveranderende ingreep zijn, waardoor patiënten weer kunnen stralen en zich zelfverzekerd voelen. Neem vandaag nog contact met ons op voor een consult om te ontdekken hoe deze procedure u kan helpen de jeugdige, levendige oogopslag te herstellen die u verdient.",
                    Image = "https://blitzware-files.s3.eu-central-1.amazonaws.com/b020388d-71c6-4908-ac78-4cb18403604c-ooglidcorrectie.png"
                },

                new Treatment
                {
                    Name = "Cataractoperatie",
                    Description = "Een cataractoperatie is een veilige en effectieve ingreep die wordt uitgevoerd om cataract, ook wel staar genoemd, te behandelen. Cataract is een veelvoorkomende oogaandoening die optreedt wanneer de natuurlijke ooglens troebel wordt, waardoor het zicht wazig en troebel wordt. Deze vertroebeling kan het dagelijks leven aanzienlijk beïnvloeden, maar met een cataractoperatie kunnen we uw helderheid en kwaliteit van zien herstellen.\n\nTijdens de procedure verwijdert onze bekwame oogarts de troebele ooglens en vervangt deze door een heldere, kunstmatige lens, die bekend staat als een intraoculaire lens (IOL). Deze IOL herstelt uw gezichtsvermogen en stelt u in staat weer scherp en duidelijk te zien. De cataractoperatie is meestal een poliklinische ingreep en wordt uitgevoerd onder lokale verdoving. Patiënten ervaren doorgaans weinig tot geen pijn en kunnen snel terugkeren naar hun dagelijkse activiteiten.\n\nHet herstellen van helder zicht na een cataractoperatie kan een levensveranderende ervaring zijn, waardoor patiënten weer volop van het leven kunnen genieten. Als u symptomen van cataract ervaart, zoals wazig zicht, verblindheid door licht of problemen met nachtzicht, aarzel dan niet om contact met ons op te nemen voor een consult. Onze deskundige oogartsen staan klaar om u te helpen uw gezichtsvermogen te herstellen en uw kwaliteit van leven te verbeteren.",
                    Image = "https://blitzware-files.s3.eu-central-1.amazonaws.com/bff02029-b469-4b50-a468-390035e1fa64-cataractoperatie.png"
                },

                new Treatment
                {
                    Name = "Straaloperatie",
                    Description = "De straaloperatie, ook bekend als lasercorrectie van oogafwijkingen, is een geavanceerde en niet-invasieve procedure die tot doel heeft om de afhankelijkheid van bril of contactlenzen te verminderen of zelfs te elimineren. Deze revolutionaire techniek heeft miljoenen mensen geholpen om scherp en helder zicht te bereiken zonder de belemmeringen van correctieve lenzen.\n\nTijdens een straaloperatie gebruiken onze ervaren oogchirurgen geavanceerde laserapparatuur om microscopisch kleine aanpassingen aan het hoornvlies van het oog aan te brengen. Deze aanpassingen kunnen bijziendheid, verziendheid, astigmatisme en andere oogafwijkingen corrigeren, waardoor het licht op de juiste manier op het netvlies wordt gefocust. De procedure is meestal snel, vrijwel pijnloos en vereist minimaal hersteltijd.\n\nDe voordelen van een straaloperatie zijn talrijk en omvatten een verbeterde kwaliteit van leven, meer vrijheid in uw dagelijkse activiteiten en het verminderen of elimineren van de kosten en het ongemak van brillen of contactlenzen. Veel patiënten ervaren na de ingreep een significante verbetering van hun zicht, waardoor ze scherp en helder kunnen zien zonder enige visuele hulpmiddelen.\n\nAls u geïnteresseerd bent in een straaloperatie om uw zicht te corrigeren, aarzel dan niet om contact met ons op te nemen voor een consult. Onze toegewijde oogartsen staan klaar om uw specifieke behoeften te beoordelen en u te begeleiden naar de best mogelijke oplossing voor uw oogafwijkingen. Ervaar de vrijheid van helder zicht met een straaloperatie en ontdek hoe het uw leven kan veranderen.",
                    Image = "https://blitzware-files.s3.eu-central-1.amazonaws.com/3a88b810-0585-458a-9196-73a0fe215b90-straaloperatie.png"
                },
            };

            var patients = new Patient[]
            {
                new Patient
                {
                    Name = "John",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    BloodGroup = BloodGroup.AMinus,
                    PhoneNumber = "0477777777",
                    Email = "john@mail.com"
                },

                new Patient
                {
                    Name = "Ella",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1991, 1, 1),
                    BloodGroup = BloodGroup.OPlus,
                    PhoneNumber = "0488888888",
                    Email = "ella@mail.com"
                }
            };

            var appointments = new Appointment[]
            {
                new Appointment
                {
                    PatientId = 1,
                    Location = "Gent",
                    DoctorId = 1,
                    Reason = "Ooglidcorrectie vragen",
                    Note = "Ik heb last van hangende oogleden en wil graag een ooglidcorrectie laten uitvoeren."
                },

                new Appointment
                {
                    PatientId = 2,
                    Location = "Gent",
                    DoctorId = 1,
                    Reason = "Cataractoperatie"
                }
            };

            var timeSlots = new TimeSlot[]
            {
                new TimeSlot
                {
                    DoctorId = 1,
                    AppointmentType = AppointmentType.Consulatie,
                    Date = new DateTime(),
                    AppointmentId = 1,
                    IsAvailable = false
                },

                new TimeSlot
                {
                    DoctorId = 2,
                    AppointmentType = AppointmentType.Operatie,
                    Date = new DateTime(),
                    IsAvailable = true
                },

                new TimeSlot
                {
                    DoctorId = 1,
                    AppointmentType = AppointmentType.Consulatie,
                    Date = new DateTime(),
                    AppointmentId = 2,
                    IsAvailable = false
                },

                new TimeSlot
                {
                    DoctorId = 2,
                    AppointmentType = AppointmentType.Operatie,
                    Date = new DateTime(),
                    IsAvailable = true
                },

                new TimeSlot
                {
                    DoctorId = 1,
                    AppointmentType = AppointmentType.Consulatie,
                    Date = new DateTime(),
                    IsAvailable = true
                },

                new TimeSlot
                {
                    DoctorId = 2,
                    AppointmentType = AppointmentType.Operatie,
                    Date = new DateTime(),
                    AppointmentId = 1,
                    IsAvailable = false
                },

                new TimeSlot
                {
                    DoctorId = 1,
                    AppointmentType = AppointmentType.Consulatie,
                    Date = new DateTime(),
                    AppointmentId = 1,
                    IsAvailable = false
                },

                new TimeSlot
                {
                    DoctorId = 2,
                    AppointmentType = AppointmentType.Operatie,
                    Date = new DateTime(),
                    AppointmentId = 1,
                    IsAvailable = false
                },

                new TimeSlot
                {
                    DoctorId = 1,
                    AppointmentType = AppointmentType.Consulatie,
                    Date = new DateTime(),
                    IsAvailable = true
                },

                new TimeSlot
                {
                    DoctorId = 2,
                    AppointmentType = AppointmentType.Operatie,
                    Date = new DateTime(),
                    AppointmentId = 1,
                    IsAvailable = false
                },
            };



            context.Doctors.AddRange(doctors);
            context.HomeHeaders.Add(header);
            context.Locations.Add(location);
            context.Blogs.AddRange(blogs);
            context.Contacts.Add(contact);
            context.Treatments.AddRange(treatments);
            context.ChatBotQuestions.AddRange(chatbotQuestions);
            context.Patients.AddRange(patients);
            context.Appointments.AddRange(appointments);
            context.TimeSlots.AddRange(timeSlots);

            context.SaveChanges();

        }



    }

}