using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class TreatmentService
    {
        private readonly DatabaseContext _ctx;

        public TreatmentService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Treatment>> GetContent()
        {
            return await _ctx.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetContentByName(string name)
        {
            var treatment =  await _ctx.Treatments.FirstOrDefaultAsync(t => t.Name == name);

            if (treatment is null)
            {
                throw new InvalidOperationException($"does not exist with name '{name}'");
            }

            return treatment;
        }

        public async Task UpdateTreatment(int id, string newName, string newDescription, string newImage)
        {
            var treatmentToUpdate = await _ctx.Treatments.FindAsync(id);

            if (treatmentToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }

            if (newName != null && newDescription != null && newImage != null)
            {
                treatmentToUpdate.Name = newName;
                treatmentToUpdate.Description = newDescription;
                treatmentToUpdate.Image = newImage;
            }
            else
            {
                throw new InvalidOperationException("updating content is null");
            }

            await _ctx.SaveChangesAsync();
        }
    }
}