using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool UsePhoneNumber { get; set; }
        public bool UseEmailAddress { get; set; }
        public DateTime MemeTime { get; set; }
        
        //[NotMapped]
        //public IEnumerable<CustomMessage> CustomMessages { get; set; }
        //public int MemeAmount { get; set; }
        //public virtual ICollection<Meme> SeenMemes { get; set; }
    }
}
