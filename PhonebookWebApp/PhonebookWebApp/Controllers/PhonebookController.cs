using Phonebook.Core;
using Phonebook.Core.Exceptions;
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
            List<Contact> contacts = null;

            try
            {
                if (id == null)
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
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
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
            Contact contact = null;

            try
            {
                contact = invoker.GetContact(id);
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
            }

            return View(contact);
        }

        [HttpPost]
        public ActionResult Change(Contact contact)
        {
            try
            {
                invoker.Change(contact);
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                invoker.Delete(id);
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
            }
           
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
            try
            {
                invoker.Add(contact);
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Search(string name)
        {
            try
            {
                var contact = invoker.Search(name);
                int id = -1;

                if (contact != null)
                    id = contact.Id;
                return RedirectToAction("Index", new { id = id });
            }

            catch (ServerException e)
            {
                ViewBag.Error = e.Message.ToString();
                return RedirectToAction("Index");
            }
        }
    }
}