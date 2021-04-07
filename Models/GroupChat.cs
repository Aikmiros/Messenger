using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class GroupChat : Chat
    {
        protected string name;
        protected int admin;

        public string Name {
            get { return name; }
            set {
                if (value.Length >= 3 && value.Length < 30) name = value;
                else Console.WriteLine("Довжина назви чату має бути вiд 3 до 30 символiв");
            }
        }

        public int Admin {
            get { return admin; }
            set {
                if (value >= 0) admin = value;
                else Console.WriteLine("Xибний iдентифiкатор користувача");
            }
        }

        public override List<int> Participants {
            get { return participants; }
        }


        public GroupChat(int userId, string name) : base() {
            this.name = name;
            admin = userId;
        }

        public GroupChat(GroupChat from) : base(from) {
            name = from.name;
            admin = from.admin;
        }

        public void addParticipant(int userId) {
            if (!participants.Contains(userId)) {
                participants.Add(userId);
            }
        }
        public void deleteParticipant(int userId) {
            participants.Remove(userId);
        }

        public override bool sendMessage(UserAccount user, string messageBody) {
            Message message = new Message(user.Id, messageBody);
            messages.Add(message);
            return true;
        }

        public override bool removeMessage(UserAccount user, int messageId) {
            if (user.Id == messages[messageId].AuthorId || user.Id == admin) {
                messages.RemoveAt(messageId);
                return true;
            } else return false;
        }

        public override sealed void clearHistory(UserAccount user) {
            if (user.Id == admin) messages.Clear();
        }

    }
}
