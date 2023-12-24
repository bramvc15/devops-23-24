using Domain;
using System.Runtime.ConstrainedExecution;
using Shared.Enums;

namespace Persistence.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {
            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.Locations.Any() && context.Treatments.Any() && context.Patients.Any() && context.TimeSlots.Any() && context.ScheduleTimeSlots.Any() && context.Appointments.Any() && context.Faqs.Any() && context.Notes.Any() && context.Messages.Any())
            {
                return;
            }

            // domain
            #region Doctors
            

            Doctor admin = new("Ozlem Kose", "Oogarts - oogchirurg", Gender.Female, "Dokter Ozlem Kose behaalde haar diploma in de geneeskunde in 2013 aan de Vrije Universiteit Brussel. Na haar opleiding geneeskunde specialiseerde ze zich gedurende vier jaar in de oftalmologie aan de Université Libre de Bruxelles. Dr. Kose behaalde een bijkomende interuniversitaire diploma \"Inflammations et Infections oculaires\" aan de Universiteit Paris Diderot in Frankrijk. Verder is ze Fellow van de European Board of Ophthalmology. Na haar specialisatie trok ze in 2017 een maand naar India voor een fellowship in de cataract en refractieve chirurgie onder begeleiding van Prof. Dr. Agarwal. Vervolgens genoot ze gedurende 6 maanden van een bijkomende chirurgische vorming onder begeleiding van Dr. Gatinel in het Fondation Rothschild te Parijs. Verder sub specialiseerde ze zich in de orbito palpebrale chirurgie (oogleden, traanwegen en orbita) op de afdelingen oftalmologie van het CHU Brugmann ziekenhuis en het Sint-Pietersziekenhuis te Brussel. Ten slotte volgde ze gedurende één haar een fellowship in het Oogziekenhuis van Rotterdam om zich verder te bekwamen in de oculoplastische chirurgie. Actueel is ze sinds 2019 verbonden aan het AZ Sint Lucas Ziekenhuis in Gent waar ze haar vooral toespitst op chirurgie van de oogleden, traanwegen, cataract, maar ook op algemene oogheelkundige aandoeningen." );
            Doctor employee = new("Eline De Pauw", "Optometrist", Gender.Female);
            Doctor employee2 = new("Diete Paternoster", "Orthoptist", Gender.Female);


            admin.Auth0Id = "auth0|6571dae55941b4686e3fd96a";
            employee.Auth0Id = "auth0|6571db555941b4686e3fd9c2";
            employee2.Auth0Id = "auth0|65846e3e61f1db9d400564f8";
            
            admin.ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/a358792c-a244-46c4-a49a-d3d37dfeb11c-kose.jpg";
            employee.ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/2d16503a-d4b7-485b-90f2-51aa91e9010e-Foto Eline De Pauw.jpeg";
            employee2.ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/b53abad5-80ec-44ac-86f8-f0db2c17709a-Foto Diete Paternoster .png";

            var doctors = new Doctor[]
            {
                admin, employee, employee2,
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
            var scheduleTimeSlotsDoctor3 = new List<ScheduleTimeSlot>();

            // monday
            var dateMonday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateMonday, 15, DayOfWeek.Monday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateMonday, 15, DayOfWeek.Monday));
                scheduleTimeSlotsDoctor3.Add(new ScheduleTimeSlot(dateMonday, 15, DayOfWeek.Monday));
                dateMonday = dateMonday.AddMinutes(15);
            }

            // tuesday
            var dateTuesday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateTuesday, 15, DayOfWeek.Tuesday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateTuesday, 15, DayOfWeek.Tuesday));
                scheduleTimeSlotsDoctor3.Add(new ScheduleTimeSlot(dateTuesday, 15, DayOfWeek.Tuesday));
                dateTuesday = dateTuesday.AddMinutes(15);
            }

            // wednesday
            var dateWednesday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateWednesday, 15, DayOfWeek.Wednesday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateWednesday, 15, DayOfWeek.Wednesday));
                scheduleTimeSlotsDoctor3.Add(new ScheduleTimeSlot(dateWednesday, 15, DayOfWeek.Wednesday));
                dateWednesday = dateWednesday.AddMinutes(15);
            }

            // thursday
            var dateThursday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateThursday, 15, DayOfWeek.Thursday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateThursday, 15, DayOfWeek.Thursday));
                scheduleTimeSlotsDoctor3.Add(new ScheduleTimeSlot(dateThursday, 15, DayOfWeek.Thursday));
                dateThursday = dateThursday.AddMinutes(15);
            }

            // friday
            var dateFriday = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < 40; i++)
            {
                scheduleTimeSlotsDoctor1.Add(new ScheduleTimeSlot(dateFriday, 15, DayOfWeek.Friday));
                scheduleTimeSlotsDoctor2.Add(new ScheduleTimeSlot(dateFriday, 15, DayOfWeek.Friday));
                scheduleTimeSlotsDoctor3.Add(new ScheduleTimeSlot(dateFriday, 15, DayOfWeek.Friday));
                dateFriday = dateFriday.AddMinutes(15);
            }

            foreach (var scheduleTimeSlot in scheduleTimeSlotsDoctor1)
            {
                admin.AddScheduleTimeSlot(scheduleTimeSlot);
            }

            foreach (var scheduleTimeSlot in scheduleTimeSlotsDoctor2)
            {
                employee.AddScheduleTimeSlot(scheduleTimeSlot);
            }

            foreach (var scheduleTimeSlot in scheduleTimeSlotsDoctor3)
            {
                employee2.AddScheduleTimeSlot(scheduleTimeSlot);
            }
            #endregion

            #region TimeSlots
            admin.ConvertScheduleToTimeSlots(new DateTime(2024, 1, 1, 0, 0, 0), 2);
            employee.ConvertScheduleToTimeSlots(new DateTime(2024, 1, 1, 0, 0, 0), 2);
            employee2.ConvertScheduleToTimeSlots(new DateTime(2024, 1, 1, 0, 0, 0), 2);
            #endregion

            #region Appointments
            var timeSlot1 = admin.TimeSlots[0];
            var timeSlot2 = employee.TimeSlots[0];
            var timeSlot3 = employee2.TimeSlots[0];
            
            admin.CreateAppointment(patient2, timeSlot1, "Reason: Normal Consultation", "");
            employee.CreateAppointment(patient2, timeSlot2, "Reason: Normal Operation", "Ik heb last van hangende oogleden en wil graag een ooglidcorrectie laten uitvoeren.");
            employee2.CreateAppointment(patient2, timeSlot3, "Reason: Normal Consultation", "Last van bolle ogen.");
            #endregion

            // CMS
            #region Header
            HomeHeader header = new("Oogcentrum Vision Gent", "Van harte welkom bij Oogcentrum Vision Gent, waar we met liefde en zorg voor uw ogen zorgen. Onze toegewijde oogartsen zijn hier om uw visuele behoeften te vervullen en uw gezichtsvermogen te optimaliseren. Bij ons vindt u de perfecte combinatie van expertise, geavanceerde technologie en persoonlijke aandacht. Stap binnen in een wereld waar dromen van helder zicht werkelijkheid worden. We kijken ernaar uit u te verwelkomen en samen te werken aan een scherpere toekomst.");
            #endregion

            #region Location
            Location location = new("Antwerpsesteenweg 1022", "9040 Gent", "België", "vision@mail.com", "09 89 78 78 11", 
                "Maandag - Vrijdag: 8:00 - 18:00", "Zaterdag - Zondag: Gesloten");
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
                new Blog("Oogcentrum Vision",
                    "Een nieuwe oogarts in het Oogcentrum Vision Gent: Dr. J. Van der Veken. "+
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

            #region Faqs
            var faqs = new Faq[]
            {
               new Faq("Wat zijn de meest voorkomende oogaandoeningen?", "Veelvoorkomende oogaandoeningen zijn bijziendheid, verziendheid, astigmatisme, cataract, glaucoom, maculadegeneratie en droge ogen."),
               new Faq("Wat zijn de symptomen van droge ogen?", "Brandend gevoel, jeuk, roodheid, wazig zicht, gevoeligheid voor licht en het gevoel van iets in het oog."),
               new Faq("Wat is glaucoom en hoe wordt het behandeld?", "Glaucoom beschadigt de oogzenuw en kan behandeld worden met oogdruppels, lasertherapie of chirurgie."),
               new Faq("Hoe kan ik mijn ogen gezond houden?", "Regelmatige controles, beschermende brillen, een gezond dieet en beperkte schermtijd kunnen helpen."),
               new Faq("Wat is het verschil tussen bijziendheid en verziendheid?", "Bijziendheid bemoeilijkt het zien van verre objecten, terwijl verziendheid moeilijkheden oplevert bij het zien van dichtbij"),
               new Faq("Welke leeftijdsgroepen hebben een hoger risico op oogaandoeningen?", "Oogaandoeningen kunnen op elke leeftijd voorkomen, maar staar komt vaker voor bij oudere volwassenen en amblyopie bij jonge kinderen."),
               new Faq("Wat zijn de risicofactoren voor maculadegeneratie?", "Leeftijd, genetica, roken, UV-blootstelling en levensstijl verhogen het risico."),
               new Faq("Hoe bescherm ik mijn ogen tegen zonneschade?", "Draag een zonnebril met UV-bescherming, vermijd langdurige blootstelling aan de zon en draag een hoed met een brede rand."),
               new Faq("Wat zijn de behandelingen voor astigmatisme?", "Brillen, contactlenzen, LASIK of PRK kunnen astigmatisme corrigeren."),
               new Faq("Hoe vaak moet ik mijn ogen laten controleren?", "Elke twee jaar voor mensen zonder bekende problemen. Vaker voor mensen met oogproblemen of risicofactoren, zoals geadviseerd door een oogarts.")
            };
            #endregion

            #region Notes
            var notes = new Note[]
            {
                new Note("Note 1", "This is the first note")
            };
            #endregion

            #region Messages
            var messages = new Message[]
            {
                new Message("John", "Doe", "john@mail.com", "0489481512", new DateTime(1990, 1, 1), "This is the first message!", false),
                new Message("Thommy", "Shelby", "thommy@mail.com", "0489481512", new DateTime(1990, 1, 1), "Ik hoop dat dit berichtje u bereikt te midden van uw drukke dagen. Terwijl de feestdagen dichterbij komen, vroeg ik me af of u een momentje tijd heeft om mijn wens te horen...", false),
                new Message("Tow", "Mater", "tow@mail.com", "0489481512", new DateTime(1990, 1, 1), "Ik word steeds roestiger en roestiger. Voro deze reden kan ik ook niet zo goed meer autorijden. Kunt u me helpen?", false),
                new Message("Buzz", "Lightyear", "buzz@mail.com", "0489481512", new DateTime(1990, 1, 1), "Naar de sterren, en er dan voorbij!", false),
                new Message("Jack", "Sparrow", "jack@mail.com", "0489481512", new DateTime(1990, 1, 1), "The beste piraat deze wereld ooit gezien heeft! Ik hou van wiskey ook.", false),
            };
            #endregion


            // domain
            context.Doctors.AddRange(doctors);
            context.Patients.AddRange(patients);
            context.Messages.AddRange(messages);

            // CMS
            context.HomeHeaders.Add(header);
            context.Locations.Add(location);
            context.Blogs.AddRange(blogs);
            context.Treatments.AddRange(treatments);
            context.ChatBotQuestions.AddRange(chatbotQuestions);
            context.Faqs.AddRange(faqs);
            context.Notes.AddRange(notes);
            
            context.SaveChanges();
        }
    }
}