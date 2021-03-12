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

            UserAccount user1 = new UserAccount();
            UserAccount user2 = new UserAccount("Anastasia", "123456");
            UserAccount user3 = new UserAccount(user2);

            ChatRoom chat1 = new ChatRoom();
            ChatRoom chat2 = new ChatRoom(2, "Chat2");
            ChatRoom chat3 = new ChatRoom(chat2);

            Message message1 = new Message();
            Message message2 = new Message("Hello");
            Message message3 = new Message(message2);

            Console.WriteLine("Modeling end");
            Console.ReadKey();
        }
    }
}
