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

            new UserAccount("System", "admin");

            Console.WriteLine("Властивостi класу UserAccount");
            UserAccount user = new UserAccount();
            Console.WriteLine("ID користувача: " + user.Id);
            user.Username = "u";
            user.Username = "user";
            Console.WriteLine("Iм'я користувача: " + user.Username);
            user.Password = "pass";
            user.Password = "password";
            Console.WriteLine("Пароль користувача: " + user.Password);
            user.Status = "status";
            Console.WriteLine("Статус користувача: " + user.Status);

            Console.WriteLine("Властивостi класу ChatRoom");

            ChatRoom chat = new ChatRoom();

            Console.WriteLine("ID чата: " + chat.Id);

            chat.Name = "Ч";
            chat.Name = "Чат1";
            Console.WriteLine("Назва чата " + chat.Name);

            chat.Admin = 1;
            chat.Admin = -1;
            Console.WriteLine("Адмiн чата: " + chat.Admin);

            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine("Modeling end");

            Console.ReadKey();
        }
    }
}
