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

            Console.WriteLine("");

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

            Console.WriteLine("Властивостi класу Message");

            Message message = new Message();

            message.Body = "";
            message.Body = "Greetings";

            Console.WriteLine("Тiло повiдомлення: " + message.Body);
            message.AuthorId = -1;
            message.AuthorId = 0;

            Console.WriteLine("Id автора повiдомлення: " + message.AuthorId);

            Console.WriteLine("Дата вiдправлення повiдомлення: " + message.Datetime);

            Console.WriteLine("");
            Console.WriteLine("Modeling end");

            Console.ReadKey();
        }
    }
}
