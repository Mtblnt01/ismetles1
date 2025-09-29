using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_core
{
    public class User
    {
        //osztályszintű mező
        public static int UserCount;

        //példányszintű mezők
        private int id;
        private string name;
        private string password;
        private string email;
        private DateTime registrationDate;
        private int level;

        public User(int id, string name, string password, string email, string registrationDate, int level)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            RegistrationDate = DateTime.Parse(registrationDate);
            Level = level;
            UserCount++;

        }

        public User() { }

        //Tulajdonságok
        public int Id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A név nem lehet üres vagy szókoz");
                name = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A jelszó nem lehet üres vagy szókoz");
                password = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("Érvénytelen email");
                email = value;
            }
        }

        //public DateTime RegistrationDate => registrationDate;
        public DateTime RegistrationDate
        {
            get => registrationDate;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("A regisztráció dátuma nem lehet a jövőben");
                }
                if (value < new DateTime(2000, 1, 1))
                {
                    throw new ArgumentException("A regisztráció dátuma nem lehet 2000 előtti");
                }
                registrationDate = value;
            }
        }

        public int Level
        {
            get => level;
            set
            {
                if (!(value >= 1 && value <= 10))
                {
                    throw new ArgumentException("a felhasználó szintje 1 és 10 közé kell essen");
                }
                level = value;
            }
        }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                   $"név: {Name}\n" +
                   $"jelszó: {Password}\n" +
                   $"email: {Email}\n" +
                   $"reg datum: {RegistrationDate:yyyy-MM-dd}\n" +
                   $"level: {level}\n";
        }

    }
}
