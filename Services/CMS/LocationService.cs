using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;

namespace Services.CMS
{
    public class LocationService
    {
        private readonly DatabaseContext _ctx;

        public LocationService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _locations = ctx.Locations;
        }

        private readonly DbSet<Location> _locations;

        public async Task<LocationDTO> GetLocation()
        {
            var location = await _locations.FirstOrDefaultAsync();

            LocationDTO locationDTO = new()
            {
                Id = location.Id,
                Context = location.Context
            };

            return locationDTO;
        }

        public async Task<LocationDTO> UpdateLocation(LocationDTO updatedLocation)
        {
            Location loc = await _locations.FindAsync(updatedLocation.Id);
            loc.UpdateLocation(loc.Context);
            _locations.Update(loc);
            await _ctx.SaveChangesAsync();

            return updatedLocation;
        }
    }
}