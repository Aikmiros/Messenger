using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger
{
    public class Channel : GroupChat
    {
        public Channel(int userId, string name) : base(userId, name) { }
        public override bool sendMessage(UserAccount user, string messageBody)
        {
            if (user.Id == admin)
            {
                IMessage message = new TextMessage(user.Id, messageBody);
                messages.Add(message);
                return true;
            }
            else return false;
        }
        public override bool removeMessage(UserAccount user, int messageId)
        {
            if (user.Id == admin)
            {
                messages.RemoveAt(messageId);
                return true;
            }
            else return false;
        }
    }
}
