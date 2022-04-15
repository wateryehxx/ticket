using System;
using System.Collections.Generic;

namespace DbContext.Ticket.Tables
{
    public partial class Issue
    {
        public Issue()
        {
            IssueHistories = new HashSet<IssueHistory>();
        }

        public Guid IssueId { get; set; }
        public Guid UserId { get; set; }
        public int IssueStatusId { get; set; }
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;

        public virtual IssueStatus IssueStatus { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<IssueHistory> IssueHistories { get; set; }
    }
}
