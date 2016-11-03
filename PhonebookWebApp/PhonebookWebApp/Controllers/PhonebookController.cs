using Phonebook.Core;
using Phonebook.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhonebookWebApp.Controllers
{
    public class PhonebookController : Controller
    {
        CommandInvoker invoker = new CommandInvoker();
        // GET: Phonebook
        public ActionResult Index(int? id)
        {
            List<Contact> contacts;
            if (id == null || id == -2)
                contacts = invoker.GetAllContacts();

            else
            {
                if (id > -1)
                {
                    contacts = new List<Contact>();
                    contacts.Add(invoker.GetContact(id.Value));
                }
                    
                else
                    contacts = null;
            }
               

            return View(contacts);
        }
        
        //public ActionResult GetConatct(int id)
        //{
        //    var contact = invoker.GetContact(id);

        //    return View(contact);
        //}

        [HttpGet]
        public ActionResult Change(int id)
        {
            var contact = invoker.GetContact(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult Change(Contact contact)
        {
            invoker.Change(contact);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            invoker.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            invoker.Add(contact);

            return RedirectToAction("Index");
        }

        public ActionResult Search(string name)
        {
            var contact =invoker.Search(name);
            int id = -1;

            if(contact != null)
                id = contact.Id;

            return RedirectToAction("Index", new { id = id });
        }
    }
}