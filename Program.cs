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

            Console.WriteLine("Testing operators");

            ChatRoom chat2 = new ChatRoom { Name = "Chat2", Admin = user.Id};
            chat2.addParticipant(user.Id);
            chat2 = chat2 + new UserAccount().Id;
            chat2 = chat2 + new Message();

            ChatRoom chat3 = chat + chat2;

            string users = "";

            for(int i = 0; i < chat3.Participants.Count; i++){
                if (i > 0) users += ", ";
                users += chat3.Participants[i];
            }

            Console.WriteLine("");

            Console.WriteLine("Chat3 participants: " + users);

            Console.WriteLine("");

            Console.WriteLine("chat2 & chat3: " + (chat2 & chat3));

            Console.WriteLine("");


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



            Console.WriteLine("");
            Console.WriteLine("Modeling end");

            Console.ReadKey();
        }
    }
}
