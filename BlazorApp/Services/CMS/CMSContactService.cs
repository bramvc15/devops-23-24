using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace BlazorApp.Services.CMS
{
    public class CMSContactService
    {
        private readonly DatabaseContext _ctx;

        public CMSContactService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _contacts = ctx.Contacts;
        }

        private readonly DbSet<CMSContact> _contacts;

        public async Task<CMSContact> GetContact()
        {
            return await _contacts.FirstOrDefaultAsync();
        }

        public async Task<CMSContact> UpdateContact(CMSContact newCMS)
        {
            CMSContact con = await _contacts.FindAsync(newCMS.Id);
            con.Context = newCMS.Context != null ? newCMS.Context : con.Context;
            _contacts.Update(newCMS);
            await _ctx.SaveChangesAsync();

            return newCMS;
        }
    }
}