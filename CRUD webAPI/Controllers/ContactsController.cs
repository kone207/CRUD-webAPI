using CRUD_webAPI.Data;
using CRUD_webAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactAPIdbContext dbContext;

        public ContactsController(ContactAPIdbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }                    
            
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactsRequest addContactsRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactsRequest.Address,
                Email = addContactsRequest.Email,
                PhoneNo = addContactsRequest.PhoneNo,
                FullName = addContactsRequest.FullName
            };
            
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id, UpdateContactsRequest updateContactsRequest)
        {
            var contact = dbContext.Contacts.Find(id);

            if (contact != null)
            {
                contact.Email = updateContactsRequest.Email;
                contact.PhoneNo = updateContactsRequest.PhoneNo;    
                contact.FullName = updateContactsRequest.FullName;
                contact.Address = updateContactsRequest.Address;

                dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContacts([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
