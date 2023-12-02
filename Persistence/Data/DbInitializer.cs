using Domain;
using System.Runtime.ConstrainedExecution;
using Shared.Enums;

namespace Persistence.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {
            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.Locations.Any() && context.Contacts.Any() && context.Treatments.Any() && context.Patients.Any() && context.TimeSlots.Any() && context.ScheduleTimeSlots.Any() && context.Appointments.Any())
            {
                return;
            }

            // domain
            #region Doctors
            Doctor doctor1 = new("Dr. J. Van der Veken", "Eye Specialist", Gender.Male, 
                "Dr. J. Van der Veken is een ervaren oogarts met een passie voor het verbeteren van het gezichtsvermogen van zijn patiënten. Met jarenlange ervaring in de oogheelkunde, is hij toegewijd aan het bieden van hoogwaardige oogzorg."
                );
            
            Doctor doctor2 = new("Dr. Smith", "Eye Specialist", Gender.Male, "Dit is Dr. Smith zijn Bio.");

            // doctor1.SetImageLink("https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg");
            // doctor2.SetImageLink("https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*");

            var doctors = new Doctor[]
            {
                doctor1, doctor2,
            };
            #endregion

            #region Patients
            Patient patient1 = new("John", "john@mail.com", "+32477777777", new DateTime(1990, 1, 1), Gender.Male, BloodType.ANegative);
            Patient patient2 = new("Ella", "ella@mail.com", "+32488888888", new DateTime(1991, 1, 1), Gender.Female, BloodType.OPositive);

            var patients = new Patient[]
            {
                patient1, patient2,
            };
            #endregion

            #region ScheduleTimeSlots
            // Monday
            ScheduleTimeSlot scheduleTimeSlot1 = new(new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot2 = new(new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot3 = new(new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot4 = new(new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot5 = new(new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot6 = new(new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot7 = new(new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot8 = new(new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Monday);
            ScheduleTimeSlot scheduleTimeSlot9 = new(new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Monday);

            // Tuesday
            ScheduleTimeSlot scheduleTimeSlot10 = new(new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot11 = new(new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot12 = new(new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot13 = new(new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot14 = new(new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot15 = new(new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot16 = new(new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot17 = new(new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Tuesday);
            ScheduleTimeSlot scheduleTimeSlot18 = new(new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Tuesday);

            // Wednesday
            ScheduleTimeSlot scheduleTimeSlot19 = new(new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Wednesday);
            ScheduleTimeSlot scheduleTimeSlot20 = new(new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Wednesday);
            ScheduleTimeSlot scheduleTimeSlot21 = new(new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Wednesday);
            ScheduleTimeSlot scheduleTimeSlot22 = new(new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Wednesday);

            // Thursday
            ScheduleTimeSlot scheduleTimeSlot23 = new(new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot24 = new(new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot25 = new(new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot26 = new(new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot27 = new(new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot28 = new(new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot29 = new(new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot30 = new(new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Thursday);
            ScheduleTimeSlot scheduleTimeSlot31 = new(new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Thursday);

            // Friday
            ScheduleTimeSlot scheduleTimeSlot32 = new(new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot33 = new(new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot34 = new(new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot35 = new(new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot36 = new(new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot37 = new(new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot38 = new(new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot39 = new(new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Friday);
            ScheduleTimeSlot scheduleTimeSlot40 = new(new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Friday);

            var scheduleTimeSlots = new ScheduleTimeSlot[]
            {
                scheduleTimeSlot1, scheduleTimeSlot2, scheduleTimeSlot3, scheduleTimeSlot4, scheduleTimeSlot5, scheduleTimeSlot6, scheduleTimeSlot7, 
                scheduleTimeSlot8, scheduleTimeSlot9, scheduleTimeSlot10, scheduleTimeSlot11, scheduleTimeSlot12, scheduleTimeSlot13, scheduleTimeSlot14, 
                scheduleTimeSlot15, scheduleTimeSlot16, scheduleTimeSlot17, scheduleTimeSlot18, scheduleTimeSlot19, scheduleTimeSlot20, scheduleTimeSlot21,
                scheduleTimeSlot22, scheduleTimeSlot23, scheduleTimeSlot24, scheduleTimeSlot25, scheduleTimeSlot26, scheduleTimeSlot27, scheduleTimeSlot28,
                scheduleTimeSlot29, scheduleTimeSlot30, scheduleTimeSlot31, scheduleTimeSlot32, scheduleTimeSlot33, scheduleTimeSlot34, scheduleTimeSlot35,
                scheduleTimeSlot36, scheduleTimeSlot37, scheduleTimeSlot38, scheduleTimeSlot39, scheduleTimeSlot40,
            };

            foreach (var scheduleTimeSlot in scheduleTimeSlots)
            {
                doctor1.AddScheduleTimeSlot(scheduleTimeSlot);
                doctor2.AddScheduleTimeSlot(scheduleTimeSlot);
            }
            #endregion

            #region TimeSlots

            TimeSlot timeSlot1 = new(AppointmentType.Consultation, new DateTime(2023, 12, 23, 8, 0, 0), 45);
            TimeSlot timeSlot2 = new(AppointmentType.Operation, new DateTime(2023, 12, 23, 9, 0, 0), 45);
            TimeSlot timeSlot3 = new(AppointmentType.Consultation, new DateTime(2023, 12, 23, 10, 0, 0), 45);
            TimeSlot timeSlot4 = new(AppointmentType.Operation, new DateTime(2023, 12, 23, 11, 0, 0), 45);
            TimeSlot timeSlot5 = new(AppointmentType.Consultation, new DateTime(2023, 12, 23, 12, 0, 0), 45);
            TimeSlot timeSlot6 = new(AppointmentType.Operation, new DateTime(2023, 12, 23, 13, 0, 0), 45);
            TimeSlot timeSlot7 = new(AppointmentType.Consultation, new DateTime(2023, 12, 23, 14, 0, 0), 45);
            TimeSlot timeSlot8 = new(AppointmentType.Operation, new DateTime(2023, 12, 23, 15, 0, 0), 45);
            TimeSlot timeSlot9 = new(AppointmentType.Consultation, new DateTime(2023, 12, 23, 16, 0, 0), 45);
            TimeSlot timeSlot10 = new(AppointmentType.Operation, new DateTime(2023, 12, 23, 17, 0, 0), 45);

            var timeSlots = new TimeSlot[]
            {
                timeSlot1, timeSlot2, timeSlot3, timeSlot4, timeSlot5, timeSlot6, timeSlot7, timeSlot8, timeSlot9, timeSlot10,
            };

            foreach (var timeSlot in timeSlots)
            {
                doctor1.AddTimeSlot(timeSlot);
                doctor2.AddTimeSlot(timeSlot);
            }
            #endregion

            #region Appointments

            /*
            Appointment appointment1 = new(patient2, "Reason: Normal Consultation", "");
            Appointment appointment2 = new(patient2, "Reason: Normal Operation", "Ik heb last van hangende oogleden en wil graag een ooglidcorrectie laten uitvoeren.");

            var appointments = new Appointment[]
            {
                appointment1, appointment2,
            };
            */


            doctor2.CreateAppointment(patient2, timeSlot1, "Reason: Normal Consultation", "");
            doctor2.CreateAppointment(patient2, timeSlot2, "Reason: Normal Operation", "Ik heb last van hangende oogleden en wil graag een ooglidcorrectie laten uitvoeren.");
            #endregion

            // CMS
            #region Header
            HomeHeader header = new("Vision Oogcentrum Gent", "Van harte welkom bij Vision Oogcenter Gent, waar we met liefde en zorg voor uw ogen zorgen. Onze toegewijde oogartsen zijn hier om uw visuele behoeften te vervullen en uw gezichtsvermogen te optimaliseren. Bij ons vindt u de perfecte combinatie van expertise, geavanceerde technologie en persoonlijke aandacht. Stap binnen in een wereld waar dromen van helder zicht werkelijkheid worden. We kijken ernaar uit u te verwelkomen en samen te werken aan een scherpere toekomst.");
            #endregion

            #region Location
            Location location = new("Onze vestiging is gelegen in 9040 Gent, op de Antwerpsesteenweg 1022.");
            #endregion

            #region Contact
            Contact contact = new("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus turpis nunc, ut euismod nisi molestie rhoncus. Donec id mattis nibh. Pellentesque et laoreet odio. Cras vehicula aliquam molestie. Mauris vestibulum elit posuere pellentesque aliquet. In ut ipsum et dolor lacinia interdum convallis a tortor. Donec ut sodales nisi, eget porttitor nisi. Suspendisse bibendum neque in nisi facilisis, ac efficitur velit euismod. Curabitur tempus ut arcu tristique blandit. Cras tincidunt scelerisque justo, quis malesuada urna ultrices id. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean vehicula justo interdum mauris fringilla vulputate.");
            #endregion

            #region Treatments
            var treatments = new Treatment[]
            {
                new Treatment("Ooglidcorrectie", "Een ooglidcorrectie, ook wel bekend als blepharoplastie, is een verfijnde cosmetische chirurgische procedure die tot doel heeft de jeugdige uitstraling van de ogen te herstellen en functionele problemen in verband met verslapte oogleden te verhelpen. Met het natuurlijke verouderingsproces of genetische factoren kunnen oogleden na verloop van tijd gaan hangen, wat kan resulteren in vermoeidheid, verminderd gezichtsvermogen en een verouderde uitstraling.\n\nBij een ooglidcorrectie verwijdert onze ervaren oogarts zorgvuldig overtollig huid- en vetweefsel rond de ogen. Hierdoor wordt niet alleen de esthetische aantrekkingskracht hersteld, maar ook eventuele gezondheidsproblemen zoals beperkt gezichtsvermogen als gevolg van hangende oogleden kunnen worden verlicht. Onze patiënten ervaren doorgaans minimale ongemakken en een snel herstel, met blijvende resultaten die de jeugdige uitstraling van de ogen herstellen en hun algehele zelfvertrouwen vergroten.\n\nEen ooglidcorrectie kan een levensveranderende ingreep zijn, waardoor patiënten weer kunnen stralen en zich zelfverzekerd voelen. Neem vandaag nog contact met ons op voor een consult om te ontdekken hoe deze procedure u kan helpen de jeugdige, levendige oogopslag te herstellen die u verdient.", "https://blitzware-files.s3.eu-central-1.amazonaws.com/b020388d-71c6-4908-ac78-4cb18403604c-ooglidcorrectie.png"),
                new Treatment("Cataractoperatie", "Een cataractoperatie is een veilige en effectieve ingreep die wordt uitgevoerd om cataract, ook wel staar genoemd, te behandelen. Cataract is een veelvoorkomende oogaandoening die optreedt wanneer de natuurlijke ooglens troebel wordt, waardoor het zicht wazig en troebel wordt. Deze vertroebeling kan het dagelijks leven aanzienlijk beïnvloeden, maar met een cataractoperatie kunnen we uw helderheid en kwaliteit van zien herstellen.\n\nTijdens de procedure verwijdert onze bekwame oogarts de troebele ooglens en vervangt deze door een heldere, kunstmatige lens, die bekend staat als een intraoculaire lens (IOL). Deze IOL herstelt uw gezichtsvermogen en stelt u in staat weer scherp en duidelijk te zien. De cataractoperatie is meestal een poliklinische ingreep en wordt uitgevoerd onder lokale verdoving. Patiënten ervaren doorgaans weinig tot geen pijn en kunnen snel terugkeren naar hun dagelijkse activiteiten.\n\nHet herstellen van helder zicht na een cataractoperatie kan een levensveranderende ervaring zijn, waardoor patiënten weer volop van het leven kunnen genieten. Als u symptomen van cataract ervaart, zoals wazig zicht, verblindheid door licht of problemen met nachtzicht, aarzel dan niet om contact met ons op te nemen voor een consult. Onze deskundige oogartsen staan klaar om u te helpen uw gezichtsvermogen te herstellen en uw kwaliteit van leven te verbeteren.", "https://blitzware-files.s3.eu-central-1.amazonaws.com/bff02029-b469-4b50-a468-390035e1fa64-cataractoperatie.png"),
                new Treatment("Straaloperatie", "De straaloperatie, ook bekend als lasercorrectie van oogafwijkingen, is een geavanceerde en niet-invasieve procedure die tot doel heeft om de afhankelijkheid van bril of contactlenzen te verminderen of zelfs te elimineren. Deze revolutionaire techniek heeft miljoenen mensen geholpen om scherp en helder zicht te bereiken zonder de belemmeringen van correctieve lenzen.\n\nTijdens een straaloperatie gebruiken onze ervaren oogchirurgen geavanceerde laserapparatuur om microscopisch kleine aanpassingen aan het hoornvlies van het oog aan te brengen. Deze aanpassingen kunnen bijziendheid, verziendheid, astigmatisme en andere oogafwijkingen corrigeren, waardoor het licht op de juiste manier op het netvlies wordt gefocust. De procedure is meestal snel, vrijwel pijnloos en vereist minimaal hersteltijd.\n\nDe voordelen van een straaloperatie zijn talrijk en omvatten een verbeterde kwaliteit van leven, meer vrijheid in uw dagelijkse activiteiten en het verminderen of elimineren van de kosten en het ongemak van brillen of contactlenzen. Veel patiënten ervaren na de ingreep een significante verbetering van hun zicht, waardoor ze scherp en helder kunnen zien zonder enige visuele hulpmiddelen.\n\nAls u geïnteresseerd bent in een straaloperatie om uw zicht te corrigeren, aarzel dan niet om contact met ons op te nemen voor een consult. Onze toegewijde oogartsen staan klaar om uw specifieke behoeften te beoordelen en u te begeleiden naar de best mogelijke oplossing voor uw oogafwijkingen. Ervaar de vrijheid van helder zicht met een straaloperatie en ontdek hoe het uw leven kan veranderen.", "https://blitzware-files.s3.eu-central-1.amazonaws.com/3a88b810-0585-458a-9196-73a0fe215b90-straaloperatie.png")
            };
            #endregion

            #region Blogs
            var blogs = new Blog[]
            {
                new Blog("Laseroperatie voor bijziendheid: de voor- en nadelen", 
                    "Bijziendheid is een veel voorkomende oogafwijking. Het is een "+
                    "refractieafwijking, wat betekent dat het oog niet in staat is om lichtstralen op de juiste manier te breken. Hierdoor ontstaat een wazig beeld. Bijziendheid kan worden gecorrigeerd met een bril of contactlenzen, "+
                    "maar ook met een laseroperatie. In dit artikel lees je meer over de voor- en nadelen van een laseroperatie voor bijziendheid.", 
                    "https://img.noordhollandsdagblad.nl/0C2g51q-JZ9mGU4zOu75QV09s_I=/731x411/smart/https://cdn-kiosk-api.telegraaf.nl/6e4b1200-ac99-11e7-9e19-111553951722.jpg"),
                new Blog("Vision Oogcentrum",
                    "Een nieuwe oogarts in het Vision Oogcentrum Gent: Dr. J. Van der Veken. "+
                    "Dr. J. Van der Veken is een oogarts met een bijzondere interesse in de behandeling van glaucoom en cataract. "+
                    "Hij is een ervaren cataractchirurg en voert ook laserbehandelingen uit voor glaucoom. "+
                    "Daarnaast is hij ook gespecialiseerd in de behandeling van droge ogen. ",
                    "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg")

            };
            #endregion

            #region ChatBotQuestions
            var chatbotQuestions = new ChatBotQuestion[]
            {
                new ChatBotQuestion(
                    "Hoeveel kost een behandeling?",
                    "In welke behandeling bent u geïnteresseerd?",
                    false,
                    new List<ChatBotQuestion>
                    {
                        new ChatBotQuestion(
                            "Ooglidcorrectie",
                            "Over welk soort ooglidcorrectie gaat het?",
                            true,
                            new List<ChatBotQuestion>
                            {
                                new ChatBotQuestion(
                                    "Bovenooglidcorrectie",
                                    "Een bovenooglidcorrectie kost 1250 euro.",
                                    true
                                ),
                                new ChatBotQuestion(
                                    "Onderooglidcorrectie",
                                    "Een onderooglidcorrectie kost 1000 euro.",
                                    true
                                ),
                            }
                        ),
                        new ChatBotQuestion(
                            "Cataractoperatie",
                            "Een cataractoperatie kost tussen de 800 en 1500 euro.", 
                            true
                        ),
                        new ChatBotQuestion(
                            "Straaloperatie",
                            "Een straaloperatie kost tussen de 1250 en 2000 euro.",
                            true
                        ),
                    }
                ),
                new ChatBotQuestion(
                    "Waar is de vestiging gelegen?",
                    "Onze vestiging is gelegen in 9040 Gent, op de Antwerpsesteenweg 1022.",
                    false
                ),
                new ChatBotQuestion(
                    "Hoe maak ik een afspraak?",
                    "Rechtsbovenaan de pagina kan u op de knop 'Maak een afspraak' klikken. U wordt dan doorverwezen naar een pagina waar u een afspraak kan maken.",
                    false
                ),
            };
            #endregion

            // domain
            context.Doctors.AddRange(doctors);
            context.Patients.AddRange(patients);
            // context.ScheduleTimeSlots.AddRange(scheduleTimeSlots);
            // context.TimeSlots.AddRange(timeSlots);
            // context.Appointments.AddRange(appointments);

            // CMS
            context.HomeHeaders.Add(header);
            context.Locations.Add(location);
            context.Contacts.Add(contact);
            context.Blogs.AddRange(blogs);
            context.Treatments.AddRange(treatments);
            context.ChatBotQuestions.AddRange(chatbotQuestions);
            
            context.SaveChanges();
        }
    }
}