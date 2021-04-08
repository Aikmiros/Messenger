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

        public int Id { get { return id; } }
        public bool Opened { get; }

        public virtual List<int> Participants { get; set; }

        internal List<IMessage> Messages {
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
            messages = new List<IMessage>();
            participants = new List<int>();
            chatRooms[id] = this;
            opened = false;
        }

        public Chat(Chat from) {
            id = _nextRoomId++;
            participants = from.Participants.Count == 0 ? new List<int>() : new List<int>(from.Participants);
            messages = new List<IMessage>();
            chatRooms[id] = this;
            opened = false;
        }

        public static void deleteRoom(int id) {
            chatRooms[id] = null;
        }

        public static Chat FindChat(int id) {
            if (id >= 0 && id < _nextRoomId){
                return chatRooms[id];
            }
            else return null;
        }

        public void joinChat(UserAccount user) {
            if (opened) {
                participants.Add(user.Id);
            }
        }

        //Следующие методы при надобности перезаписвыаем

        //Первый аргумент - пользователь, который хочет добавить другого пользователя
        //В методе проверяем, есть ли у него право это сделать а потом добавляем пользователя если права есть
        //(GroupChat, Channel - добавлять может только админ, PersonalMessages  - никто)
        public virtual void addParticipant(UserAccount user, int userId) { }
        public virtual void deleteParticipant(UserAccount user, int userId) { }

        //Управление доступом к чату. Если чат открыт, в него можно входить с помощью joinChat()
        //Открывает чат в GroupChat и Channel админ, в PersonalMessages - никто
        public virtual void openChat(UserAccount user, bool open) { }

        //Метод, в который передаём пользователя, который хочет отправить сообщение и само сообщение,
        //проверяем есть ли у пользователя разрешение его отправить(например, в канале только автор может это делать), и создаем сообщение
        public abstract bool sendMessage(UserAccount user, string messageBody);

        //То же самое с удалением
        public abstract bool removeMessage(UserAccount user, int messageId);

        //Тоже проверяем, кто хочет очистить историю(GroupChat, channel - админ, PersonalMessages - не проверяем)
        public virtual void clearHistory(UserAccount user) {
            messages.Clear();
        }

        public void showHistory() {
            messages.ForEach(msg => msg.show());
        }

    }
}
