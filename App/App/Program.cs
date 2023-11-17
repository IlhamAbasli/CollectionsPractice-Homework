using App.Controllers;

ContactController contactController = new();
bool loop = true;
while (loop)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("\nZehmet olmasa istediyiniz emeliyyati secin :)\n*******************************\n(1) Yeni kontakt elave etmek\n(2) Kontakti silmek\n(3) Kontakt nomresini deyisdirme\n(4) Kontaktlari gostermek\n(5) Axtaris\n(0) Bitir\n");
    Console.ResetColor();
Operation: string operation = Console.ReadLine();
    switch (operation)
    {
        case "1":
            contactController.Add();
            break;
        case "2":
            contactController.Delete();
            break;
        case "3":
            contactController.UpdatePhoneNumber();
            break;
        case "4":
            contactController.GetAll();
            break;
        case "5":
            contactController.Search();
            break;
        case "0":
            loop = false;
            break;
        default:
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Emeliyyat sehvdir, yeniden daxil et");
            Console.ResetColor();
            goto Operation;
    }
}



