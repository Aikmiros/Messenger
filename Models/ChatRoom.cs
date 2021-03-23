using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class ChatRoom {

        private static ChatRoom[] chatRooms = new ChatRoom[100];
        private static int _nextRoomId = 0;

        private int[] participants;
        private List<Message> messages;
        private int _nextMessageId;

        private int id;
        private string name;
        private int admin;

        public int Id { get; }

        public int Participants { get; }

        public int Messages { get; }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3 && value.Length < 30) name = value;
                else Console.WriteLine("Довжина назви чату має бути від 3 до 30 символів");
            }
        }

        public int Admin
        {
            get { return admin; }
            set
            {
                if (value >= 0) admin = value;
                else Console.WriteLine("Xибний ідентифікатор користувача");
            }
        }

        public ChatRoom()
        {
            this.id = ChatRoom._nextRoomId++;
            this.name = "Chat" + this.id;
            this.admin = -1;
            this.participants = new int[100];
            ChatRoom.chatRooms[this.id] = this;
            this.messages = new List<Message>();
            this.messages.Add(new Message());
            Console.WriteLine("ChatRoom created constructor default");
        }

        public ChatRoom(int userId, string name) {
            this.id = ChatRoom._nextRoomId++;
            this.name = name;
            this.admin = userId;
            this.participants = new int[100];
            ChatRoom.chatRooms[this.id] = this;
            Console.WriteLine("ChatRoom created constructor initialization");
        }

        public ChatRoom(ChatRoom from)
        {
            this.id = ChatRoom._nextRoomId++;
            this.name = from.name;
            this.admin = from.admin;
            this.participants = from.participants;
            ChatRoom.chatRooms[this.id] = this;
            Console.WriteLine("ChatRoom created constructor copy");
        }

        public void deleteRoom() { }
        public void postMessage(Message message) { }
        public void deleteMessage(int id) { }
        public void clearHistory() { }
        public void showHistory() { }
        public void addParticipant(int userId) { }
        public void deleteParticipant(int userId) { }
        
    }
}
