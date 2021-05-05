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
            try {
                UserAccount user1 = UserAccount.findUser(-10);
                Console.WriteLine("User found");
            }
            catch (UserFindException ex) {
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            try
            {
                UserAccount user2 = UserAccount.findUser(15);
                Console.WriteLine("Users found");
            }
            catch (UserFindException ex)
            {
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nУспiшний пошук: ");
            try {
                UserAccount user1 = UserAccount.findUser(1);
                Console.WriteLine("User found: " + user1.Username);
            }
            catch (UserFindException ex) {
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
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
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            try
            {
                UserAccount.deleteUser(25);
                Console.WriteLine("User deleted");
            }
            catch (UserFindException ex)
            {
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nУспiшне видалення");
            try
            {
                UserAccount.deleteUser(1);
                Console.WriteLine("User deleted. ID: 1");
            }
            catch (UserFindException ex)
            {
                Console.WriteLine("Exception: " + ex.Message + ". ID: " + ex.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Modeling end");
            Console.ReadKey();

        }

        public static void ChatParticipantsChanged(Object sender, string message) {
            GroupChat chat = (GroupChat)sender;
            chat.sendMessage(UserAccount.System, message);
            Console.WriteLine(message);
        }

    }
}
