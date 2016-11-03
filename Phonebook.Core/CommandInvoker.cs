using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Phonebook.Core.Model;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Newtonsoft.Json;

namespace Phonebook.Core
{
    public class CommandInvoker
    {
        static HttpClient client;
        string baseAdress = "http://localhost:8080";

        public CommandInvoker()
        {
            client = new HttpClient();
        }

        public Contact GetContact(int id)
        {
            string url = baseAdress
                + "/api/command/get/" + id;

            var response = client.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Contact>(response);
        }

        public void Add(Contact contact)
        {
            string url = baseAdress
                + "/api/command/add";

            var response = client.PostAsJsonAsync<Contact>(url, contact).Result;
        }

        public void Delete(int id)
        {
            string url = baseAdress
                + "/api/command/delete/" + id;

            var response = client.DeleteAsync(url).Result;
        }

        public Contact Search(string name)
        {
            string url = baseAdress
                + "/api/command/search?name=" + name;

            var response = client.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Contact>(response);
        }

        public void Change(Contact contact)
        {
            string url = baseAdress
                + "/api/command/change/";

            var response = client.PostAsJsonAsync<Contact>(url, contact).Result;
        }

        public List<Contact> GetAllContacts()
        {
            string url = baseAdress
                + "/api/command/getallcontacts";

            var response = client.GetStringAsync(url).Result;

            return  JsonConvert.DeserializeObject<List<Contact>>(response);
        }
    }
}
