using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class ChatRoom {

        private static ChatRoom[] chatRooms = new ChatRoom[100];
        private static int _nextRoomId = 0;

        private List<int> participants;
        private List<Message> messages;

        private int id;
        private string name;
        private int admin;

        public int Id { get { return id; } }

        public List<int> Participants {
            get { return participants; }
        }

        public List<Message> Messages {
            get { return messages; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3 && value.Length < 30) name = value;
                else Console.WriteLine("Довжина назви чату має бути вiд 3 до 30 символiв");
            }
        }

        public int Admin
        {
            get { return admin; }
            set
            {
                if (value >= 0) admin = value;
                else Console.WriteLine("Xибний iдентифiкатор користувача");
            }
        }

        public ChatRoom()
        {
            id = _nextRoomId++;
            name = "Chat" + id;
            admin = -1;
            chatRooms[id] = this;
            messages = new List<Message>();
            participants = new List<int>();
            messages.Add(new Message());
            //Console.WriteLine("ChatRoom created constructor default");
        }

        public ChatRoom(int userId, string name) {
            id = _nextRoomId++;
            this.name = name;
            admin = userId;
            messages = new List<Message>();
            participants = new List<int>();
            chatRooms[id] = this;
            //Console.WriteLine("ChatRoom created constructor initialization");
        }

        public ChatRoom(ChatRoom from)
        {
            id = _nextRoomId++;
            name = from.name;
            admin = from.admin;
            participants = from.participants;
            messages = new List<Message>();
            chatRooms[id] = this;
            //Console.WriteLine("ChatRoom created constructor copy");
        }

        public static ChatRoom operator +(ChatRoom A, Message msg)
        {
            A.postMessage(msg);
            return A;
        }

        public static ChatRoom operator+ (ChatRoom A, int userId)
        {
            A.addParticipant(userId);
            return A;
        }

        public static ChatRoom operator- (ChatRoom A, int userId)
        {
            A.deleteParticipant(userId);
            return A;
        }

        public static ChatRoom operator+ (ChatRoom A, ChatRoom B) {
            ChatRoom res = new ChatRoom(A);
            res.clearHistory();
            foreach (int id in B.participants) {
                res.addParticipant(id);
            }
            return res;
        }

        public static bool operator> (ChatRoom A, ChatRoom B)
        {
            return A.Participants.Count > B.participants.Count;
        }

        public static bool operator< (ChatRoom A, ChatRoom B)
        {
            return A.Participants.Count < B.participants.Count;
        }

        public static bool operator& (ChatRoom A, ChatRoom B)
        {
            foreach(int i in A.Participants){
                if (B.participants.Contains(i)){
                    return true;
                }
            }
            return false;
        }

        public static void deleteRoom(int id) {
            chatRooms[id] = null;
        }
        public void postMessage(Message message) {
            messages.Add(message);
        }
        public void deleteMessage(int id) {
            messages.RemoveAt(id);
        }
        public void clearHistory() {
            messages.Clear();
        }
        public void showHistory() {
            messages.ForEach(msg => msg.show());
        }
        public void addParticipant(int userId) {
            if (!participants.Contains(userId)) {
                participants.Add(userId);
            }
        }
        public void deleteParticipant(int userId) {
            participants.Remove(userId);
        }

    }
}
