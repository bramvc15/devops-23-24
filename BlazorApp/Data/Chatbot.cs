using System.Collections.Generic;

public class FAQItem
{
    public int id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}

public class FAQData
{
    public static List<FAQItem> GetFAQs()
    {
        return new List<FAQItem>
        {
            new FAQItem
            {
                id = 1,
                Question = "Hoe plan ik een afspraak?",
                Answer = "In de rechterbovenhoek van de website kan je op de knop 'Maak een afspraak' klikken. Daarna kan je een datum en tijdslot kiezen voor je afspraak."
            },
            new FAQItem
            {
                id = 2,
                Question = "Wat is het adres van jullie vestiging?",
                Answer = "Onze vestiging is gelegen op de Antwerpsesteenweg 1022, 9040 Gent."
            },
            new FAQItem
            {
                id = 3,
                Question = "Wat zijn de openingsuren?",
                Answer = "Wij zijn open van maandag tot vrijdag van 9u tot 18u."
            },
        };
    }
}
