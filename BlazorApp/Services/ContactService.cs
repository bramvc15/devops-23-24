using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class ContactService
    {

        private readonly DatabaseContext _ctx;

        public ContactService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ContactM> GetContent()
        {
            return _ctx.Contacts.ToList();
        }


        public void UpdateContactText( string content)
        {
            var contactToUpdate = _ctx.Contacts.Find(1);


            if (contactToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }
            if(content != null){
       
                contactToUpdate.Context = content;
            }

            _ctx.SaveChanges();
        }

    }

}