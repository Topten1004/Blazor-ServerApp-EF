using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Data
{
    public class ContactService
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public ContactService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Contacts
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _appDBContext.Contacts.ToListAsync();
        }
        #endregion

        #region Insert Contact
        public async Task<bool> InsertContactAsync(Contact contact)
        {
            await _appDBContext.Contacts.AddAsync(contact);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Contact by Id
        public async Task<Contact> GetContactAsync(string Id)
        {
            Contact contact = await _appDBContext.Contacts.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return contact;
        }
        #endregion

        #region Update Contact
        public async Task<bool> UpdateContactAsync(Contact contact)
        {
             _appDBContext.Contacts.Update(contact);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteContact
        public async Task<bool> DeleteContactAsync(Contact contact)
        {
            _appDBContext.Remove(contact);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
