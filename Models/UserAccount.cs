﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger
{
    public class UserAccount
    {

        private static UserAccount[] users = new UserAccount[100];
        private static int _nextUserId = 0;

        private int id;
        private string username;
        private string password;
        private string status;
        private int rank;
        public List<int> GroupChats;

        private readonly static UserAccount system = new UserAccount("System", "admin");

        public static UserAccount System
        {
            get { return system; }
        }

        public int Id
        {
            get { return id; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string Username
        {
            get { return username; }
            set {
                if (value.Length > 2) username = value;
                else Console.WriteLine("Довжина iменi має бути не менше трьох символiв");
            }
        }

        public string Password
        {
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

            _fields = new Dictionary<string, FieldDelegate> {
                {"username", (info) => this.username = info },
                {"password", (info) => this.password = info }
            };

            createGroupChat("Hello world");
        }


        public delegate void FieldDelegate(string info);
        public Dictionary<string, FieldDelegate> _fields;


        public void changeUserInfo(string field, string info) {
            if (!_fields.ContainsKey(field)) throw new ArgumentException();
            _fields[field](info);
        }

        public void addFieldToChange(string field, FieldDelegate body) {
            if (_fields.ContainsKey(field)) throw new ArgumentException();
            _fields.Add(field, body);
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
        }

        public static UserAccount findUser(int id) {
            if (id > users.Length || id < 0) throw new UserIdOutOfRangeException("User ID", id);
            if (users[id] == null) throw new UserFindException("User does not exist", id);
            return users[id];
        }

        public void createGroupChat(string name) {
            GroupChat chat = new GroupChat(id, name);
            GroupChats.Add(chat.Id);
        }


        //Унарні оператори
        public static UserAccount operator ++(UserAccount user) {
            if (user.rank < 10) user.rank++;
            return user;
        }

        public static UserAccount operator --(UserAccount user) {
            if (user.rank > 0) user.rank--;
            return user;
        }

        //Бінарні оператори
        public static UserAccount operator +(UserAccount user, string status) {
            user.Status += status;
            return user;
        }

        public static UserAccount operator +(UserAccount user, GroupChat chat) {
            chat.addParticipant(user, user.id);
            user.GroupChats.Add(chat.Id);
            return user;
        }

        public static UserAccount operator -(UserAccount user, GroupChat chat) {
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

        public static UserAccount login(string username, string password) {
            foreach (UserAccount u in users) {
                if (u == null) break;
                if (u.username == username) {
                    if (u.password != password) throw new Exception("Wrong password");
                    return u;
                }
            }
            throw new UserAuthException("User not found", username);
        }
        public static void deleteUser(int id) {
            if (id > users.Length || id < 0) throw new UserIdOutOfRangeException("User ID", id);
            if (users[id] == null) throw new UserFindException("User does not exist", id);
            users[id] = null;
        }

        public void showGroupChats() { }
        public void showUserInfo() { }

        public void NotifyUser(Chat chat, Chat.ChatEvents chatEvent) {
            if (chatEvent == Chat.ChatEvents.delete) {
                string chatName = chat is GroupChat ? ((GroupChat)chat).Name : "chat" + chat.Id;
                Console.WriteLine("Notification to user" + id + ": " + chatName + " was deleted");
            }
        }
    }

    public class UserIdOutOfRangeException : ArgumentOutOfRangeException
    {
        public int Id { get; }
        public UserIdOutOfRangeException(string message, int id) : base(message) {
            Id = id;
        }
    }

    public class UserFindException : NullReferenceException
    {
        public int Id { get; }
        public UserFindException(string message, int id) : base(message) {
            Id = id;
        }
    }

    public class UserAuthException : ArgumentException
    {
        public string Username { get; }
        public UserAuthException(string message, string username) : base(message) {
            Username = username;
        }
    }
}
