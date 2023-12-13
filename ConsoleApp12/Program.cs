using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Events;
using System.IO;
using System.Text.RegularExpressions;
using ConsoleApp12;

class Program
{
    static List<string> existingLogins = new List<string> { "user1", "user2", "user3", "user4", "user5" };

    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("registration.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Console.WriteLine("Введите логин:");
        string login = Console.ReadLine();
        Console.WriteLine("Введите пароль:");
        string password = Console.ReadLine();
        Console.WriteLine("Подтвердите пароль:");
        string confirmPassword = Console.ReadLine();
        Registration registration = new Registration();
        (bool registrationSuccess, string errorMessage) = registration.ValidateUserRegistration(login, password, confirmPassword);

        if (registrationSuccess)
        {
            LogInformation(login, password, confirmPassword);
            Console.WriteLine("Успешная регистрация.");
        }
        else
        {
            LogError(login, password, confirmPassword, errorMessage);
            Console.WriteLine($"Ошибка регистрации: {errorMessage}");
        }
        Log.CloseAndFlush();
    }
    static void LogInformation(string login, string password, string confirmPassword)
    {
        Log.Information("{DateTime}: Успешная регистрация - Логин: {Login}, Пароль: {Password}, Подтверждение: {ConfirmPassword}",
            DateTime.Now, login, MaskPassword(password), MaskPassword(confirmPassword));
    }

    static void LogError(string login, string password, string confirmPassword, string errorMessage)
    {
        Log.Error(
            "{DateTime}: Неуспешная регистрация - Логин: {Login}, Пароль: {Password}, Подтверждение: {ConfirmPassword}, Ошибка: {ErrorMessage}",
            DateTime.Now, login, MaskPassword(password), MaskPassword(confirmPassword), errorMessage);
    }
    static string MaskPassword(string password)
    {
        return new string('*', password.Length);
    }
}
