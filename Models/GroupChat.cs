using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class GroupChat : Chat {
        protected string name;
        protected int admin;

        public delegate void EventHandler(Object sender, string message);
        public event EventHandler ParticipantsChanged;

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

        public GroupChat() : base() {
            name = "GroupChat";
            admin = -1;
        }

        public GroupChat(int userId, string name) : base() {
            this.name = name;
            admin = userId;
        }

        public GroupChat(GroupChat from) : base(from) {
            name = from.name;
            admin = from.admin;
        }

        public override void addParticipant(UserAccount user, int userId) {
            if (user.Id == admin) {
                UserAccount userToAdd = UserAccount.findUser(userId);
                if (userToAdd == null || !addUser(userToAdd)) return;
                ParticipantsChanged?.Invoke(this, "Add participant " + userToAdd.Username);
            }
        }

        public override void openChat(UserAccount user, bool open) {
            if (user.Id == admin) {
                opened = open;
            }
        }

        public override void deleteParticipant(UserAccount user, int userId) {
            if (user.Id == admin) {
                UserAccount userToAdd = UserAccount.findUser(userId);
                if (userToAdd == null || !removeUser(userToAdd)) return;
                ParticipantsChanged?.Invoke(this, "Delete participant " + userToAdd.Username);
            }
        }

        public override bool sendMessage(UserAccount user, string messageBody) {
            IMessage message = new TextMessage(user.Id, messageBody);
            messages.Add(message);
            base.sendMessage(user, messageBody);
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