using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SentMail
    {
        [Key]
        public int SentMailId { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
    }
}

