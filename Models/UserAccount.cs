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
                else Console.WriteLine("Довжина iменi має бути не менше трьох символів");
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

        public string Status { get; set; }
        public List<int> ChatRooms { get; set; }

        // constructor default
        public UserAccount() {
            id = UserAccount._nextUserId++;
            username = "User" + id;
            password = "User" + id;
            status = "";
            chatRooms = new List<int>();
            UserAccount.users[id] = this;
            //Console.WriteLine("UserAccount created constructor default");
        }

        // constructor inizialization
        public UserAccount(string username, string password) {
            this.username = username;
            this.password = password;
            status = "";
            id = UserAccount._nextUserId++;
            chatRooms = new List<int>();
            UserAccount.users[id] = this;
            createChatRoom();
            //Console.WriteLine("UserAccount created constructor inizialization");
        }

        // constructor copy
        public UserAccount(UserAccount oldUser) {
            username = oldUser.username;
            password = oldUser.password;
            status = oldUser.status;
            id = oldUser.id;
            chatRooms = oldUser.chatRooms;
            UserAccount.users[id] = this;
            //Console.WriteLine("UserAccount created constructor copy");
        }

        public void createChatRoom() {
            ChatRoom chat = new ChatRoom();
            chatRooms.Add(chat.Id);
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
