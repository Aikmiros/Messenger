using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class ChatRoom {

        public static ChatRoom[] chatRooms = new ChatRoom[100];
        public static int _nextRoomId = 0;

        public int id;
        public string name;
        public int admin;
        public List<Message> messages;
        public int[] participants;

        public int _nextMessageId;

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
        public void changeName(string name) { }
        public void postMessage(Message message) { }
        public void deleteMessage(int id) { }
        public void clearHistory() { }
        public void showHistory() { }
        public void addParticipant(int userId) { }
        public void deleteParticipant(int userId) { }
        
    }
}
