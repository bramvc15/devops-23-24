using BlazorApp.Data;
using BlazorApp.Models;
using BlazorApp.Pages;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Services
{

    public class HomeHeaderService
    {

        private readonly DatabaseContext _ctx;

        public HomeHeaderService(DatabaseContext ctx){
            _ctx = ctx;
        }

        public IEnumerable<HomeHeader> GetContent()
        {
           return _ctx.HomeHeaders.ToList();
        }

        public JsonResult PutContent()
        {
            throw new NotImplementedException();
        }
    }

}