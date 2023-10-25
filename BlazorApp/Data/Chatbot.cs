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
                Answer = "Enim quis magna occaecat consequat elit anim eu aliqua fugiat."
            },
            new FAQItem
            {
                id = 2,
                Question = "Wat is het adres van jullie vestiging?",
                Answer = "Enim ad reprehenderit reprehenderit reprehenderit aute pariatur reprehenderit cupidatat voluptate labore culpa."
            },
            new FAQItem
            {
                id = 3,
                Question = "Wat zijn de openingsuren?",
                Answer = "Nulla occaecat ad exercitation reprehenderit."
            },
        };
    }
}
