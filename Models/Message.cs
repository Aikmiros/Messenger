using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message {
		public static Message[] messages = new Message[100];
		public static int _nextMessageId = 0;

		public int id;
		public string body;
		public string author;
		public DateTime datetime;

		public Message() {
			this.id = Message._nextMessageId++;
			this.body = "";
			this.author = "Author: " + UserAccount.username;
			this.datetime = DateTime.UtcNow;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor default");
		}

		public Message(string author) {
			this.id = Message._nextMessageId++;
			this.body = "";
			this.author = author;
			this.datetime = DateTime.UtcNow;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor initialization");
		}

		public Message(Message savedMessage) {
			this.id = savedMessage.id;
			this.body = savedMessage.body;
			this.author = savedMessage.author;
			this.datetime = DateTime.UtcNow;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor copy");
		}
	}
}
