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
using Phonebook.Core.Exceptions;

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

            try
            {
                var response = client.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<Contact>(response);
            }

            catch (AggregateException)
            {
                throw new ServerException("Server connection error");
            }
        }

        public void Add(Contact contact)
        {
            string url = baseAdress
                + "/api/command/add";

            try
            {
                var response = client.PostAsJsonAsync<Contact>(url, contact).Result;
            }

            catch (AggregateException)
            {
                throw new ServerException("Server connection error");
            }

        }

        public void Delete(int id)
        {
            string url = baseAdress
                + "/api/command/delete/" + id;
            try
            {
                var response = client.DeleteAsync(url).Result;
            }

            catch (AggregateException)
            {
                throw new ServerException("Server connection error");
            }

        }

        public Contact Search(string name)
        {
            string url = baseAdress
                + "/api/command/search?name=" + name;

            try
            {
                var response = client.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<Contact>(response);
            }

            catch (AggregateException)
            {
                throw new ServerException("Server connection error");
            }
        }

        public void Change(Contact contact)
        {
            string url = baseAdress
                + "/api/command/change/";

            try
            {
                var response = client.PostAsJsonAsync<Contact>(url, contact).Result;
            }

            catch (AggregateException)
            {
                throw new ServerException("Server connection error");
            }

        }

        public List<Contact> GetAllContacts()
        {
            string url = baseAdress
                + "/api/command/getallcontacts";

            try
            {
                var response = client.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<List<Contact>>(response);
            }

            catch(AggregateException)
            {
                throw new ServerException("Server connection error");
            }
        }
    }
}
