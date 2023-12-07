using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;

namespace Services.CMS
{
    public class HomeHeaderService
    {
        private readonly DatabaseContext _ctx;

        public HomeHeaderService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _homeHeaders = ctx.HomeHeaders;
        }

        private readonly DbSet<HomeHeader> _homeHeaders;

        public async Task<HomeHeaderDTO> GetHomeHeader()
        {
            var homeHeader = await _homeHeaders.FirstOrDefaultAsync();

            HomeHeaderDTO homeHeaderDTO = new()
            {
                Id = homeHeader.Id,
                Title = homeHeader.Title,
                Context = homeHeader.Context,
            };

            return homeHeaderDTO;
        }

        public async Task<HomeHeaderDTO> UpdateHomeHeader(HomeHeaderDTO updatedHomeHeader)
        {
            HomeHeader homeHeader = await _homeHeaders.FindAsync(updatedHomeHeader.Id);
            homeHeader.UpdateHomeHeader(updatedHomeHeader.Title, updatedHomeHeader.Context);
            _homeHeaders.Update(homeHeader);
            await _ctx.SaveChangesAsync();

            return updatedHomeHeader;
        }
    }
}