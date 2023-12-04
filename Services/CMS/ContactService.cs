using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;

namespace Services.CMS
{
    public class ContactService
    {
        private readonly DatabaseContext _ctx;

        public ContactService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _contacts = ctx.Contacts;
        }

        private readonly DbSet<Contact> _contacts;

        public async Task<ContactDTO> GetContact()
        {
            var contact = await _contacts.FirstOrDefaultAsync();

            ContactDTO contactDTO = new()
            {
                Id = contact.Id,
                Context = contact.Context
            };

            return contactDTO;
        }

        public async Task<ContactDTO> UpdateContact(ContactDTO updatedContact)
        {
            Contact con = await _contacts.FindAsync(updatedContact.Id);
            con.UpdateContact(con.Context);
            _contacts.Update(con);
            await _ctx.SaveChangesAsync();

            return updatedContact;
        }
    }
}