using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class ChatRoom {

        public static ChatRoom[] chatRooms;
        public static int _nextRoomId;

        public int id;
        public string name;
        public Message[] messages;
        public int[] participants;

        public int _nextMessageId;

        public void createRoom(string name) { }
        public void deleteRoom(string name) { }
        public void changeName(string name) { }
        public void postMessage(string body, string username) { }
        public void deleteMessage(int id) { }
        public void clearHistory() { }
        public void showHistory() { }
        public void addParticipant(string username) { }
        public void deleteParticipant(string username) { }
        
         
    }
}
