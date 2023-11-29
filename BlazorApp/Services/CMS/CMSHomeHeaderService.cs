using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace BlazorApp.Services.CMS
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
            _homeHeaders.Update(homeHeader);
            await _ctx.SaveChangesAsync();

            return homeHeader; 
        }
    }
}