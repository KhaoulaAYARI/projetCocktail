//using DAL_Khaoula.Entities;
//using DAL_Khaoula.Srvices;
using BLL_Khaoula.Entities;
using BLL_Khaoula.Services;

namespace ConsoleTestKhaoula
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*UserService userService = new UserService();
             Guid id = Guid.Parse("7418898e-51cb-4a01-a7aa-3f9281ed79aa");
             User user = userService.GetById(id);
             Console.WriteLine(user.First_Name);*/

            /*User user = new User(
            Guid.NewGuid(),
            "Maria",
             "Dupont",
              "Maria@example.com",
               "Test1234=");
            userService.Insert(user);
            Console.WriteLine(user.User_Id);
            foreach (User u in userService.Get())
           {
               Console.WriteLine($"{u.First_Name} {u.Last_Name}");
           }
          Console.WriteLine("avant Update");
          Console.WriteLine($"{user1.Last_Name}:{user1.First_Name}::{user1.Email} ");
          user1.First_Name = "Update2";
          user1.Last_Name = "Update2";
          user1.Email = "TestUpdate2@example.com";
          user1.Password = "Test1234=";

          userService.Update(user1.User_Id,user1);
          Console.WriteLine("apres Update");
          Console.WriteLine($"{user1.Last_Name}:{user1.First_Name}::{user1.Email} ");
          Guid id = Guid.Parse("3850bc18-ab44-47d0-bc52-22a6d5c30234");
          User user = userService.GetById(id);
          Console.WriteLine(user.First_Name);*/


            //BLL Get() ok
            //BLL Insert() ok
            //BLL GetById() ok

        }
    }
}
