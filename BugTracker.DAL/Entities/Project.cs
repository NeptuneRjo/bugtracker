using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL.Entities
{
    public enum ProjectStatus
    {
        Active,
        Abandoned,
        Closed
    }

    [Table("Projects")]
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Labels { get; set; }
        public ProjectStatus Status { get; set; }
        
        public Account Creator { get; set; }
        public int CreatorId { get; set; }

        public ICollection<Account> Collaborators { get; set; }
        
        public Project()
        {
            Issues = new List<Issue>();
            CreatedAt = DateTime.UtcNow;
            Collaborators = new List<Account>();

            // Set the default labels
            Labels = new List<string>()
            {
                "Bug",
                "Feature",
                "Documentation",
                "Needs Investigation",
                "Question",
                "Help Wanted"
            };

            Status = ProjectStatus.Active;
        }
    }
}
