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
        internal List<IMessage> messages;
        protected int id;
        protected bool opened;

        public enum ChatEvents
        {
            delete,
            create,
            message
        }

        public delegate void Notification(Chat chat, ChatEvents chatEvent);
        public event Notification ChatNotification;

        public int Id { get { return id; } }
        public bool Opened { get; }

        public virtual List<int> Participants { get; }

        internal List<IMessage> Messages {
            get { return messages; }
        }

        public Chat()
        {
            id = _nextRoomId++;
            messages = new List<IMessage>();
            participants = new List<int>();
            chatRooms[id] = this;
            opened = false;
        }

        public Chat(Chat from) : this() {
            participants = from.Participants.Count == 0 ? new List<int>() : new List<int>(from.Participants);
        }

        public static void deleteRoom(int id) {
            chatRooms[id].OnDestroy();
            chatRooms[id] = null;
        }

        public static Chat FindChat(int id) {
            if (id >= 0 && id < _nextRoomId){
                return chatRooms[id];
            }
            else return null;
        }

        protected bool addUser(UserAccount user)
        {
            if (participants.Contains(user.Id)) return false;
            participants.Add(user.Id);
            ChatNotification += user.NotifyUser;
            return true;
        }

        protected bool removeUser(UserAccount user)
        {
            if (!participants.Contains(user.Id)) return false;
            participants.Remove(user.Id);
            ChatNotification -= user.NotifyUser;
            return true;
        }

        public void joinChat(UserAccount user) {
            if (opened) {
                addUser(user);
            }
        }

        public virtual void addParticipant(UserAccount user, int userId) { }
        public virtual void deleteParticipant(UserAccount user, int userId) { }

        public virtual void openChat(UserAccount user, bool open) { }

        public abstract bool sendMessage(UserAccount user, string messageBody);

        public abstract bool removeMessage(UserAccount user, int messageId);

        public virtual void clearHistory(UserAccount user) {
            messages.Clear();
        }

        public void showHistory() {
            messages.ForEach(msg => msg.show());
        }

        protected virtual void OnDestroy()
        {
            ChatNotification?.Invoke(this, ChatEvents.delete);
        }
    }
}
