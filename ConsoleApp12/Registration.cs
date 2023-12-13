using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Registration
    {
        static List<string> existingLogins = new List<string> { "user1", "user2", "user3", "user4", "user5" };

        public (bool, string) ValidateUserRegistration(string login, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(login))
            {
                Console.WriteLine("Пустая строка в качестве логина");
                return (false, "Пустая строка в качестве логина");
            }
            else if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Пустая строка в качестве пароля");
                return (false, "Пустая строка в качестве пароля");
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                Console.WriteLine("Пустая строка в качестве подтверждения пароля");
                return (false, "Пустая строка в качестве подтверждения пароля");
            }
            if (existingLogins.Contains(login))
            {
                Console.WriteLine("Логин уже существует");
                return (false, "Логин уже существует");
            }
            if (login.Length < 5)
            {
                return (false, "Логин слишком короткий");
            }

            bool isValidLogin = Regex.IsMatch(login, @"^(?:\+\d{1,3}-)?\d{1,4}-\d{1,4}-\d{1,4}$|^\w+@\w+\.\w+$");
            if (!isValidLogin)
            {
                return (false, "Логин не соответствует формату телефона или электронной почты");
            }

            if (password != confirmPassword)
            {
                return (false, "Пароль и подтверждение пароля не совпадают.");
            }

            if (password.Length < 7)
            {
                return (false, "Пароль слишком короткий.");
            }

            if (!IsCyrillic(password))
            {
                return (false, "Пароль должен содержать только кириллические символы.");
            }

            bool hasLower = false;
            bool hasUpper = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    hasLower = true;
                }
                else if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    hasSpecialChar = true;
                }
            }

            if (!hasLower)
            {
                return (false, "Пароль не содержит буквы в нижнем регистре.");
            }

            if (!hasUpper)
            {
                return (false, "Пароль не содержит буквы в верхнем регистре.");
            }

            if (!hasDigit)
            {
                return (false, "Пароль не содержит цифры.");
            }

            if (!hasSpecialChar)
            {
                return (false, "Пароль не содержит спецсимвола.");
            }

            return (true, "Успешно");
        }

        static bool IsCyrillic(string password)
        {
            return !Regex.IsMatch(password, @"[a-zA-Z]");
        }

        static bool IsCyrillic(char c)
        {
            return (c >= 'А' && c <= 'я') || (c >= 'ё' && c <= 'ё');
        }
    }
}
