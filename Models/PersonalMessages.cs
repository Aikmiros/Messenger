using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Models
{
    class PersonalMessages : Chat
    {
        public override List<int> Participants
        {
            get { return Participants; }
            set
            {
                if (Participants.Count == 2) 
                {
                    Participants = value;
                }

            }
        }
        public override void openChat(UserAccount user, bool open)
        {
            opened = false;
        }
        public override bool sendMessage(UserAccount user, string messageBody)
        {
            IMessage message = new TextMessage(user.Id, messageBody);
            messages.Add(message);
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
