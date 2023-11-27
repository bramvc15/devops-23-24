using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class LocationService
    {

        private readonly DatabaseContext _ctx;

        public LocationService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<LocationM>> GetContent()
        {
            return await _ctx.Locations.ToListAsync();
        }


        public async Task UpdateLocationText( string content)
        {
            var locationToUpdate = await _ctx.Locations.FindAsync(1);


            if (locationToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }
            if(content != null){
       
                locationToUpdate.Context = content;
            }

            await _ctx.SaveChangesAsync();
        }

    }

}