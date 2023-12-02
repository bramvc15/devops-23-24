using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;

namespace Services.CMS
{
    public class CMSTreatmentService
    {
        private readonly DatabaseContext _ctx;

        public CMSTreatmentService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _treatments = ctx.Treatments;
        }

        private readonly DbSet<TreatmentDTO> _treatments;

        public async Task<IEnumerable<TreatmentDTO>> GetTreatments()
        {
            return await _treatments.ToListAsync();
        }

        public async Task<TreatmentDTO> CreateTreatment(TreatmentDTO newTreatment)
        {
            _treatments.Add(newTreatment);
            await _ctx.SaveChangesAsync();

            return newTreatment;
        }

        public async Task<TreatmentDTO> UpdateTreatment(TreatmentDTO updatedTreatment)
        {
            TreatmentDTO treatment = await _treatments.FindAsync(updatedTreatment.Id);
            treatment.Name = updatedTreatment.Name != null ? updatedTreatment.Name : treatment.Name;
            treatment.Description = updatedTreatment.Description != null ? updatedTreatment.Description : treatment.Description;
            treatment.ImageLink = updatedTreatment.ImageLink != null ? updatedTreatment.ImageLink : treatment.ImageLink;
            _treatments.Update(treatment);
            await _ctx.SaveChangesAsync();

            return updatedTreatment;
        }

        public async Task DeleteTreatment(TreatmentDTO treatmentToDelete)
        {
            _treatments.Remove(treatmentToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}