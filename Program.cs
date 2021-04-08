using System;

namespace Messenger {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Messenger");
            Console.WriteLine("Version: 1");
            Console.WriteLine("Authors: Grybenko Yegor, Sukhanova Maria, Trembach Anastasia");
            Console.WriteLine("Group: IP-93");
            Console.WriteLine("Brigade: 3");
            Console.WriteLine("");
            Console.WriteLine("Modeling start");
            Console.WriteLine("");

            UserAccount admin = new UserAccount("System", "admin");

            Console.WriteLine("Upcast, downcast");

            Console.WriteLine("");

            GroupChat up = new Channel(admin.Id, "Channel1");

            Console.WriteLine("GroupChat up = new Channel();");

            Chat up2 = up;

            Console.WriteLine("Chat up2 = up;");
            Console.WriteLine("up2 => " + up2);

            GroupChat down = (GroupChat)up2;

            Console.WriteLine("GroupChat down = (GroupChat)up2;");

            Channel down2 = (Channel)up2;

            Console.WriteLine("Channel down2 = (Channel)up2;");
            Console.WriteLine("down2 => " + up2);

            Console.WriteLine("");

            Console.WriteLine("Modeling end");

            Console.ReadKey();
        }
    }
}
