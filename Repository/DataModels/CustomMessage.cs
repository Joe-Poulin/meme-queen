using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataModels
{
    public class CustomMessage
    {
        public int Id { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string MessageText { get; set; }
        public DateTime Date { get; set; }
        public CustomMessageType CustomMessageType { get; set; }
    }
}
