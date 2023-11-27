using Domain;
using Shared;
using System.Runtime.ConstrainedExecution;

namespace BlazorApp.Data
{

    public static class DbInitializer
    {

        public static void Initialize(DatabaseContext context)
        {

            if (context.Doctors.Any() && context.HomeHeaders.Any() && context.Blogs.Any() && context.Locations.Any() && context.Contacts.Any() && context.Treatments.Any() && context.ChatBotQuestions.Any() && context.Appointments.Any() && context.TimeSlots.Any() && context.Patients.Any() && context.ScheduleTimeSlots.Any())
            {
                return;
            }

            // domain
            #region Doctors
            Doctor doctor1 = new Doctor("Dr. J. Van der Veken", "Eye Specialist", Gender.Male, "Dr. J. Van der Veken is een ervaren oogarts met een passie voor het verbeteren van het gezichtsvermogen van zijn patiënten. Met jarenlange ervaring in de oogheelkunde, is hij toegewijd aan het bieden van hoogwaardige oogzorg.");
            Doctor doctor2 = new Doctor("Dr. Smith", "Eye Specialist", Gender.Male, "Dit is Dr. Smith zijn Bio.");

            var doctors = new Doctor[]
            {
                doctor1, doctor2,
            };

            /* OLD Doctors
             * new Doctor {
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
                },
                new Doctor
                {
                    Name = "Dr. S. Patel",
                    Gender = "Female",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. S. Patel is a dedicated eye specialist committed to providing comprehensive eye care services. With a focus on patient well-being, she brings a wealth of experience in treating various eye conditions.",
                    InfoOpleiding = "Dr. Patel earned her medical degree from Johns Hopkins University and completed her specialization in ophthalmology at Harvard Medical School. She is well-versed in the latest advancements in eye care.",
                    InfoPublicaties = "Actively involved in eye care research, Dr. Patel has published numerous articles and received recognition for her outstanding contributions to the field.",
                    Image = "https://www.stevensegallery.com/640/360",
                },
                new Doctor
                {
                    Name = "Dr. M. García",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. M. García is a passionate eye specialist dedicated to improving the vision and eye health of his patients. With a background in ophthalmology, he provides personalized and advanced eye care.",
                    InfoOpleiding = "Dr. García completed his medical training at the University of Barcelona and pursued his specialization in ophthalmology at King's College London. He has expertise in a wide range of eye conditions.",
                    InfoPublicaties = "Contributing to eye care research, Dr. García has presented at international conferences and received accolades for his commitment to excellence in ophthalmology.",
                    Image = "https://www.stevensegallery.com/640/361",
                },
                new Doctor
                {
                    Name = "Dr. A. Wang",
                    Gender = "Female",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. A. Wang is an experienced eye specialist with a focus on delivering comprehensive and compassionate eye care. She is dedicated to enhancing the visual health and well-being of her patients.",
                    InfoOpleiding = "Dr. Wang graduated from Stanford University School of Medicine and completed her residency in ophthalmology at the Mayo Clinic. She is skilled in the latest diagnostic and treatment techniques.",
                    InfoPublicaties = "Actively involved in eye research, Dr. Wang has published research papers in renowned journals and received awards for her significant contributions to the field.",
                    Image = "https://www.stevensegallery.com/640/362",
                },
                new Doctor
                {
                    Name = "Dr. R. Singh",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. R. Singh is a dedicated eye specialist committed to providing high-quality eye care services. With extensive experience, he focuses on the diagnosis and treatment of various eye conditions.",
                    InfoOpleiding = "Dr. Singh completed his medical education at the University of Delhi and pursued his specialization in ophthalmology at Johns Hopkins University. He is proficient in advanced eye surgeries.",
                    InfoPublicaties = "Contributing to eye care advancements, Dr. Singh has published research articles and received recognition for his outstanding contributions to the field.",
                    Image = "https://www.stevensegallery.com/640/363",
                },
                new Doctor
                {
                    Name = "Dr. E. Martinez",
                    Gender = "Female",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. E. Martinez is a compassionate eye specialist dedicated to providing patient-centered eye care. With expertise in various eye conditions, she strives to improve the vision and ocular health of her patients.",
                    InfoOpleiding = "Dr. Martinez received her medical degree from Columbia University and completed her residency in ophthalmology at the University of California, San Francisco. She is proficient in the latest diagnostic technologies.",
                    InfoPublicaties = "Actively contributing to eye care research, Dr. Martinez has presented at national conferences and received awards for her commitment to excellence in ophthalmology.",
                    Image = "https://www.stevensegallery.com/640/364",
                },
                new Doctor
                {
                    Name = "Dr. K. Johnson",
                    Gender = "Male",
                    Specialization = "Eye Specialist",
                    InfoOver = "Dr. K. Johnson is a skilled eye specialist dedicated to providing exceptional eye care services. With a focus on patient satisfaction, he brings expertise in the diagnosis and treatment of a wide range of eye conditions.",
                    InfoOpleiding = "Dr. Johnson completed his medical training at the University of Chicago and pursued his specialization in ophthalmology at the Cleveland Clinic. He is well-versed in advanced eye surgeries.",
                    InfoPublicaties = "Contributing to advancements in eye care, Dr. Johnson has authored research articles and received recognition for his significant contributions to the field.",
                    Image = "https://www.stevensegallery.com/640/365",
                }
             */
            #endregion

            #region Patients
            Patient patient1 = new Patient("John", "john@mail.com", "+32477777777", new DateTime(1990, 1, 1), Gender.Male, BloodType.ANegative);
            Patient patient2 = new Patient("Ella", "ella@mail.com", "+32488888888", new DateTime(1991, 1, 1), Gender.Female, BloodType.OPositive);

            var patients = new Patient[]
            {
                patient1, patient2,
            };
            #endregion

            #region ScheduleTimeSlots
            // Monday
            ScheduleTimeSlot scheduleTimeSlot1 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot2 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot3 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot4 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot5 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot6 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot7 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot8 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot9 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Monday, "Dr. Smith");

