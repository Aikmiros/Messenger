using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class UserAccount {

        public static UserAccount[] users = new UserAccount[100];
        public static int _nextUserId = 0;

        public int id;
        public string username;
        public string password;
        public string status;
        public List<int> chatRooms;
        
        public UserAccount() {
            this.id = UserAccount._nextUserId++;
            this.username = "User" + this.id;
            this.password = "User" + this.id;
            this.status = "";
            this.chatRooms = new List<int>();
            UserAccount.users[this.id] = this;
            Console.WriteLine("UserAccount created constructor default");
        }

        public UserAccount(string username, string password) {
            this.username = username;
            this.password = password;
            this.status = "";
            this.id = UserAccount._nextUserId++;
            this.chatRooms = new List<int>();
            UserAccount.users[this.id] = this;
            createChatRoom();
            Console.WriteLine("UserAccount created constructor inizialization");
        }

        public UserAccount(UserAccount oldUser) {
            this.username = oldUser.username;
            this.password = oldUser.password;
            this.status = oldUser.status;
            this.id = oldUser.id;
            this.chatRooms = oldUser.chatRooms;
            UserAccount.users[this.id] = this;
            Console.WriteLine("UserAccount created constructor copy");
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
