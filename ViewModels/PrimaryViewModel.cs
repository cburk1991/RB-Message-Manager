using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBMessageManager.Model;
using RBMessageManager.Common;
using System.ComponentModel;

namespace RBMessageManager.ViewModels
{
    class PrimaryViewModel : ViewModelBase
    {
        private ObservableCollection<CompositeItem> _itemCollection;
        public ObservableCollection<CompositeItem> ItemCollection
        {
            get
            {
                if (_itemCollection == null)
                {
                    CompositeItem compositeItem = new CompositeItem();
                    List<Message> messagesList = new List<Message>();
                    ObservableCollection<MessageType> messageTypesList = new ObservableCollection<MessageType>();

                    _itemCollection = new ObservableCollection<CompositeItem>();

                    var types = (from t in MessagesContext.context.MessageTypes select t).ToList();
                    foreach (MessageType t in types)
                        messageTypesList.Add(t);

                    var messages = (from m in MessagesContext.context.Messages select m).ToList();
                    foreach (Message m in messages)
                        messagesList.Add(m);

                    for(int i = 0; i < messagesList.Count; i++)
                    {
                        compositeItem = new CompositeItem();
                        compositeItem.Message = messagesList[i];

                        if (messageTypesList.Count >= i)
                            compositeItem.MessageType = messageTypesList[i];
                        else
                            compositeItem.MessageType = null;

                        compositeItem.MessageTypesList = messageTypesList;
                        _itemCollection.Add(compositeItem);
                    }
                }
                return _itemCollection;
            }
            set
            {
                if (_itemCollection == value)
                    return;
                _itemCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MessageType> _messageTypeCollection;
        public ObservableCollection<MessageType> MessageTypeCollection
        {
            get
            {
                if(_messageTypeCollection == null)
                {
                    _messageTypeCollection = new ObservableCollection<MessageType>();
                    var types = (from t in MessagesContext.context.MessageTypes select t).ToList();
                    foreach (MessageType t in types)
                        _messageTypeCollection.Add(t);
                }
                return _messageTypeCollection;
            }
            set
            {
                if (_messageTypeCollection == value)
                    return;
                _messageTypeCollection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Message> _messageCollection;
        public ObservableCollection<Message> MessageCollection
        {
            get
            {
                if (_messageCollection == null)
                {
                    _messageCollection = new ObservableCollection<Message>();
                    var messages = (from m in MessagesContext.context.Messages select m).ToList();
                    foreach (Message m in messages)
                    {
                        _messageCollection.Add(m);
                    }
                }
                return _messageCollection;
            }
            set
            {
                if (_messageCollection == value)
                    return;
                _messageCollection = value;
                OnPropertyChanged();
            }
        }

    }

    class CompositeItem : RaisePropertyChanged
    {
        private Message _message;
        public Message Message
        {
            get => _message;
            set => SetField(ref _message, value);
        }
        public MessageType MessageType { get; set; }
        public ObservableCollection<MessageType> MessageTypesList { get; set; }
        public int NewType { get; set; }
    }
}
