using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace BlazorApp.Services.CMS
{
    public class CMSLocationService
    {
        private readonly DatabaseContext _ctx;

        public CMSLocationService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _locations = ctx.Locations;
        }

        private readonly DbSet<CMSLocation> _locations;

        public async Task<CMSLocation> GetLocation()
        {
            return await _locations.FirstOrDefaultAsync();
        }

        public async Task<CMSLocation> UpdateLocation(CMSLocation newLocation)
        {
            _locations.Update(newLocation);
            await _ctx.SaveChangesAsync();

            return newLocation;
        }
    }
}