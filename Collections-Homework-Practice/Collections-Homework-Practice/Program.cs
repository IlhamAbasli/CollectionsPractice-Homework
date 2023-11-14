using Collections_Homework_Practice.Controllers;
using Service.Datas;
using System.Collections;


#region Homework
//AuthorController authorController = new AuthorController();

//authorController.GetAlByAge();


//EmployeeController employeeController = new EmployeeController();
//employeeController.GetCountByFilter();




//AccountController accountController = new();
//ProductController productController = new();


//var res = accountController.Login();

//if (res)
//{
//    while (true)
//    {
//        Console.WriteLine("Select one option: 1 - GetAllProducts, 2 - SearchProductsByName");

//        Option: string option = Console.ReadLine();


//        int resultOption;

//        bool isCorrextFormatOption = int.TryParse(option, out resultOption);

//        if (isCorrextFormatOption)
//        {
//            switch (resultOption)
//            {
//                case 1:
//                    productController.GetAll();
//                    break;
//                case 2:
//                    productController.Search();
//                    break;
//                default:
//                    Console.WriteLine("Option not found, please select again:");
//                    goto Option;
//            }
//        }
//        else
//        {
//            Console.WriteLine("Option format is wrong, please select again:");
//            goto Option;
//        }
//    }

//}

#endregion


#region Collections

//ArrayList arrayList = new ArrayList();

//arrayList.Add(1);
//arrayList.Add("salam");
//arrayList.Add(true);

//foreach (var item in arrayList)
//{
//    Console.WriteLine(item);
//}



//Hashtable hastable = new Hashtable();
//hastable.Add(1, "salam");
//hastable.Add(2, "sagol");
//foreach (DictionaryEntry item in hastable)
//{
//    Console.WriteLine(item.Key + " - " + item.Value);
//}



//SortedList sortedList = new SortedList();
//sortedList.Add("b", "salam");
//sortedList.Add("a", "sagol");
//foreach (DictionaryEntry item in sortedList)
//{
//    Console.WriteLine(item.Key + " - " + item.Value);
//}




//SortedList<int, string> sortedList = new SortedList<int, string>();
//sortedList.Add(1, "test1");
//sortedList.Add(2, "test2");

//foreach(KeyValuePair<int,string> item in sortedList)
//{
//    if(item.Key == 1)
//    {
//        Console.WriteLine(item.Value);
//    }
//}




//Queue queue = new Queue();

//queue.Enqueue("salam");
//queue.Enqueue("salam1");
//queue.Enqueue("salam2");

//foreach (var item in queue)
//{
//    Console.WriteLine(item);
//}



//Stack stack = new Stack();


//stack.Push("test1");
//stack.Push("test2");
//stack.Push("test3");

//foreach(var item in stack)
//{
//    Console.WriteLine(item);
//}



//Dictionary<int,string> roles = new Dictionary<int,string>();

//roles.Add(1, "Member");
//roles.Add(2, "Admin");
//roles.Add(3, "SuperAdmin");

//foreach (KeyValuePair<int,string> role in roles)
//{
//    Console.WriteLine(role.Value);
//}


List<string> roles = new List<string>() { "Admin", "Member", "SuperAdmin" };
List<string> emails = new List<string>() { "t@gmail.com", "s@mail.ru", "ds@gmail.com" };

Dictionary<string, List<string>> datas = new Dictionary<string, List<string>>();

datas.Add("roles", roles);
datas.Add("emails", emails);

foreach (var item in datas)
{
    if(item.Key == "roles")
    {
        foreach (var role in item.Value)
        {
            if(role == "Admin")
            {
                Console.WriteLine(role);
            }
        }
    }

}


#endregion




