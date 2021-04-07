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

            UserAccount user = new UserAccount();
            ChatRoom chat = new ChatRoom();

            Console.WriteLine("Перевантаження операторiв для класу UserAccount");
            Console.WriteLine("Унарнi оператори");
            UserAccount user2 = new UserAccount("user2", "qwerty");
            Console.WriteLine("user++ => user.rank = " + user++.Rank);
            Console.WriteLine("user-- => user.rank = " + user--.Rank);
            Console.WriteLine("");

            Console.WriteLine("Бiнарнi оператори");
            user = user + "newstatus";
            Console.WriteLine("user + 'newstatus' => user.status = " + user.Status);
            ChatRoom chat4 = new ChatRoom(user.Id, "newChat");
            user2 = user2 + chat4;
            Console.WriteLine("user + chat => user.ChatRooms = " + String.Join(", ", user2.chatRooms));
            user2 = user2 - chat4;
            Console.WriteLine("user - chat => user.ChatRooms = " + String.Join(", ", user2.chatRooms));
            Console.WriteLine("");

            Console.WriteLine("Оператори порiвняння");
            user.Rank = 4;
            Console.WriteLine("user > user2 => " + (user > user2));
            Console.WriteLine("user < user2 => " + (user < user2));
            Console.WriteLine("");

            Console.WriteLine("Перевантаження операторiв для класу ChatRoom");
            Console.WriteLine("");

            ChatRoom chat2 = new ChatRoom { Name = "Chat2", Admin = user.Id };
            chat2.addParticipant(user.Id);

            Console.WriteLine("Унарнi оператори");

            Console.WriteLine("");

            Console.WriteLine("chat2 => " + !!chat2);
            Console.WriteLine("!chat2 => " + !chat2);
            Console.WriteLine("");

            Console.WriteLine("Бiнарнi оператори");

            Console.WriteLine("");

            chat2.addParticipant(user.Id);

            Console.WriteLine("chat2.participants: " + chat2.participantList);
            int user3 = new UserAccount().Id;
            chat2 = chat2 + user3;
            Console.WriteLine("chat2 = chat2 + user3 => chat2.participants: " + chat2.participantList);

            chat2 = chat2 + new Message();

            chat += new UserAccount().Id;

            Console.WriteLine("");

            ChatRoom chat3 = chat2 + chat;

            Console.WriteLine("chat3 = chat + chat2 => chat3.participants: " + chat3.participantList);

            Console.WriteLine("");

            Console.WriteLine("Логiчнi оператори");

            Console.WriteLine("");

            Console.WriteLine("chat && chat2: " + !!(chat2 && chat));
            Console.WriteLine("chat || chat2: " + !!(chat2 || chat));

            Console.WriteLine("");

            Console.WriteLine("Оператори порiвняння");
            
            Console.WriteLine("");

            Console.WriteLine("chat3 > chat2 => " + (chat3 > chat2));
            Console.WriteLine("chat3 < chat2 => " + (chat3 < chat2));
            Console.WriteLine("");

            Console.WriteLine("Перевантаження операторiв для класу Message");
            Console.WriteLine("");

            Message firstMsg = new Message { Body = "First message" };

            Console.WriteLine("Унарнi оператори");

            Console.WriteLine("");

            Console.WriteLine("first => " + !!firstMsg);
            Console.WriteLine("!first => " + !firstMsg);

            Console.WriteLine("");

            Console.WriteLine("firstMsg++ => firstMsg.authorId = " + firstMsg++.AuthorId);
            Console.WriteLine("firstMsg-- => firstMsg.authorId = " + firstMsg--.AuthorId);

            Console.WriteLine("");

            Console.WriteLine("Бiнарнi оператори");

            Console.WriteLine("");

            firstMsg = firstMsg + " and more.";
            Console.WriteLine("firstMsg + 'and more.' => firstMsg.body = " + firstMsg.Body);

            Message secondMsg = new Message { Body = " Second message" };

            Message bothMsg = firstMsg + secondMsg;

            Console.WriteLine("firstMsg + secondMsg => bothMsg.body = " + bothMsg.Body);

            Console.WriteLine("");

            Console.WriteLine("Оператори порiвняння");

            Console.WriteLine("");

            Console.WriteLine("firstMsg > secondMsg => " + (firstMsg > secondMsg));
            Console.WriteLine("firstMsg < secondMsg => " + (firstMsg < secondMsg));

            Console.WriteLine("");

            Console.WriteLine("firstMsg == secondMsg => " + (firstMsg == secondMsg));
            Console.WriteLine("firstMsg != secondMsg => " + (firstMsg != secondMsg));

            Console.WriteLine("");

            Console.WriteLine("Modeling end");

            Console.ReadKey();
        }
    }
}
