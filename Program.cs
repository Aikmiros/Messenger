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
            Console.WriteLine("Розгортання системи");

            UserAccount user = new UserAccount("User", "user");

            Console.WriteLine("");
            Console.WriteLine("Конструктори");

            UserAccount user1 = new UserAccount();
            UserAccount user2 = new UserAccount("User2", "123456");
            UserAccount user3 = new UserAccount(user2);

            ChatRoom chat1 = new ChatRoom();
            ChatRoom chat2 = new ChatRoom(user2.id, "Chat2");
            ChatRoom chat3 = new ChatRoom(chat2);

            Message message1 = new Message();
            Message message2 = new Message(user2.id, "Hello");
            Message message3 = new Message(message2);

            Console.WriteLine("");
            Console.WriteLine("Modeling end");
            Console.ReadKey();
        }
    }
}
