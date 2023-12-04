using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services.CMS
{
    public class TreatmentService
    {
        private readonly DatabaseContext _ctx;

        public TreatmentService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _treatments = ctx.Treatments;
        }

        private readonly DbSet<Treatment> _treatments;

        public async Task<IEnumerable<TreatmentDTO>> GetTreatments()
        {
            return (IEnumerable<TreatmentDTO>)await _treatments.ToListAsync();
        }

        public async Task<TreatmentDTO> CreateTreatment(TreatmentDTO newTreatment)
        {
            _treatments.Add(new Treatment(newTreatment.Name, newTreatment.Description, newTreatment.ImageLink));
            await _ctx.SaveChangesAsync();

            return newTreatment;
        }

        public async Task<TreatmentDTO> UpdateTreatment(TreatmentDTO updatedTreatment)
        {
            Treatment treatment = await _treatments.FindAsync(updatedTreatment.Id);
            treatment.UpdateTreatment(updatedTreatment.Name, updatedTreatment.Description, updatedTreatment.ImageLink);
            _treatments.Update(treatment);
            await _ctx.SaveChangesAsync();

            return updatedTreatment;
        }

        public async Task DeleteTreatment(TreatmentDTO treatmentToDelete)
        {
            Treatment treatment = await _treatments.FindAsync(treatmentToDelete.Id);
            _treatments.Remove(treatment);
            await _ctx.SaveChangesAsync();
        }
    }
}