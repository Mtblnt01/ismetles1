using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_core
{
    public class UserService
    {
        // Controller metódusok
        private List<User> users;

        public UserService(List<User> u) {
            this.users = u;
        }

        public static User ParseFromCsv(string csv, char separator)
        {
            string[] parts = csv.Split(separator);
            if (parts.Length != 6)
                throw new ArgumentException("Hibás mezőszám");
            int id = int.Parse(parts[0]);
            string name = parts[1];
            string password = parts[2];
            string email = parts[3];
            string registrationDate = parts[4];
            int level = int.Parse(parts[5]);

            User user = new User(id, name, password, email, registrationDate, level);
            return user;
        }

        public void LoadUsersFromCsvFile(string filepath, char separator)
        {
            users.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if ((string.IsNullOrWhiteSpace(line)) || (line.StartsWith("#")))
                        {
                            continue;
                        }

                        try{
                            User user = ParseFromCsv(line, separator);
                            users.Add(user);
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine("Hibás sor kihagyása: " + ex.Message);
                            System.Diagnostics.Debug.WriteLine("Hibás sor kihagyva: " + ex.Message);
                        }
                    }
                }

            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Hiba a fájl olvasása során: "+ioEx.Message);
                System.Diagnostics.Debug.WriteLine(ioEx.StackTrace);    
            }
        }

        public void SaveUsersToCsvFile(string filepath, char separator)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
                {
                    foreach (User user in users)
                    {
                        string line = $"{user.Id} {separator}" +
                                      $"{user.Name} {separator}" +
                                      $"{user.Password} {separator}" +
                                      $"{user.Email} {separator}" +
                                      $"{user.RegistrationDate.ToString("yyyy-MM-dd")} {separator}" +
                                      $"{user.Level} {separator}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Hiba a fájl írása során: " + ioEx.Message);
                System.Diagnostics.Debug.WriteLine("Hiba a fájl írása során: " + ioEx.Message);
                throw;
            }
        }

        public User CreateUser(string name, string password, string email, string regDate, string levelStr)
        {
            int id = User.UserCount + 1;
            int level;
            try
            {
                level = int.Parse(levelStr);
            }
            catch (FormatException)
            {
                throw new ArgumentException("A szintnek számnak kell lennie");
            }
            User user = new User(id, name, password, email, regDate, level);
            users.Add(user);
            return user;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUserName(int id, string newName)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                user.Name = newName;
                return true;
            }
            return false;
        }

        public bool DeleteUserById(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        public List<User> ListAllUsers()
        {
            return users;
        }


    }
}
