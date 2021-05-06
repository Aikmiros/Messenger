using System;

namespace Messenger {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Messenger");
            Console.WriteLine("Version: 1");
            Console.WriteLine("Authors: Grybenko Yegor, Sukhanova Maria, Trembach Anastasia");
            Console.WriteLine("Group: IP-93");
            Console.WriteLine("Brigade: 3");
            Console.WriteLine("");
            Console.WriteLine("Modeling start");
            Console.WriteLine("");


            Console.WriteLine("Виключення, якi можуть виникати при некоректнiй авторизацiї");
            new UserAccount("user1", "password");
            Console.WriteLine("Некоректний пароль");
            try {
                UserAccount user1 = UserAccount.login("user1", "passwor");
                Console.WriteLine("Succesful login");
            } catch(UserAuthException ex) {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Exception: " + "No user with username - " + ex.Username);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Некоректне iм'я користувача, генерацiя власного виключення");
            try {
                UserAccount user1 = UserAccount.login("user", "password");
                Console.WriteLine("Succesful login");
            } catch (UserAuthException ex) {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Exception: " + "No user with username - " + ex.Username);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Успiшна авторизацiя");
            try {
                UserAccount user1 = UserAccount.login("user1", "password");
                Console.WriteLine("Succesful login");
            } catch (UserAuthException ex) {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Exception: " + "No user with username - " + ex.Username);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nВиключення, якi можуть виникати при пошуку неiснуючих користувачiв");
            int id = -10;
            try {
                UserAccount user1 = UserAccount.findUser(id);
                Console.WriteLine("User found");
            }
            catch (UserFindException ex) {
                Console.WriteLine("UserFindException: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (ArgumentOutOfRangeException) when (id < 0)
            {
                Console.WriteLine("ID mustn't be less than 0");
            }
            catch (ArgumentOutOfRangeException) when (id >= 100)
            {
                Console.WriteLine("ID must be less than 100");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            try {
                UserAccount user2 = UserAccount.findUser(15);
                Console.WriteLine("Users found");
            }
            catch (UserFindException ex) {
                Console.WriteLine("UserFindException: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nВиключення, якi можуть виникати при спробi видалення неiснуючих користувачiв");
            try {
                UserAccount.deleteUser(-20);
                Console.WriteLine("User deleted");
            }
            catch (UserFindException ex) {
                Console.WriteLine("UserFindException: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            try {
                UserAccount.deleteUser(25);
                Console.WriteLine("User deleted");
            }
            catch (UserFindException ex) {
                Console.WriteLine("UserFindException: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nВиключення, якi можуть виникати при спробi вiдправлення пустого повiдомлення");
            UserAccount user = new UserAccount();
            GroupChat chat1 = new GroupChat(user.Id, "Chat1");

            try {
                chat1.sendMessage(user, "");
            }
            catch (ArgumentException ex) {
                Console.WriteLine("ArgumentException: " + ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Exception: " + ex.Message);
            }

            try {
                chat1.sendMessage(user, null);
            }
            catch (ArgumentNullException ex) {
                Console.WriteLine("ArgumentNullException: " + ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Modeling end");
            Console.ReadKey();

        }

    }
}
