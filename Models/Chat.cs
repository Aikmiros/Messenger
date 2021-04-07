using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger
{
    public abstract class Chat
    {
        private static Chat[] chatRooms = new Chat[100];
        private static int _nextRoomId = 0;

        protected List<int> participants;
        protected List<Message> messages;
        protected int id;

        public int Id { get { return id; } }

        public List<int> Participants
        {
            get { return participants; }
        }

        public List<Message> Messages
        {
            get { return messages; }
        }

        public Chat()
        {
            id = _nextRoomId++;
            chatRooms[id] = this;
            messages = new List<Message>();
            participants = new List<int>();
            messages.Add(new Message());
        }

        public Chat(int userId, string name)
        {
            id = _nextRoomId++;
            messages = new List<Message>();
            participants = new List<int>();
            chatRooms[id] = this;
        }

        public Chat(Chat from)
        {
            id = _nextRoomId++;
            participants = from.Participants.Count == 0 ? new List<int>() : new List<int>(from.Participants);
            messages = new List<Message>();
            chatRooms[id] = this;
        }

        public static void deleteRoom(int id)
        {
            chatRooms[id] = null;
        }

        public void postMessage(Message message)
        {
            messages.Add(message);
        }

        public void deleteMessage(int id)
        {
            messages.RemoveAt(id);
        }
        public void clearHistory()
        {
            messages.Clear();
        }
        public void showHistory()
        {
            messages.ForEach(msg => msg.show());
        }

    }
}
