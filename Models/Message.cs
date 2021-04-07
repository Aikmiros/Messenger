using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
	public class Message
	{
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

		//Унарні оператори
		public static bool operator !(Message A)
		{
			return A.body.Length == 0;
		}

		public static Message operator ++(Message A)
        {
			if (A.authorId <= 0) A.authorId++;
			return A;
        }

		public static Message operator --(Message A)
        {
			if (A.authorId > 0) A.authorId--;
			return A;
        }
		//Бінарні оператори
		public static Message operator +(Message A, string body)
		{
			A.body += body;
			return A;
		}

		public static Message operator +(Message A, Message B)
        {
			Message C = new Message();
			C.body = A.body + B.body;
			return C;
        }
	
		//Оператори порівняння
		public static bool operator >(Message A, Message B)
		{
			if (A.body.Length > B.body.Length) return true;
			else return false;
		}
		public static bool operator <(Message A, Message B)
		{
			if (A.body.Length < B.body.Length) return true;
			else return false;
		}

		public static bool operator ==(Message A, Message B)
		{
			if (A.body == B.body) return true;
			else return false;
		}
		public static bool operator !=(Message A, Message B)
		{
			if (A.body != B.body) return true;
			else return false;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Message))
				return false;
			else return body == ((Message)obj).body;
		}
		public override int GetHashCode()
		{
			return body.GetHashCode();
		}
		public void show() {
			Console.WriteLine(UserAccount.findUser(authorId).Username + "  " + datetime);
			Console.WriteLine(body);
		}
	}
}
