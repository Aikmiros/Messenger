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

        public string participantList
        {
            get {
                string users = "";

                for (int i = 0; i < participants.Count; i++)
                {
                    if (i > 0) users += ", ";
                    users += participants[i];
                }
                return users;
            }
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
        }

        public ChatRoom(int userId, string name) {
            id = _nextRoomId++;
            this.name = name;
            admin = userId;
            messages = new List<Message>();
            participants = new List<int>();
            chatRooms[id] = this;
        }

        public ChatRoom(ChatRoom from)
        {
            id = _nextRoomId++;
            name = from.name;
            admin = from.admin;
            participants = from.Participants.Count == 0 ? new List<int>() : new List<int>(from.Participants);
            messages = new List<Message>();
            chatRooms[id] = this;
        }

        public static bool operator !(ChatRoom A)
        {
            return A.participants.Count == 0;
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

        public static bool operator true(ChatRoom A)
        {
            return A.participants.Count > 0;
        }
        public static bool operator false(ChatRoom A)
        {
            return A.participants.Count == 0; ;
        }

        public static ChatRoom operator & (ChatRoom A, ChatRoom B)
        {
            ChatRoom C = new ChatRoom(A.Admin, A.Name);
            foreach (int i in A.Participants){
                if (B.participants.Contains(i)){
                    C.addParticipant(i);
                }
            }
            return C;
        }

        public static ChatRoom operator |(ChatRoom A, ChatRoom B)
        {
            ChatRoom C = new ChatRoom(A.admin, A.name);
            foreach (int i in A.Participants)
            {
                C.addParticipant(i);
            }
            foreach (int i in B.Participants)
            {
                if (A.participants.Contains(i))
                {
                    C.addParticipant(i);
                }
            }
            return C;
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
