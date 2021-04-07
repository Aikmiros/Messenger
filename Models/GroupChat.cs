using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger {
    public class GroupChat : Chat
    {
        public GroupChat()
        {
        }

        public GroupChat(int userId, string name) : base(userId, name)
        {
        }

        internal void addParticipant(int id)
        {
            throw new NotImplementedException();
        }

        internal void deleteParticipant(int id)
        {
            throw new NotImplementedException();
        }
    }
}
