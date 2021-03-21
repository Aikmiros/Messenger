using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class UserAccount {

        public static UserAccount[] users = new UserAccount[100];
        public static int _nextUserId = 0;

        private int id;
        private string username;
        private string password;
        private string status;
        private List<int> chatRooms;

        public int Id {
            get { return id; }
        }

        public string Username {
            get { return username; }
            set {
                if (value.Length > 2) username = value;
                else Console.WriteLine("Довжина iменi має бути не менше три символа");
            }
        }

        public string Password {
            get { return password; }
            set {
                if (value.Length < 6) Console.WriteLine("Довжина паролю має бути не менше 6 символiв");
                else if (value == username) Console.WriteLine("Пароль i iм'я не можуть бути однаковим");
                else password = value;
            }
        }

        //public string Status {
            //get { return status; }
            //set { status = value; }
        //}
        public string Status { get; set; }
        public List<int> ChatRooms { get; set; }


        // constructor default
        public UserAccount() {
            this.id = UserAccount._nextUserId++;
            this.username = "User" + this.id;
            this.password = "User" + this.id;
            this.status = "";
            this.chatRooms = new List<int>();
            UserAccount.users[this.id] = this;
            //Console.WriteLine("UserAccount created constructor default");
        }

        // constructor inizialization
        public UserAccount(string username, string password) {
            this.username = username;
            this.password = password;
            this.status = "";
            this.id = UserAccount._nextUserId++;
            this.chatRooms = new List<int>();
            UserAccount.users[this.id] = this;
            createChatRoom();
            //Console.WriteLine("UserAccount created constructor inizialization");
        }

        // constructor copy
        public UserAccount(UserAccount oldUser) {
            this.username = oldUser.username;
            this.password = oldUser.password;
            this.status = oldUser.status;
            this.id = oldUser.id;
            this.chatRooms = oldUser.chatRooms;
            UserAccount.users[this.id] = this;
            //Console.WriteLine("UserAccount created constructor copy");
        }

        public void createChatRoom() {
            ChatRoom chat = new ChatRoom();
            this.chatRooms.Add(chat.id);
        }

        public static void login(string username, string password) { }

        public void deleteUser() { }
        public void showChatRooms() { }
        public void showUserInfo() { }
        public void changePassword(string newPassword) { }
        public void changeUsername(string newUsername) { }
        public void changeStatus(string newStatus) { }
    }
}
