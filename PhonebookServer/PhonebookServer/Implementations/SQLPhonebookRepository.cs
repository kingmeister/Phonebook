using PhonebookServer.Interfaces;
using PhonebookServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookServer.Implementations
{
    class SQLPhonebookRepository : IRepository<Contact>
    {
        private Context db;
        private bool disposed = false;

        public SQLPhonebookRepository()
        {
            this.db = new Context();
        }

        public void Create(Contact item)
        {
            db.Contacts.Add(item);
        }

        public void Delete(int id)
        {
            var contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Contact Get(int id)
        {
            return db.Contacts.Find(id);
        }

        public IEnumerable<Contact> GetList()
        {
            return db.Contacts.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Contact item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
