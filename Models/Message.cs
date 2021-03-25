using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message {
		private string body;
		private int authorId;
		private DateTime datetime;

		public string Body
		{
			get { return body; }
			set
			{
				if (value == "") Console.WriteLine("У повiдомлення вiдсутнiй текст");
				else body = value;
			}
		}

		public int AuthorId 
		{ 
			get { return authorId; }
			set 
			{ 
				if (value >= 0) authorId = value;
				else Console.WriteLine("Автора повiдомлення не iснує");
			}
		}

		public DateTime Datetime { get; }

		public Message() {
			body = "It's first message to say hello to you";
			authorId = 0;
			datetime = DateTime.UtcNow;
			//Console.WriteLine("Message created constructor default");
		}

		public Message(int author, string body) {
			this.body = body;
			authorId = author;
			datetime = DateTime.UtcNow;
			//Console.WriteLine("Message created constructor initialization");
		}

		public Message(Message savedMessage) {
			body = savedMessage.body;
			authorId = savedMessage.authorId;
			datetime = savedMessage.datetime;
			//Console.WriteLine("Message created constructor copy");
		}

		public void show() {
			Console.WriteLine(UserAccount.findUser(authorId).Username + "  " + datetime);
			Console.WriteLine(body);
		}
	}
}
