using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services.CMS
{
    public class FaqService
    {
        private readonly DatabaseContext _ctx;

        public FaqService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _faqs = ctx.Faqs;
        }

        private readonly DbSet<Faq> _faqs;

        public async Task<IEnumerable<FaqDTO>> GetFaqs()
        {
            List<Faq> faqs = await _faqs.ToListAsync();
            List<FaqDTO> convertedFaqs = new();

            foreach (var faq in faqs)
            {
                FaqDTO f = new()
                {
                    Id = faq.Id,
                    Question = faq.Question,
                    Answer = faq.Answer,
                };
                convertedFaqs.Add(f);
            }

            return convertedFaqs;
        }

        public async Task<FaqDTO> CreateFaq(FaqDTO newFaq)
        {
            _faqs.Add(new Faq(newFaq.Question, newFaq.Answer));
            await _ctx.SaveChangesAsync();

            return newFaq;
        }

        public async Task<FaqDTO> UpdateFaq(FaqDTO updatedFaq)
        {
            Faq faq = await _faqs.FindAsync(updatedFaq.Id);
            faq.UpdateFaq(updatedFaq.Question, updatedFaq.Answer);
            _faqs.Update(faq);
            await _ctx.SaveChangesAsync();

            return updatedFaq;
        }

        public async Task DeleteFaq(FaqDTO faqToDelete)
        {
            Faq faq = await _faqs.FindAsync(faqToDelete.Id);
            _faqs.Remove(faq);
            await _ctx.SaveChangesAsync();
        }
    }
}