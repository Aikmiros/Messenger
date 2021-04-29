﻿using System;

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

            Console.WriteLine("Викoристання делегату для класу UserAccount");
            UserAccount user1 = new UserAccount("user1", "password");
            Console.WriteLine("username = " + user1.Username);
            user1.changeUserInfo("username", "newUser2");
            Console.WriteLine("Змiнення iменi");
            Console.WriteLine("username = " + user1.Username);

            Console.WriteLine("Додавання нового делегату");
            Console.WriteLine("status = " + user1.Status);
            user1.addFieldToChange("status", (info) => { user1.Status = info; });
            user1.changeUserInfo("status", "newStatus");
            Console.WriteLine("Змiнення статусу");
            Console.WriteLine("status = " + user1.Status);


            Console.WriteLine("");
            Console.WriteLine("Подiя для класу GroupChat");
            GroupChat chat = new GroupChat(user1.Id, "NewChat");

            GroupChat.EventHandler listener1 = new GroupChat.EventHandler(ChatParticipantsChanged);
            GroupChat.EventHandler listener2 = new GroupChat.EventHandler(delegate { Console.WriteLine("Event done"); });

            chat.ParticipantsChanged += listener1;
            chat.ParticipantsChanged += listener2;
            UserAccount user2 = new UserAccount("user2", "password");
            chat.addParticipant(user1, user2.Id);
            chat.ParticipantsChanged -= ChatParticipantsChanged;
            chat.deleteParticipant(user1, user2.Id);

            chat.ParticipantsChanged -= listener1;
            chat.ParticipantsChanged -= listener2;

            chat.addParticipant(user1, user1.Id);
            chat.addParticipant(user1, user2.Id);
            chat.addParticipant(user1, new UserAccount("user3", "password").Id);

            Console.WriteLine("");
            Console.WriteLine("Подiя для класу Chat");

            Chat.deleteRoom(chat.Id);

            Console.WriteLine("");
            Console.WriteLine("Виклик лямбда-оператора");

            chat.ChatNotification += (Chat chat, Chat.ChatEvents chatEvent) => {
                if (chatEvent == Chat.ChatEvents.message)
                {
                    TextMessage msg = chat.messages[chat.messages.Count - 1] as TextMessage;
                    if (msg != null) msg.show();
                }
            };

            chat.sendMessage(user1, "NewMessageText");

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
