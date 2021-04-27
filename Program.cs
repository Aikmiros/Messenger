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

            UserAccount admin = new UserAccount("System", "admin");

            Console.WriteLine("Викристання делегату для класу UserAccount");
            UserAccount user1 = new UserAccount("user1", "password");
            Console.WriteLine("username = " + user1.Username);
            user1.changeUserInfo("username", "newUser2");
            Console.WriteLine("Змiнення iменi");
            Console.WriteLine("username = " + user1.Username);

            

            Console.WriteLine("");
            Console.WriteLine("Modeling end");
            Console.ReadKey();
        }
    }
}
