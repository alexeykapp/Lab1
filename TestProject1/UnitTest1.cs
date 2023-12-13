using ConsoleApp12;
using Microsoft.Win32;

namespace TestProject1
{
    public class Tests
    {
        [TestCase("", "Password123", "Password123",false, "������ ������ � �������� ������")]
        [TestCase("hhdsdh@gds.dud", "", "Password123",false, "������ ������ � �������� ������")]
        [TestCase("hhdsdh@gds.dud", "��������", "",false, "������ ������ � �������� ������������� ������")]
        [TestCase("jdsjsd@jds.cj", "������343!", "������343!", true, "�������")]
        [TestCase("+7-123-456-789", "������343!", "������343!", true, "�������")]
        [TestCase("gfs", "���������", "���", false, "����� ������� ��������")]
        [TestCase("����", "����", "����", false, "����� ������� ��������")]
        [TestCase("?*:%;��%:?*()(*?:%", "�����", "����", false, "����� �� ������������� ������� �������� ��� ����������� �����")]
        [TestCase("user@sd", "", "������2112", false, "������ ������ � �������� ������")]
        [TestCase("newuser", "������", "������", false, "����� �� ������������� ������� �������� ��� ����������� �����")]
        [TestCase("asasasas@gds.ds", "��������", "��������", false, "������ �� �������� ����� � ������� ��������.")]
        [TestCase("sasas@gds.ds", "��������", "��������", false, "������ �� �������� �����.")]
        [TestCase("sadssas@gds.ds", "��������1", "��������1", false, "������ �� �������� �����������.")]
        [TestCase("adsssssws@gds.ds", "��W������!1", "��W������!1", false, "������ ������ ��������� ������ ������������� �������.")]
        [TestCase("abc", "Password123", "Password123", false, "����� ������� ��������")]
        [TestCase("asasasas@dsd.c", "����������2", "����������2", false, "������ �� �������� ����� � ������ ��������.")]
        [TestCase("+7-123-456-789", "������!", "������!", false, "������ �� �������� �����.")]
        [TestCase("+7-423-456-789", "������", "������", false, "������ ������� ��������.")]
        [TestCase("+7-177-416-789", "������1", "������1", false, "������ �� �������� �����������.")]
        [TestCase("+7177416789", "������1", "������1", false, "����� �� ������������� ������� �������� ��� ����������� �����")]
        [TestCase("+7-177-416-OOO", "������1", "������1", false, "����� �� ������������� ������� �������� ��� ����������� �����")]
        [TestCase("+7-177-416000", "�dfdsdf3", "�dfdsdf3", false, "����� �� ������������� ������� �������� ��� ����������� �����")]
        [TestCase("fdfdsfsd", "", "", false, "������ ������ � �������� ������")]
        [TestCase("user1", "Password123", "Password123", false, "����� ��� ����������")]

        public void CheckRegisterTest(string login, string password, string password2, bool expectedResult, string expectedMessage)
        {
            Registration registr = new Registration();
            (bool result, string messageResult) = registr.ValidateUserRegistration(login,password,password2);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMessage, messageResult);
        }
    }
}