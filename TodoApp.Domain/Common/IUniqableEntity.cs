using System;

namespace TodoApp.Domain.Common
{
    interface IUniqableEntity
    {
        public Guid Id { get; set; }
    }
}
