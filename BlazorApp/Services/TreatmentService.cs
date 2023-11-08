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

        public IEnumerable<Treatment> GetContent()
        {
            return _ctx.Treatments.ToList();
        }

        public Treatment GetContentByName(string name)
        {
            var treatment =  _ctx.Treatments.FirstOrDefault(t => t.Name == name);

            if (treatment is null)
            {
                throw new InvalidOperationException($"does not exist with name '{name}'");
            }

            return treatment;
        }


        public void UpdateTreatment(int id, string newName, string newDescription, string newImage)
        {
            var treatmentToUpdate = _ctx.Treatments.Find(id);


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

            _ctx.SaveChanges();
        }

    }

}