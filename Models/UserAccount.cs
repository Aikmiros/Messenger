using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class UserAccount {

        private static UserAccount[] users = new UserAccount[100];
        private static int _nextUserId = 0;

        private int id;
        private string username;
        private string password;
        private string status;
        private int[] chatRooms;
        
        public UserAccount() {
            this.id = UserAccount._nextUserId++;
            this.username = "User" + this.id;
            this.password = "User" + this.id;
            this.status = "";
            this.chatRooms = new int[100];
            UserAccount.users[this.id] = this;
            Console.WriteLine("UserAccount created constructor default");
        }

        public UserAccount(string username, string password) {
            this.username = username;
            this.password = password;
            this.status = "";
            this.id = UserAccount._nextUserId++;
            this.chatRooms = new int[100];
            UserAccount.users[this.id] = this;
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

        public static void login(string username, string password) { }

        private void deleteUser() { }
        private void showChatRooms() { }
        private void showUserInfo() { }
        private void changePassword(string newPassword) { }
        private void changeUsername(string newUsername) { }
        private void changeStatus(string newStatus) { }
    }
}
