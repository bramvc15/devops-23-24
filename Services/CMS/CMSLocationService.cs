using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Services.CMS
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
            CMSLocation loc = await _locations.FindAsync(newLocation.Id);
            loc.Context = newLocation.Context != null ? newLocation.Context : loc.Context;
            _locations.Update(loc);
            await _ctx.SaveChangesAsync();

            return newLocation;
        }
    }
}