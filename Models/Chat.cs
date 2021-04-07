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

        public virtual List<int> Participants { get; }

        public List<Message> Messages
        {
            get { return messages; }
        }

        //public Chat()
        //{
        //    id = _nextRoomId++;
        //    chatRooms[id] = this;
        //    messages = new List<Message>();
        //    participants = new List<int>();
        //    messages.Add(new Message());
        //}

        //public Chat(int userId, string name)
        public Chat()
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

        //Метод, в который передаём пользователя, который хочет отправить сообщение и само сообщение,
        //проверяем есть ли у пользователя разрешение его отправить(например, в канале только автор может это делать),
        //создаем сообщение и возвращаем положительный/отрицательный результат
        public abstract bool sendMessage(UserAccount user, string messageBody);

        //То же самое с удалением
        public abstract bool removeMessage(UserAccount user, int messageId);

        //Тоже проверяем, кто хочет очистить историю(GroupChat, channel - админ, PersonalMessages - не проверяем)
        public abstract void clearHistory(UserAccount user);

        public void showHistory()
        {
            messages.ForEach(msg => msg.show());
        }

    }
}
