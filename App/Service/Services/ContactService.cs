using Domain.Models;
using Service.Datas;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>() 
            {               
                new Contact{Id = 1, Name = "Ilham", Surname = "Abasli", PhoneNumber = "111111"},
                new Contact{Id = 2, Name = "Semed", Surname = "Huseynov", PhoneNumber = "222222"},
                new Contact{Id = 3, Name = "Aqsin", Surname = "Veliyev", PhoneNumber = "333333"},
                new Contact{Id = 4, Name = "Tunzale", Surname = "Memmedova", PhoneNumber = "444444"},
                new Contact{Id = 5, Name = "Arzu", Surname = "Kerimli", PhoneNumber = "555555"},

            };
        }

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public bool Delete(string text)
        {
            foreach (Contact contact in _contacts)
            {
                if (text.Trim().ToLower() == contact.Name.Trim().ToLower() || text.Trim().ToLower() == contact.Surname.Trim().ToLower())
                {
                    _contacts.Remove(contact);
                    return true;
                } 
            }
            return false;

        }

        public List<Contact> GetAll()
        {
            return _contacts;    
        }

        public List<Contact> SearchByName(string name)
        {
            return _contacts.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower()) || x.Surname.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();
        }
        public List<Contact> SearchByPhoneNumber(string phoneNumber)
        {
            return _contacts.Where(x => x.PhoneNumber.Trim() == phoneNumber.Trim()).ToList();

        }

        public List<Contact> UpdatePhoneNumber(string searchText)
        {
            var res = _contacts.Where(x => x.Name.Trim().ToLower() == searchText.Trim().ToLower() || x.Surname.Trim().ToLower() == searchText.Trim().ToLower()).ToList();
            if(res.Count == 0)
            {
                return null;
            }
            return res;
        }
    }
}
