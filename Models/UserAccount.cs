using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger {
    public class UserAccount {

        private static UserAccount[] users = new UserAccount[100];
        private static int _nextUserId = 0;

        private int id;
        private string username;
        private string password;
        private string status;
        private int rank;
        public List<int> GroupChats;

        public int Id {
            get { return id; }
        }

        public int Rank {
            get { return rank; }
            set { rank = value; }
        }

        public string Username {
            get { return username; }
            set {
                if (value.Length > 2) username = value;
                else Console.WriteLine("Довжина iменi має бути не менше трьох символiв");
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
        
        // constructor default
        public UserAccount() {
            id = _nextUserId++;
            username = "User" + id;
            password = "User" + id;
            rank = 0;
            status = "";
            GroupChats = new List<int>();
            users[id] = this;
            //Console.WriteLine("UserAccount created constructor default");
        }

        // constructor inizialization
        public UserAccount(string username, string password) {
            this.username = username;
            this.password = password;
            rank = 0;
            status = "";
            id = _nextUserId++;
            GroupChats = new List<int>();
            users[id] = this;
            createGroupChat("Hello world");
            //Console.WriteLine("UserAccount created constructor inizialization");
        }

        // constructor copy
        public UserAccount(UserAccount oldUser) {
            username = oldUser.username;
            password = oldUser.password;
            status = oldUser.status;
            id = oldUser.id;
            rank = oldUser.rank;
            GroupChats = oldUser.GroupChats;
            users[id] = this;
            //Console.WriteLine("UserAccount created constructor copy");
        }

        public static UserAccount findUser(int id) {
            return users[id];
        }

        public void createGroupChat(string name) {
            GroupChat chat = new GroupChat(id, name);
            GroupChats.Add(chat.Id);
        }


        //Унарні оператори
        public static UserAccount operator ++(UserAccount user) {
            if(user.rank < 10) user.rank++;
            return user;
        }

        public static UserAccount operator --(UserAccount user) {
            if (user.rank > 0) user.rank--;
            return user;
        }

        //Бінарні оператори
        public static UserAccount operator+ (UserAccount user, string status) {
            user.Status += status;
            return user;
        }

        public static UserAccount operator+ (UserAccount user, GroupChat chat) {
            chat.addParticipant(user, user.id);
            user.GroupChats.Add(chat.Id);
            return user;
        }

        public static UserAccount operator- (UserAccount user, GroupChat chat) {
            chat.deleteParticipant(user, user.id);
            user.GroupChats.Remove(chat.Id);
            return user;
        }

        //Логічні оператори
        public static bool operator <(UserAccount user1, UserAccount user2) {
            if (user1.rank < user2.rank) return true;
            else return false;
        }

        public static bool operator >(UserAccount user1, UserAccount user2) {
            if (user1.rank > user2.rank) return true;
            else return false;
        }


        public static void login(string username, string password) { }

        public void deleteUser() { }
        public void showGroupChats() { }
        public void showUserInfo() { }
        public void changePassword(string newPassword) { }
        public void changeUsername(string newUsername) { }
        public void changeStatus(string newStatus) { }
    }
}
