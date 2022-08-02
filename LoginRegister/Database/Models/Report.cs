using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.Database.Models
{
    public class Report
    {
        private static int IdCounter = 1;
        public int Id { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public User Target { get; set; }
        
        public Report(User sender, string text,User target)
        {
            Id = IdCounter++;
            Sender = sender;
            Text = text;
            Sent = DateTime.Now;
            Target = target;
        }
    }
}
