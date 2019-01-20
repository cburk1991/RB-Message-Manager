namespace RBMessageManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public long ID { get; set; }

        public long MessageTypeID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Text { get; set; }

        public long? DateCreated { get; set; }

        public virtual MessageType MessageType { get; set; }

        
    }
}
