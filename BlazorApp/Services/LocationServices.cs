using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class LocationService
    {

        private readonly DatabaseContext _ctx;

        public LocationService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<LocationM> GetContent()
        {
            return _ctx.Locations.ToList();
        }


        public void UpdateLocationText( string content)
        {
            var locationToUpdate = _ctx.Locations.Find(1);


            if (locationToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }
            if(content != null){
       
                locationToUpdate.Context = content;
            }

            _ctx.SaveChanges();
        }

    }

}