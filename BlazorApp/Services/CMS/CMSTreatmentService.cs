using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace BlazorApp.Services.CMS
{
    public class CMSTreatmentService
    {
        private readonly DatabaseContext _ctx;

        public CMSTreatmentService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _treatments = ctx.Treatments;
        }

        private readonly DbSet<CMSTreatment> _treatments;

        public async Task<IEnumerable<CMSTreatment>> GetTreatments()
        {
            return await _treatments.ToListAsync();
        }

        public async Task<CMSTreatment> CreateTreatment(CMSTreatment newTreatment)
        {
            _treatments.Add(newTreatment);
            await _ctx.SaveChangesAsync();

            return newTreatment;
        }

        public async Task<CMSTreatment> UpdateTreatment(CMSTreatment updatedTreatment)
        {
            CMSTreatment treatment = await _treatments.FindAsync(updatedTreatment.Id);
            treatment.Name = updatedTreatment.Name != null ? updatedTreatment.Name : treatment.Name;
            treatment.Description = updatedTreatment.Description != null ? updatedTreatment.Description : treatment.Description;
            treatment.ImageLink = updatedTreatment.ImageLink != null ? updatedTreatment.ImageLink : treatment.ImageLink;
            _treatments.Update(treatment);
            await _ctx.SaveChangesAsync();

            return updatedTreatment;
        }

        public async Task DeleteTreatment(CMSTreatment treatmentToDelete)
        {
            _treatments.Remove(treatmentToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}