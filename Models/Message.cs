using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message {
		public string body;
		public int authorId;
		public DateTime datetime;

		public Message() {
			body = "It's first message to say hello to you";
			authorId = -1;
			datetime = DateTime.UtcNow;
			Console.WriteLine("Message created constructor default");
		}

		public Message(int author, string body) {
			this.body = body;
			authorId = author;
			datetime = DateTime.UtcNow;
			Console.WriteLine("Message created constructor initialization");
		}

		public Message(Message savedMessage) {
			body = savedMessage.body;
			authorId = savedMessage.authorId;
			datetime = savedMessage.datetime;
			Console.WriteLine("Message created constructor copy");
		}
	}
}
