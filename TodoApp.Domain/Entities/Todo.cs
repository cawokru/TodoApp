using System;
using TodoApp.Domain.Common;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities
{
    public class Todo : IUniqableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public PriorityLevel Priority { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
