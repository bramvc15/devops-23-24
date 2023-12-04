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

            doctor1.ImageLink = "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg";
            doctor2.ImageLink = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*";

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
            var scheduleTimeSlotsDoctor1 = new List<ScheduleTimeSlot>();
            var scheduleTimeSlotsDoctor2 = new List<ScheduleTimeSlot>();

            // monday
            var dateMonday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateMonday, 15, DayOfWeek.Monday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateMonday, 15, DayOfWeek.Monday));
                dateMonday = dateMonday.AddMinutes(15);
            }

            // tuesday
            var dateTuesday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateTuesday, 15, DayOfWeek.Tuesday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateTuesday, 15, DayOfWeek.Tuesday));
                dateTuesday = dateTuesday.AddMinutes(15);
            }

            // wednesday
            var dateWednesday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateWednesday, 15, DayOfWeek.Wednesday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateWednesday, 15, DayOfWeek.Wednesday));
                dateWednesday = dateWednesday.AddMinutes(15);
            }

            // thursday
            var dateThursday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateThursday, 15, DayOfWeek.Thursday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateThursday, 15, DayOfWeek.Thursday));
                dateThursday = dateThursday.AddMinutes(15);
            }

            // friday
            var dateFriday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateFriday, 15, DayOfWeek.Friday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateFriday, 15, DayOfWeek.Friday));
                dateFriday = dateFriday.AddMinutes(15);
            }

            foreach (var scheduleTimeSlot in scheduleTimeSlotsDoctor1)
            {
                doctor1.AddScheduleTimeSlot(scheduleTimeSlot);
            }

            foreach (var scheduleTimeSlot in scheduleTimeSlotsDoctor2)
            {
                doctor2.AddScheduleTimeSlot(scheduleTimeSlot);
            }
            #endregion

            #region TimeSlots
            doctor1.ConvertScheduleToTimeSlots(new DateTime(2024, 1, 1, 0, 0, 0), 2);
            doctor2.ConvertScheduleToTimeSlots(new DateTime(2024, 1, 1, 0, 0, 0), 2);
            #endregion

            #region Appointments
            var timeSlot1 = doctor1.TimeSlots[0];
            var timeSlot2 = doctor2.TimeSlots[0];
            
            doctor1.CreateAppointment(patient2, timeSlot1, "Reason: Normal Consultation", "");
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
                    "<p>In welke behandeling bent u geïnteresseerd?</p>",
                    false,
                    new List<ChatBotQuestion>
                    {
                        new ChatBotQuestion(
                            "Ooglidcorrectie",
                            "<p>Over welk soort ooglidcorrectie gaat het?</p>",
                            true,
                            new List<ChatBotQuestion>
                            {
                                new ChatBotQuestion(
                                    "Bovenooglidcorrectie",
                                    "<p>Een bovenooglidcorrectie kost 1250 euro.</p>",
                                    true
                                ),
                                new ChatBotQuestion(
                                    "Onderooglidcorrectie",
                                    "<p>Een onderooglidcorrectie kost 1000 euro.</p>",
                                    true
                                ),
                            }
                        ),
                        new ChatBotQuestion(
                            "Cataractoperatie",
                            "<p>Een cataractoperatie kost tussen de 800 en 1500 euro.</p>", 
                            true
                        ),
                        new ChatBotQuestion(
                            "Straaloperatie",
                            "<p>Een straaloperatie kost tussen de 1250 en 2000 euro.</p>",
                            true
                        ),
                    }
                ),
                new ChatBotQuestion(
                    "Waar is de vestiging gelegen?",
                    "<p>Onze vestiging is gelegen in 9040 Gent, op de Antwerpsesteenweg 1022.</p>",
                    false
                ),
                new ChatBotQuestion(
                    "Hoe maak ik een afspraak?",
                    "<p>Rechtsbovenaan de pagina kan u op de knop <a href='http://127.0.0.1:5046/Afspraak' rel='noopener noreferrer' target='_blank'>'Maak een afspraak'</a> klikken. U wordt dan doorverwezen naar een pagina waar u een afspraak kan maken.</p>",
                    false
                ),
            };
            #endregion

            // domain
            context.Doctors.AddRange(doctors);
            context.Patients.AddRange(patients);

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