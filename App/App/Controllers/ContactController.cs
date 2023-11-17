using Domain.Models;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Console.Clear();
            Console.WriteLine("Ad daxil et");
            Name: string? name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Ad bos qoyula bilmez");
                Console.ResetColor();
                goto Name;
            }

            Console.WriteLine("Soyad daxil et");
            Surname: string? surname = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Soyad bos qoyula bilmez");
                Console.ResetColor();
                goto Surname;
            }

            Console.WriteLine("Telefon nomresi daxil et");
            Number: string? phoneNumber = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Telefon nomresi bos qoyula bilmez");
                Console.ResetColor();
                goto Number;
            }else if(Regex.IsMatch(phoneNumber, "[a-zA-Z]"))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Telefon nomresinde herflerden istifade edile bilmez");
                Console.ResetColor();
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
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Kontakt elave edildi");
            Console.ResetColor();
        }
        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Zehmet olmasa nomresini silmek istediyiniz sexsin adini ve ya soyadini daxil edin:");
            Text: string text = Console.ReadLine();
            var res = _contactService.Delete(text);
            if (!res)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                Console.ResetColor();
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
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Kontakt muveffeqiyyetle silindi");
                Console.ResetColor();
            }

            
        }
        public void GetAll()
        {
            Console.Clear();
            Console.WriteLine("Hansi emeliyyati yerine yetirmek isteyirsiniz?\n(1) Butun siyahini gostermek\n(2) Butun siyahini A-Z siralamaq\n(3) Butun siyahini Z-A siralamaq\n");
            Operation: string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    var response = _contactService.GetAll();

                    foreach (var contact in response)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    Console.ResetColor();
                    break;
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    var sortedResponse = _contactService.GetAll().OrderBy(x => x.Name);
                    foreach (var contact in sortedResponse)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    Console.ResetColor();
                    break;
                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    var res = _contactService.GetAll().OrderByDescending(x => x.Name);
                    foreach (var contact in res)
                    {
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    }
                    Console.ResetColor();
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Emeliyyat sehvdir, yeniden daxil et:");
                    Console.ResetColor();
                    goto Operation;
            }

        }

        public void Search()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hansi elamet uzre axtaris etmek isteyirsiniz?\nAd ve ya soyada gore: (1)\nTelefon nomresine gore: (2)\n");
            Console.ResetColor();
            Operation: string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Name: Console.WriteLine("*Ad ve ya soyadi daxil edin");
                    Console.ResetColor();
                    string text = Console.ReadLine();
                    var response = _contactService.SearchByName(text);
                    if(response.Count == 0)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                        Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                        Console.ResetColor();
                    }
                    break;
               
                
                case "2":
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Number: Console.WriteLine("*Telefon nomresi daxil et:");
                    Console.ResetColor();
                    string phoneNumber = Console.ReadLine();
                    var persons = _contactService.SearchByPhoneNumber(phoneNumber);
                    if (persons.Count == 0)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                        Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                        Console.ResetColor();
                    }
                    break;

                default:
                    Console.BackgroundColor= ConsoleColor.Red;
                    Console.ForegroundColor= ConsoleColor.Black;
                    Console.WriteLine("Emeliyyat sehvdir, yeniden daxil et:");
                    Console.ResetColor();
                    goto Operation;
            }

        }

        public void UpdatePhoneNumber()
        {
            Text: Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Nomresini deyisdirmek istediyiniz sexsin adini ve ya soyadini daxil edin:");
            Console.ResetColor();
            string searchText = Console.ReadLine();

            var res = _contactService.UpdatePhoneNumber(searchText);

            if(res != null)
            {
                foreach (var contact in res)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\n**Ad: {contact.Name}\n**Soyad: {contact.Surname}\n**Telefon nomresi: {contact.PhoneNumber}\n*****************************\n");
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Yeni nomreni daxil edin:");
                Console.ResetColor();
                string phoneNumber = Console.ReadLine();

                foreach (var contact1 in res)
                {
                    Console.Clear();
                    contact1.PhoneNumber = phoneNumber;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Nomre ugurla deyisdirildi");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Axtardiginiz meyarlara cavab veren melumat tapilmadi. Zehmet olmasa secim edin:\n* Emeliyyati dayandirmaq ucun: (1)\n* Yeniden cehd etmek ucun: (2)\n");
                Console.ResetColor();
                string searchOperation = Console.ReadLine();
                if (searchOperation == "1")
                {
                    return;
                }
                else if (searchOperation == "2")
                {
                    goto Text;
                }
            }


        }
    }
}