            // Tuesday
            ScheduleTimeSlot scheduleTimeSlot10 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot11 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot12 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot13 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot14 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot15 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot16 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot17 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot18 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Tuesday, "Dr. Smith");

            // Wednesday
            ScheduleTimeSlot scheduleTimeSlot19 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Wednesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot20 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Wednesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot21 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Wednesday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot22 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Wednesday, "Dr. Smith");

            // Thursday
            ScheduleTimeSlot scheduleTimeSlot23 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot24 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot25 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot26 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot27 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot28 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot29 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot30 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot31 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Thursday, "Dr. Smith");

            // Friday
            ScheduleTimeSlot scheduleTimeSlot32 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 8, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot33 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 9, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot34 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 10, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot35 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 11, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot36 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 13, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot37 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 14, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot38 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 15, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot39 = new ScheduleTimeSlot(AppointmentType.Operation, new DateTime(1, 1, 1, 16, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");
            ScheduleTimeSlot scheduleTimeSlot40 = new ScheduleTimeSlot(AppointmentType.Consultation, new DateTime(1, 1, 1, 17, 0, 0), 45, DayOfWeek.Friday, "Dr. Smith");

            var scheduleTimeSlots = new ScheduleTimeSlot[]
            {
                scheduleTimeSlot1, scheduleTimeSlot2, scheduleTimeSlot3, scheduleTimeSlot4, scheduleTimeSlot5, scheduleTimeSlot6, scheduleTimeSlot7, 
                scheduleTimeSlot8, scheduleTimeSlot9, scheduleTimeSlot10, scheduleTimeSlot11, scheduleTimeSlot12, scheduleTimeSlot13, scheduleTimeSlot14, 
                scheduleTimeSlot15, scheduleTimeSlot16, scheduleTimeSlot17, scheduleTimeSlot18, scheduleTimeSlot19, scheduleTimeSlot20, scheduleTimeSlot21,
                scheduleTimeSlot22, scheduleTimeSlot23, scheduleTimeSlot24, scheduleTimeSlot25, scheduleTimeSlot26, scheduleTimeSlot27, scheduleTimeSlot28,
                scheduleTimeSlot29, scheduleTimeSlot30, scheduleTimeSlot31, scheduleTimeSlot32, scheduleTimeSlot33, scheduleTimeSlot34, scheduleTimeSlot35,
                scheduleTimeSlot36, scheduleTimeSlot37, scheduleTimeSlot38, scheduleTimeSlot39, scheduleTimeSlot40,
            };
            #endregion

            #region TimeSlots
            string nameDoctor = "Dr. Smith";

            TimeSlot timeSlot1 = new TimeSlot(AppointmentType.Consultation, new DateTime(2023, 12, 23, 8, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot2 = new TimeSlot(AppointmentType.Operation, new DateTime(2023, 12, 23, 9, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot3 = new TimeSlot(AppointmentType.Consultation, new DateTime(2023, 12, 23, 10, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot4 = new TimeSlot(AppointmentType.Operation, new DateTime(2023, 12, 23, 11, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot5 = new TimeSlot(AppointmentType.Consultation, new DateTime(2023, 12, 23, 12, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot6 = new TimeSlot(AppointmentType.Operation, new DateTime(2023, 12, 23, 13, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot7 = new TimeSlot(AppointmentType.Consultation, new DateTime(2023, 12, 23, 14, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot8 = new TimeSlot(AppointmentType.Operation, new DateTime(2023, 12, 23, 15, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot9 = new TimeSlot(AppointmentType.Consultation, new DateTime(2023, 12, 23, 16, 0, 0), 45, nameDoctor);
            TimeSlot timeSlot10 = new TimeSlot(AppointmentType.Operation, new DateTime(2023, 12, 23, 17, 0, 0), 45, nameDoctor);

            var timeSlots = new TimeSlot[]
            {
                timeSlot1, timeSlot2, timeSlot3, timeSlot4, timeSlot5, timeSlot6, timeSlot7, timeSlot8, timeSlot9, timeSlot10,
            };
            #endregion

            #region Appointments
            Appointment appointment1 = new Appointment(patient1, new DateTime(2023, 12, 23, 8, 0, 0), "Reason: Normal Consultation", "");
            Appointment appointment2 = new Appointment(patient1, new DateTime(2023, 12, 23, 9, 0, 0), "Reason: Normal Operation", "Ik heb last van hangende oogleden en wil graag een ooglidcorrectie laten uitvoeren.");

            var appointments = new Appointment[]
            {
                appointment1, appointment2,
            };
            #endregion

            // CMS
            #region Header
            var header = new CMSHomeHeader
            {
                Id = 0,
                Title = "Vision Oogcentrum Gent",
                Context = "Van harte welkom bij Vision Oogcenter Gent, waar we met liefde en zorg voor uw ogen zorgen. Onze toegewijde oogartsen zijn hier om uw visuele behoeften te vervullen en uw gezichtsvermogen te optimaliseren. Bij ons vindt u de perfecte combinatie van expertise, geavanceerde technologie en persoonlijke aandacht. Stap binnen in een wereld waar dromen van helder zicht werkelijkheid worden. We kijken ernaar uit u te verwelkomen en samen te werken aan een scherpere toekomst."

            };
            #endregion

            #region Location
            var location = new CMSLocation
            {
                Id = 0,
                Context = "Ergens in GENT, best via de E40 binnen rijden"

            };
            #endregion

            #region Contact
            var contact = new CMSContact
            {
                Id = 0,
                Context = "wij zijn mensen en geen ALiens ookal zijn we oogartsen"

            };
            #endregion

            #region Treatments
            var treatments = new CMSTreatment[]
            {
                new CMSTreatment
                {
                    Id = 0,
                    Name = "Ooglidcorrectie",
                    Description = "Een ooglidcorrectie, ook wel bekend als blepharoplastie, is een verfijnde cosmetische chirurgische procedure die tot doel heeft de jeugdige uitstraling van de ogen te herstellen en functionele problemen in verband met verslapte oogleden te verhelpen. Met het natuurlijke verouderingsproces of genetische factoren kunnen oogleden na verloop van tijd gaan hangen, wat kan resulteren in vermoeidheid, verminderd gezichtsvermogen en een verouderde uitstraling.\n\nBij een ooglidcorrectie verwijdert onze ervaren oogarts zorgvuldig overtollig huid- en vetweefsel rond de ogen. Hierdoor wordt niet alleen de esthetische aantrekkingskracht hersteld, maar ook eventuele gezondheidsproblemen zoals beperkt gezichtsvermogen als gevolg van hangende oogleden kunnen worden verlicht. Onze patiënten ervaren doorgaans minimale ongemakken en een snel herstel, met blijvende resultaten die de jeugdige uitstraling van de ogen herstellen en hun algehele zelfvertrouwen vergroten.\n\nEen ooglidcorrectie kan een levensveranderende ingreep zijn, waardoor patiënten weer kunnen stralen en zich zelfverzekerd voelen. Neem vandaag nog contact met ons op voor een consult om te ontdekken hoe deze procedure u kan helpen de jeugdige, levendige oogopslag te herstellen die u verdient.",
                    ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/b020388d-71c6-4908-ac78-4cb18403604c-ooglidcorrectie.png"
                },

                new CMSTreatment
                {
                    Id = 1,
                    Name = "Cataractoperatie",
                    Description = "Een cataractoperatie is een veilige en effectieve ingreep die wordt uitgevoerd om cataract, ook wel staar genoemd, te behandelen. Cataract is een veelvoorkomende oogaandoening die optreedt wanneer de natuurlijke ooglens troebel wordt, waardoor het zicht wazig en troebel wordt. Deze vertroebeling kan het dagelijks leven aanzienlijk beïnvloeden, maar met een cataractoperatie kunnen we uw helderheid en kwaliteit van zien herstellen.\n\nTijdens de procedure verwijdert onze bekwame oogarts de troebele ooglens en vervangt deze door een heldere, kunstmatige lens, die bekend staat als een intraoculaire lens (IOL). Deze IOL herstelt uw gezichtsvermogen en stelt u in staat weer scherp en duidelijk te zien. De cataractoperatie is meestal een poliklinische ingreep en wordt uitgevoerd onder lokale verdoving. Patiënten ervaren doorgaans weinig tot geen pijn en kunnen snel terugkeren naar hun dagelijkse activiteiten.\n\nHet herstellen van helder zicht na een cataractoperatie kan een levensveranderende ervaring zijn, waardoor patiënten weer volop van het leven kunnen genieten. Als u symptomen van cataract ervaart, zoals wazig zicht, verblindheid door licht of problemen met nachtzicht, aarzel dan niet om contact met ons op te nemen voor een consult. Onze deskundige oogartsen staan klaar om u te helpen uw gezichtsvermogen te herstellen en uw kwaliteit van leven te verbeteren.",
                    ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/bff02029-b469-4b50-a468-390035e1fa64-cataractoperatie.png"
                },

                new CMSTreatment
                {
                    Id = 2,
                    Name = "Straaloperatie",
                    Description = "De straaloperatie, ook bekend als lasercorrectie van oogafwijkingen, is een geavanceerde en niet-invasieve procedure die tot doel heeft om de afhankelijkheid van bril of contactlenzen te verminderen of zelfs te elimineren. Deze revolutionaire techniek heeft miljoenen mensen geholpen om scherp en helder zicht te bereiken zonder de belemmeringen van correctieve lenzen.\n\nTijdens een straaloperatie gebruiken onze ervaren oogchirurgen geavanceerde laserapparatuur om microscopisch kleine aanpassingen aan het hoornvlies van het oog aan te brengen. Deze aanpassingen kunnen bijziendheid, verziendheid, astigmatisme en andere oogafwijkingen corrigeren, waardoor het licht op de juiste manier op het netvlies wordt gefocust. De procedure is meestal snel, vrijwel pijnloos en vereist minimaal hersteltijd.\n\nDe voordelen van een straaloperatie zijn talrijk en omvatten een verbeterde kwaliteit van leven, meer vrijheid in uw dagelijkse activiteiten en het verminderen of elimineren van de kosten en het ongemak van brillen of contactlenzen. Veel patiënten ervaren na de ingreep een significante verbetering van hun zicht, waardoor ze scherp en helder kunnen zien zonder enige visuele hulpmiddelen.\n\nAls u geïnteresseerd bent in een straaloperatie om uw zicht te corrigeren, aarzel dan niet om contact met ons op te nemen voor een consult. Onze toegewijde oogartsen staan klaar om uw specifieke behoeften te beoordelen en u te begeleiden naar de best mogelijke oplossing voor uw oogafwijkingen. Ervaar de vrijheid van helder zicht met een straaloperatie en ontdek hoe het uw leven kan veranderen.",
                    ImageLink = "https://blitzware-files.s3.eu-central-1.amazonaws.com/3a88b810-0585-458a-9196-73a0fe215b90-straaloperatie.png"
                },
            };
            #endregion

            #region Blogs
            var blogs = new CMSBlog[]
            {
                new CMSBlog
                {
                    Id = 0,
                    Title = "Laseroperatie voor bijziendheid: de voor- en nadelen",
                    Text = "Bijziendheid is een veel voorkomende oogafwijking. Het is een "+
                    "refractieafwijking, wat betekent dat het oog niet in staat is om lichtstralen op de juiste manier te breken. Hierdoor ontstaat een wazig beeld. Bijziendheid kan worden gecorrigeerd met een bril of contactlenzen, "+
                    "maar ook met een laseroperatie. In dit artikel lees je meer over de voor- en nadelen van een laseroperatie voor bijziendheid.",
                    ImageLink = "https://img.noordhollandsdagblad.nl/0C2g51q-JZ9mGU4zOu75QV09s_I=/731x411/smart/https://cdn-kiosk-api.telegraaf.nl/6e4b1200-ac99-11e7-9e19-111553951722.jpg"
                },

               new CMSBlog
                {
                    Id = 0,
                    Title = "Vision oogcenter ",
                    Text = "Een nieuwe oogarts in het Vision Oogcentrum Gent: Dr. J. Van der Veken. "+
                    "Dr. J. Van der Veken is een oogarts met een bijzondere interesse in de behandeling van glaucoom en cataract. "+
                    "Hij is een ervaren cataractchirurg en voert ook laserbehandelingen uit voor glaucoom. "+
                    "Daarnaast is hij ook gespecialiseerd in de behandeling van droge ogen. ",
                    ImageLink = "https://images.healthshots.com/healthshots/en/uploads/2022/07/02195043/doctor-stress.jpg"
                }

            };
            #endregion

            #region ChatBotQuestions
            var chatbotQuestions = new CMSChatBotQuestion[]
            {
                new CMSChatBotQuestion
                {
                    Id = 0,
                    Question = "Hoeveel kost een behandeling?",
                    Answer = "In welke behandeling bent u geïnteresseerd?",
                    FollowUpQuestions = new List<CMSChatBotQuestion>
                    {
                        new CMSChatBotQuestion
                        {
                            Id = 1,
                            IsFollowUp = true,
                            Question = "Ooglidcorrectie",
                            Answer = "Over welk soort ooglidcorrectie gaat het?",
                            FollowUpQuestions = new List<CMSChatBotQuestion>
                            {
                                new CMSChatBotQuestion
                                {
                                    Id = 2,
                                    IsFollowUp = true,
                                    Question = "Bovenooglidcorrectie",
                                    Answer = "Een bovenooglidcorrectie kost 1250 euro.",
                                },
                                new CMSChatBotQuestion
                                {
                                    Id = 3,
                                    IsFollowUp = true,
                                    Question = "Onderooglidcorrectie",
                                    Answer = "Een onderooglidcorrectie kost 1000 euro.",
                                },
                            }
                        },
                        new CMSChatBotQuestion
                        {
                            Id = 4,
                            IsFollowUp = true,
                            Question = "Cataractoperatie",
                            Answer = "Een cataractoperatie kost tussen de 800 en 1500 euro.",
                        },
                        new CMSChatBotQuestion
                        {
                            Id = 5,
                            IsFollowUp = true,
                            Question = "Straaloperatie",
                            Answer = "Een straaloperatie kost tussen de 1250 en 2000 euro.",
                        },
                    }
                },
                new CMSChatBotQuestion
                {
                    Id = 6,
                    Question = "Waar is de vestiging gelegen?",
                    Answer = "Onze vestiging is gelegen in 9040 Gent, op de Antwerpsesteenweg 1022.",
                },
                new CMSChatBotQuestion
                {
                    Id = 7,
                    Question = "Hoe maak ik een afspraak?",
                    Answer = "Rechtsbovenaan de pagina kan u op de knop 'Maak een afspraak' klikken. U wordt dan doorverwezen naar een pagina waar u een afspraak kan maken.",
                },
            };
            #endregion

            // domain
            context.Doctors.AddRange(doctors);
            context.ScheduleTimeSlots.AddRange(scheduleTimeSlots);
            context.Patients.AddRange(patients);
            context.TimeSlots.AddRange(timeSlots);
            context.Appointments.AddRange(appointments);

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