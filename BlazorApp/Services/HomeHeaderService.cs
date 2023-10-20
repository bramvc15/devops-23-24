using BlazorApp.Data;
using BlazorApp.Models;

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

        public void UpdateHeaderTitle(int headerId, string newTitle)
        {
            var headerToUpdate = _ctx.HomeHeaders.Find(headerId);


            if (headerToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }

            headerToUpdate.Title = newTitle;
            _ctx.SaveChanges();
        }
    }

}