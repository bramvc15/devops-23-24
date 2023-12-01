using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared.CMS;

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

        private readonly DbSet<CMSHomeHeader> _homeHeaders;

        public async Task<CMSHomeHeader> GetHomeHeader()
        {
            return await _homeHeaders.FirstOrDefaultAsync();
        }

        public async Task<CMSHomeHeader> UpdateHomeHeader(CMSHomeHeader homeHeader)
        {
            CMSHomeHeader header = await _homeHeaders.FindAsync(homeHeader.Id);
            header.Title = homeHeader.Title != null ? homeHeader.Title : header.Title;
            header.Context = homeHeader.Context != null ? homeHeader.Context : header.Context;
            _homeHeaders.Update(header);
            await _ctx.SaveChangesAsync();

            return header; 
        }
    }
}