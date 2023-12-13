using ConsoleApp12;
using Microsoft.Win32;

namespace TestProject1
{
    public class Tests
    {
        [TestCase("", "Password123", "Password123",false, "Пустая строка в качестве логина")]
        [TestCase("hhdsdh@gds.dud", "", "Password123",false, "Пустая строка в качестве пароля")]
        [TestCase("hhdsdh@gds.dud", "Вывывывы", "",false, "Пустая строка в качестве подтверждения пароля")]
        [TestCase("jdsjsd@jds.cj", "Порвыо343!", "Порвыо343!", true, "Успешно")]
        [TestCase("+7-123-456-789", "Вырвыо343!", "Вырвыо343!", true, "Успешно")]
        [TestCase("gfs", "павпвапва", "авы", false, "Логин слишком короткий")]
        [TestCase("роав", "выав", "ваыа", false, "Логин слишком короткий")]
        [TestCase("?*:%;№К%:?*()(*?:%", "вапва", "павп", false, "Логин не соответствует формату телефона или электронной почты")]
        [TestCase("user@sd", "", "Пароль2112", false, "Пустая строка в качестве пароля")]
        [TestCase("newuser", "Пароль", "Пароль", false, "Логин не соответствует формату телефона или электронной почты")]
        [TestCase("asasasas@gds.ds", "вырвывры", "вырвывры", false, "Пароль не содержит буквы в верхнем регистре.")]
        [TestCase("sasas@gds.ds", "Вырвывры", "Вырвывры", false, "Пароль не содержит цифры.")]
        [TestCase("sadssas@gds.ds", "Вырвывры1", "Вырвывры1", false, "Пароль не содержит спецсимвола.")]
        [TestCase("adsssssws@gds.ds", "ВыWрвывры!1", "ВыWрвывры!1", false, "Пароль должен содержать только кириллические символы.")]
        [TestCase("abc", "Password123", "Password123", false, "Логин слишком короткий")]
        [TestCase("asasasas@dsd.c", "ВВВВВВВВВВ2", "ВВВВВВВВВВ2", false, "Пароль не содержит буквы в нижнем регистре.")]
        [TestCase("+7-123-456-789", "Пароль!", "Пароль!", false, "Пароль не содержит цифры.")]
        [TestCase("+7-423-456-789", "Пароль", "Пароль", false, "Пароль слишком короткий.")]
        [TestCase("+7-177-416-789", "Пароль1", "Пароль1", false, "Пароль не содержит спецсимвола.")]
        [TestCase("+7177416789", "Пароль1", "Пароль1", false, "Логин не соответствует формату телефона или электронной почты")]
        [TestCase("+7-177-416-OOO", "Пароль1", "Пароль1", false, "Логин не соответствует формату телефона или электронной почты")]
        [TestCase("+7-177-416000", "Пdfdsdf3", "Пdfdsdf3", false, "Логин не соответствует формату телефона или электронной почты")]
        [TestCase("fdfdsfsd", "", "", false, "Пустая строка в качестве пароля")]
        [TestCase("user1", "Password123", "Password123", false, "Логин уже существует")]

        public void CheckRegisterTest(string login, string password, string password2, bool expectedResult, string expectedMessage)
        {
            Registration registr = new Registration();
            (bool result, string messageResult) = registr.ValidateUserRegistration(login,password,password2);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMessage, messageResult);
        }
    }
}