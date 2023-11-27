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

        public async Task<IEnumerable<ContactM>> GetContent()
        {
            return await _ctx.Contacts.ToListAsync();
        }

        public async Task UpdateContactText( string content)
        {
            var contactToUpdate = await _ctx.Contacts.FindAsync(1);

            if (contactToUpdate is null)
            {
                throw new InvalidOperationException("does not exist");
            }
            if(content != null){
       
                contactToUpdate.Context = content;
            }

            await _ctx.SaveChangesAsync();
        }

    }

}