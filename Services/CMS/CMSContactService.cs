using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;

namespace Services.CMS
{
    public class CMSContactService
    {
        private readonly DatabaseContext _ctx;

        public CMSContactService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _contacts = ctx.Contacts;
        }

        private readonly DbSet<ContactDTO> _contacts;

        public async Task<ContactDTO> GetContact()
        {
            return await _contacts.FirstOrDefaultAsync();
        }

        public async Task<ContactDTO> UpdateContact(ContactDTO newCMS)
        {
            ContactDTO con = await _contacts.FindAsync(newCMS.Id);
            con.Context = newCMS.Context != null ? newCMS.Context : con.Context;
            _contacts.Update(newCMS);
            await _ctx.SaveChangesAsync();

            return newCMS;
        }
    }
}