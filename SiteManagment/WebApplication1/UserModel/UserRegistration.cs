using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RGR.Models.UserModel
{
    public class UserRegistration
    {

        private const string _namePattern = @"^[A-Z][a-z]*$|^[А-ЯЁ][а-яё]*$";
        private const string _surnamePattern = @"^[A-Z][a-z]*(?:-[A-Z][a-z]*)?$|^[А-ЯЁ][а-яё]*(?:-[А-ЯЁ][а-яё]*)?$";
        private const string _mailPattern = @"^[^\W_](?:[\w\-\.]*[^\W_])?@(?:[^\W_](?:[\w\-]*[^\W_])?\.){1,}[a-zA-Z]{2,6}$";
        private const int symbolAmmount = 100;

        private string _name;
        private string _surname;
        private string _mail;
        private string _login;
        private string _password;
        private const string _role = "user";

        public UserRegistration(string name, string surname, string mail, string login, string password)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Login = login;
            Password = password;
        }
        public Guid Id { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

                if (CheckIfRegExp(_namePattern, value))
                {

                    _name = value;
                }
                else
                {
                    throw new Exception("Name");
                }

            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {

                if (CheckIfRegExp(_surnamePattern, value))
                {
                    _surname = value;
                }
                else
                {
                    throw new Exception("Surname");
                }

            }
        }
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {

                if (CheckIfRegExp(_mailPattern, value))
                {
                    _mail = value;
                }
                else
                {
                    throw new Exception("Mail");
                }
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {

                if (value != null)
                {
                    _login = value;
                }
                else
                {
                    throw new Exception("Login");
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != null)
                {
                    _password = value;
                }
                else
                {
                    throw new Exception("Password");
                }
            }
        }
        public string Role
        {
            get
            {
                return _role;
            }
        }

        private bool CheckIfRegExp(string pattern, string str)
        {
            if (str.Length <= symbolAmmount)
            {
                if (Regex.IsMatch(str, pattern))
                {
                    return true;
                }
            }
            return false;
        }
    }
}