using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message {
		public static Message[] messages = new Message[100];
		public static int _nextMessageId = 0;

		public int id;
		public string body;
		public int authorId;
		public DateTime datetime;

		public Message() {
			this.id = Message._nextMessageId++;
			this.body = "It's first message to say hello to you";
			this.authorId = -1;
			this.datetime = DateTime.UtcNow;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor default");
		}

		public Message(int author, string body) {
			this.id = Message._nextMessageId++;
			this.body = body;
			this.authorId = author;
			this.datetime = DateTime.UtcNow;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor initialization");
		}

		public Message(Message savedMessage) {
			this.id = savedMessage.id;
			this.body = savedMessage.body;
			this.authorId = savedMessage.authorId;
			this.datetime = savedMessage.datetime;
			Message.messages[this.id] = this;
			Console.WriteLine("Message created constructor copy");
		}
	}
}
