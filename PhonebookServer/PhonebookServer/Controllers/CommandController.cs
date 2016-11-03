using PhonebookServer.Implementations;
using PhonebookServer.Interfaces;
using PhonebookServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhonebookServer.Controllers
{
    public class CommandController : ApiController
    {
        IRepository<Contact> db;

        public CommandController()
        {
            db = new SQLPhonebookRepository();
        }

        [HttpPost]
        public void Add(Contact contact)
        {
            db.Create(contact);
            db.Save();

            Console.WriteLine("Contact"+ contact.ToString() + "added");
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var contact = db.Get(id);

            db.Delete(id);
            db.Save();
            
            Console.WriteLine("Contact" + contact.ToString() + "deleted");
        }

        [HttpPost]
        public void Change(Contact contact)
        {
            var contactForChange = db.Get(contact.Id);
            var contactForShow = contactForChange;

            contactForChange.Name = contact.Name;
            contactForChange.PhoneNumber = contact.PhoneNumber;

            db.Update(contactForChange);
            db.Save();

            Console.WriteLine("Contact" + contactForShow.ToString() + "changed to" + contact.ToString());
        }

        [HttpGet]
        public Contact Search(string name)
        {
            var contact = db.GetList().FirstOrDefault(c => c.Name.ToUpper() == name.ToUpper());

            if(contact !=null)
                Console.WriteLine("Search for" + contact.ToString());
            else
                Console.WriteLine("No contact with name" + name);

            return contact;
        }

        [HttpGet]
        public Contact Get(int id)
        {
            var contact = db.Get(id);

            return contact;
        }
        
        [HttpGet]
        public List<Contact> GetAllContacts()
        {
            Console.WriteLine("Send all contacts");

            return db.GetList().ToList();
        }

            

    }
}
