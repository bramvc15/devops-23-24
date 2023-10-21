using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class HomeHeaderService
    {

        private readonly DatabaseContext _ctx;

        public HomeHeaderService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<HomeHeader> GetContent()
        {
            return _ctx.HomeHeaders.ToList();
        }

        // public async Task<IEnumerable<HomeHeader>> GetContentAsync()
        // {
        //     return await _ctx.HomeHeaders.ToListAsync();
        // }

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

        public void UpdateHeaderTitle(string newTitle)
        {
            var headerToUpdate = _ctx.HomeHeaders.Find(1);


            if (headerToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }

            headerToUpdate.Title = newTitle;
            _ctx.SaveChanges();
        }

//         public void UpdateHeaderTitle(HomeHeader header)
// {
//     var headerToUpdate = _ctx.HomeHeaders.FirstOrDefault(); // You might want to adjust this logic.

//     if (headerToUpdate is null)
//     {
//         throw new InvalidOperationException("Header does not exist");
//     }

//     if (!string.IsNullOrEmpty(header.Title))
//     {
//         headerToUpdate.Title = header.Title;
//     }

//     if (!string.IsNullOrEmpty(header.Context))
//     {
//         headerToUpdate.Context = header.Context;
//     }

//     _ctx.SaveChanges();
// }

    }

}