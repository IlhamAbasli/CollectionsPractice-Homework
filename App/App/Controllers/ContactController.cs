using Domain.Models;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Controllers
{
    internal class ContactController
    {
        private IContactService _contactService;

        public ContactController()
        {
            _contactService = new ContactService(); 
        }

        public void Add()
        {
            Console.WriteLine("Ad daxil et");
            Name: string? name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ad bos qoyula bilmez");
                goto Name;
            }

            Console.WriteLine("Soyad daxil et");
            Surname: string? surname = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Soyad bos qoyula bilmez");
                goto Surname;
            }

            Console.WriteLine("Telefon nomresi daxil et");
            Number: string? phoneNumber = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Telefon nomresi bos qoyula bilmez");
                goto Number;
            }
            
            int id = 5;
            
            Contact contact = new Contact
            {
                Id = id + 1,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
            };
            _contactService.Add(contact);
        }
        public void Delete()
        {
            Console.WriteLine("Zehmet olmasa nomresini silmek istediyiniz sexsin adini ve ya soyadini daxil edin:");
            Text: string text = Console.ReadLine();
            var res = _contactService.Delete(text);
            if (!res)
            {
                Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                string operation = Console.ReadLine();
                if (operation == "1")
                {
                    return;
                }
                else if(operation == "2")
                {
                    goto Text;
                }
            }

            
        }
        public void GetAll()
        {
            Console.WriteLine("Hansi emeliyyati yerine yetirmek isteyirsiniz?\n(1) Butun siyahini gostermek\n(2) Butun siyahini A-Z siralamaq\n(3) Butun siyahini Z-A siralamaq\n");
            Operation: string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    var response = _contactService.GetAll();

                    foreach (var contact in response)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    break;
                case "2":
                    var sortedResponse = _contactService.GetAll().OrderBy(x => x.Name);
                    foreach (var contact in sortedResponse)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    break;
                case "3":
                    var res = _contactService.GetAll().OrderByDescending(x => x.Name);
                    foreach (var contact in res)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    break;

                default:
                    Console.WriteLine("Emeliyyat sehvdir, yeniden daxil et:");
                    goto Operation;
            }

        }

        public void Search()
        {
            Console.WriteLine("Hansi elamet uzre axtaris etmek isteyirsiniz?\nAd ve ya soyada gore: (1)\nTelefon nomresine gore: (2)\n");
            Operation: string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Name: Console.WriteLine("*Ad ve ya soyadi daxil edin");
                    string text = Console.ReadLine();
                    var response = _contactService.SearchByName(text);
                    if(response.Count == 0)
                    {
                        Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                        string searchOperation = Console.ReadLine();
                        if (searchOperation == "1")
                        {
                            return;
                        }
                        else if (searchOperation == "2")
                        {
                            goto Name;
                        }

                    }
                    foreach (var contact in response)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    break;
               
                
                case "2":
                    Number: Console.WriteLine("*Telefon nomresi daxil et:");
                    string phoneNumber = Console.ReadLine();
                    var persons = _contactService.SearchByPhoneNumber(phoneNumber);
                    if (persons.Count == 0)
                    {
                        Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                        string searchOperation = Console.ReadLine();
                        if (searchOperation == "1")
                        {
                            return;
                        }
                        else if (searchOperation == "2")
                        {
                            goto Number;
                        }

                    }

                    foreach (var contact in persons)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    break;

                default:
                    Console.WriteLine("Emeliyyat sehvdir, yeniden daxil et:");
                    goto Operation;
            }

        }

        public void UpdatePhoneNumber()
        {
            Console.WriteLine("Nomresini deyisdirmek istediyiniz sexsin adini ve ya soyadini daxil edin:");
            string searchText = Console.ReadLine();

            var res = _contactService.UpdatePhoneNumber(searchText);

            if(res != null)
            {
                foreach (var contact in res)
                {
                    Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                }
                Console.WriteLine("Yeni nomreni daxil edin:");
                string phoneNumber = Console.ReadLine();

                foreach (var contact1 in res)
                {
                    contact1.PhoneNumber = phoneNumber;
                    Console.WriteLine("Nomre ugurla deyisdirildi");
                }
            }
            else
            {
                Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
            }


        }
    }
}
