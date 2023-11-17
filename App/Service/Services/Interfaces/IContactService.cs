using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void Add(Contact contact);
        bool Delete(string text);
        List<Contact> UpdatePhoneNumber(string searchText);
        List<Contact> SearchByName(string name);
        List<Contact> SearchByPhoneNumber(string phoneNumber);

    }
}
