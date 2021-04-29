using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger
{
    public class PersonalMessages : Chat
    {
        public PersonalMessages(UserAccount A, UserAccount B) : base()
        {
            participants.Add(A.Id);
            participants.Add(B.Id);
        }
        public override bool sendMessage(UserAccount user, string messageBody)
        {
            IMessage message = new TextMessage(user.Id, messageBody);
            messages.Add(message);
            base.sendMessage(user, messageBody);
            return true;
        }
        public override bool removeMessage(UserAccount user, int messageId)
        {
            if (user.Id == messages[messageId].AuthorId)
            {
                messages.RemoveAt(messageId);
                return true;
            }
            else return false;
        }
    }
}
