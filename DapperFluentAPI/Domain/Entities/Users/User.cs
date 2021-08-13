using System;

namespace DapperFluentAPI.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public DateTime CreationDate { get; }
        public DateTime? LastModificationDate { get; private set; }
    }
}
