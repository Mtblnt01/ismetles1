using ism_core;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace ism_console1
{
    internal class Program
    {
        public static List<User> users = new List<User>();
        public static UserService userService = new UserService(users);
        public static char separator = Config.CsvSeparator;

        public static void CreateUser(UserService service) {
            Console.Write("Kérek egy nevet: ");
            string name = Console.ReadLine();
            Console.Write("kérek egy jelszót: ");
            string password = Console.ReadLine();
            Console.Write("Kérek egy email címet: ");
            string email = Console.ReadLine();
            Console.Write("Kérek egy regisztrációs dátumot (yyyy-MM-dd): ");
            string regDate = Console.ReadLine();
            Console.Write("Kérek egy szintet (1-5): ");
            string levelStr = Console.ReadLine();

            try
            {
                User user = service.CreateUser(name, password, email, regDate, levelStr);
                Console.WriteLine(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hiba"+ex.Message);
            }
        }

        static void Main(string[] args)
        {
            //UI metódusok



            /*string csv = "2; Tibi; tibiakiraly; tibiakiraly@gmail.com; 2020-05-05; 2";
            
            try
            {
                User user = UserService.ParseFromCsv(csv, separator);
                users.Add(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
                Environment.Exit(1);
                throw;
            }
            */

            CreateUser(userService);




            /*
            User user = new User();

            try
            {
                user.Name = "tibi";
                user.Password = "jelszo";
                user.Email = "tibi.moriczref@hu";
                user.RegistrationDate = DateTime.Parse("2025-09-08");
                user.Level = 5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
                Environment.Exit(1);
            }
            Console.WriteLine(user);

            try   
            {
                User user1 = new User(2, "Tibi", "tibiakiraly", "tibiakiraly@gmail.com", "2020-05-05", 2);
                Console.WriteLine(user1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
                Environment.Exit(1);
            }
            */  
            Console.ReadKey();
            

        }
    }
}
