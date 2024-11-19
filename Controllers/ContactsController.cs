using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDBContext dbContext;

        public ContactsController(ContactlyDBContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [HttpGet]
        public IActionResult getAllContacts()
        {
            var contacts=dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var domainModelContact = new Contacts
            {
              
                ContactName = request.ContactName,
                Phone = request.Phone,
                Email = request.Email,
                Favorite = request.Favorite


            };
            dbContext.Contacts.Add(domainModelContact);
            dbContext.SaveChanges();
            return Ok(domainModelContact);

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateContact(int id, UpdateContactRequestDTO request)
        {
            var contact = dbContext.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            // Update the fields
            contact.ContactName = request.ContactName;
            contact.Phone = request.Phone;
            contact.Email = request.Email;
            contact.Favorite = request.Favorite;

            dbContext.SaveChanges();

            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = dbContext.Contacts.Find(id);
            if(contact is not null) { 
            dbContext.Contacts.Remove(contact);
            dbContext.SaveChanges();
            }
            return Ok();
        }


    }
}
