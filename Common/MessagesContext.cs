using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBMessageManager.Model;

namespace RBMessageManager.Common
{
    static class MessagesContext
    {
        private static MessageModel _context;
        public static MessageModel context
        {
            get
            {
                return _context ?? (_context = new MessageModel());
            }
        }
    }
}
