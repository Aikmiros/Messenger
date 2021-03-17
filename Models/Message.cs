using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message {
		public string body;
		public int authorId;
		public DateTime datetime;

		public Message() {
			this.body = "It's first message to say hello to you";
			this.authorId = -1;
			this.datetime = DateTime.UtcNow;
			Console.WriteLine("Message created constructor default");
		}

		public Message(int author, string body) {
			this.body = body;
			this.authorId = author;
			this.datetime = DateTime.UtcNow;
			Console.WriteLine("Message created constructor initialization");
		}

		public Message(Message savedMessage) {
			this.body = savedMessage.body;
			this.authorId = savedMessage.authorId;
			this.datetime = savedMessage.datetime;
			Console.WriteLine("Message created constructor copy");
		}
	}
}
