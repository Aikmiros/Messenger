using System;

namespace Messenger {
	public class TextMessage : IMessage
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

		public TextMessage() {
			body = "It's first message to say hello to you";
			authorId = 0;
			datetime = DateTime.UtcNow;
		}

		public TextMessage(int author, string body) {
			this.body = body;
			authorId = author;
			datetime = DateTime.UtcNow;
		}

		public TextMessage(TextMessage savedMessage) {
			body = savedMessage.body;
			authorId = savedMessage.authorId;
			datetime = savedMessage.datetime;
		}

		//Унарні оператори
		public static bool operator !(TextMessage A)
		{
			return A.body.Length == 0;
		}

		public static TextMessage operator ++(TextMessage A)
		{
			if (A.authorId <= 0) A.authorId++;
			return A;
		}

		public static TextMessage operator --(TextMessage A)
		{
			if (A.authorId > 0) A.authorId--;
			return A;
		}
		//Бінарні оператори
		public static TextMessage operator +(TextMessage A, string body)
		{
			A.body += body;
			return A;
		}

		public static TextMessage operator +(TextMessage A, TextMessage B)
		{
			TextMessage C = new TextMessage();
			C.body = A.body + B.body;
			return C;
		}
	
		//Оператори порівняння
		public static bool operator >(TextMessage A, TextMessage B)
		{
			if (A.body.Length > B.body.Length) return true;
			else return false;
		}
		public static bool operator <(TextMessage A, TextMessage B)
		{
			if (A.body.Length < B.body.Length) return true;
			else return false;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is TextMessage))
				return false;
			else return body == ((TextMessage)obj).body;
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
