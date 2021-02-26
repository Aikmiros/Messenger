using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class ChatRoom {

        public static ChatRoom[] chatRooms;
        public static int _nextRoomId;

        public int id;
        public string name;
        public int admin;
        public Message[] messages;
        public int[] participants;

        public int _nextMessageId;

        public static void createRoom(string name) { }

        public void deleteRoom() { }
        public void changeName(string name) { }
        public void postMessage(Message message) { }
        public void deleteMessage(int id) { }
        public void clearHistory() { }
        public void showHistory() { }
        public void addParticipant(string username) { }
        public void deleteParticipant(string username) { }
        
         
    }
}
