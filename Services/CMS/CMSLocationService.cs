using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;

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

        private readonly DbSet<LocationDTO> _locations;

        public async Task<LocationDTO> GetLocation()
        {
            return await _locations.FirstOrDefaultAsync();
        }

        public async Task<LocationDTO> UpdateLocation(LocationDTO newLocation)
        {
            LocationDTO loc = await _locations.FindAsync(newLocation.Id);
            loc.Context = newLocation.Context != null ? newLocation.Context : loc.Context;
            _locations.Update(loc);
            await _ctx.SaveChangesAsync();

            return newLocation;
        }
    }
}