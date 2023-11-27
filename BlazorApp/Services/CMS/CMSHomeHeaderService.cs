using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services.CMS
{
    public class CMSHomeHeaderService
    {
        private readonly DatabaseContext _ctx;

        public CMSHomeHeaderService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<HomeHeader>> GetContent()
        {
            return await _ctx.HomeHeaders.ToListAsync();
        }

        public async Task UpdateHeaderTitleAsync(int headerId, string newTitle)
        {
            var headerToUpdate = await _ctx.HomeHeaders.FindAsync(headerId);

            if (headerToUpdate is null)
            {
                throw new InvalidOperationException("Header does not exist");
            }

            headerToUpdate.Title = newTitle;
            await _ctx.SaveChangesAsync();
        }

        public void UpdateHeaderTitle(string newTitle, string content)
        {
            var headerToUpdate = _ctx.HomeHeaders.Find(1);

            if (headerToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }
            if (newTitle != null && content != null)
            {
                headerToUpdate.Title = newTitle;
                headerToUpdate.Context = content;
            }

            if (newTitle == null && content != null)
            {
                headerToUpdate.Context = content;
            }

            if (content == null && newTitle != null)
            {
                headerToUpdate.Title = newTitle;
            }

            // headerToUpdate.Title = newTitle;
            _ctx.SaveChanges();
        }
    }
}