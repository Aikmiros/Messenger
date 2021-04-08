using System;

namespace Messenger {
    interface IMessage {
        string Body { get; set; }
        int AuthorId { get; set; }
        DateTime Datetime { get; }

        void show() {
            Console.WriteLine("Message");
        }
    }
}
