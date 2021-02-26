using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class User {

        public static User[] users;
        public static int _nextUserId;

        public int id;
        public string username;
        public string password;
        public string status;
        public int[] chatRooms;

        public static void createUser(string username, string password) { }
        public static void login(string username, string password) { }

        public void deleteUser() { }
        public void showChatRooms() { }
        public void showUserInfo() { }
        public void changePassword(string newPassword) { }
        public void changeUsername(string newUsername) { }
        public void changeStatus(string newStatus) { }
    }
}
