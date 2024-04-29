using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL.Entities
{
    [Table("Account")]
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UID { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Project> CreatedProjects { get; set; }
        public ICollection<Project> CollaborationProjects { get; set; }


        public Account()
        {
            CreatedAt = DateTime.UtcNow;
            CreatedProjects = new List<Project>();
            CollaborationProjects = new List<Project>();
        }
    }
}
