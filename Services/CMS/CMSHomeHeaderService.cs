using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;

namespace Services.CMS
{
    public class CMSHomeHeaderService
    {
        private readonly DatabaseContext _ctx;

        public CMSHomeHeaderService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _homeHeaders = ctx.HomeHeaders;
        }

        private readonly DbSet<HomeHeaderDTO> _homeHeaders;

        public async Task<HomeHeaderDTO> GetHomeHeader()
        {
            return await _homeHeaders.FirstOrDefaultAsync();
        }

        public async Task<HomeHeaderDTO> UpdateHomeHeader(HomeHeaderDTO homeHeader)
        {
            HomeHeaderDTO header = await _homeHeaders.FindAsync(homeHeader.Id);
            header.Title = homeHeader.Title != null ? homeHeader.Title : header.Title;
            header.Context = homeHeader.Context != null ? homeHeader.Context : header.Context;
            _homeHeaders.Update(header);
            await _ctx.SaveChangesAsync();

            return header; 
        }
    }
}