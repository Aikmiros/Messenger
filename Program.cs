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


            UserAccount user = new UserAccount();
            UserAccount user2 = new UserAccount();
            GroupChat chat = new GroupChat();

            Chat upChannel = new Channel(user.Id, "upcast channel");
            Chat upPersonal = new PersonalMessages(user, user2);
            IMessage upMessage = new TextMessage(user.Id, "upcast text message");

            Console.WriteLine("");
            Console.WriteLine("Upcast, downcast using operator as");
            Console.WriteLine("Upcast");
            Console.WriteLine(upChannel.GetType());
            Console.WriteLine(upPersonal.GetType());

            Console.WriteLine("");
            Console.WriteLine("Downcast");
            Chat downChannel = upChannel as GroupChat;
            if (downChannel != null) Console.WriteLine("Success downcast from Channel to GroupChat");
            Chat downGroupChat = downChannel as Chat;
            if (downGroupChat != null) Console.WriteLine("Success downcast from GroupChat to Chat");
            Chat downPersonal = upPersonal as Chat;
            if (downPersonal != null) Console.WriteLine("Success downcast from PersonalMessages to Chat");

            Console.WriteLine("");
            Console.WriteLine("Modeling end");
            Console.ReadKey();
        }
    }
}
