using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBMessageManager.Model;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.Linq;
using RBMessageManager.Common;

namespace RBMessageManager
{
    public class SQLiteHelpers
    {
        public SQLiteHelpers()
        { }

        /// <summary>
        /// Inserts requested item into the corresponding table
        /// </summary>
        /// <param></param>
        public bool AddItem<T>(T item)
        {
            // check validity
            if (item == null)
                return false;
            // verify connection exists, else make new database

            // add item
            var itemType = item.GetType();
            if(itemType == typeof(Message))
            {
                MessagesContext.context.Messages.Add(item as Message);
            }
            else if(itemType == typeof(MessageType))
            {
                MessagesContext.context.MessageTypes.Add(item as MessageType);
            }

            if (MessagesContext.context.ChangeTracker.HasChanges())
            {
                MessagesContext.context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the existing item in the database with the new item provided.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateMessage(Message item)
        {

            if (item != null)
            {
                if (MessagesContext.context.Messages.Any(x => x.ID == item.ID)) //Item does exist
                {
                    var oldRow = MessagesContext.context.Messages.Where(x => x.ID == item.ID).FirstOrDefault();
                    var rowToUpdate = MessagesContext.context.Entry(oldRow);
                    rowToUpdate.Entity.Text = item.Text;
                    rowToUpdate.Entity.MessageType = item.MessageType;
                    rowToUpdate.State = System.Data.Entity.EntityState.Modified;

                    MessagesContext.context.SaveChanges();
                    return true;
                }
                else
                {
                    AddItem(item); // Item must be added
                    return true;
                }
            }
            return false;
        }

        public void DeleteMessage(Message item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks to see if the database exists.
        /// </summary>
        /// <returns>True if predefined database exists and connection can be made, false otherwise.</returns>
        private bool VerifyConnection()
        {
            if (System.IO.File.Exists(MessagesContext.context.Database.Connection.ConnectionString))
                return true;
            return false;
        }

        /// <summary>
        /// Calls the appropriate function to create and save a predefined database
        /// </summary>
        /// <returns>True if the database was created, false if it already existed.</returns>
        //public bool CreateIfNotExists()
        //{
        //    return context.Database.CreateIfNotExists();
        //}    }
    }
}