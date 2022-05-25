using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class UserPasswordEntity : Entity
    {        
        public virtual Guid Id { get; set; }
        
        public virtual UserEntity User { get; set; }
        
        public virtual string PasswordHash { get; set; }
        
        public virtual byte[] PasswordSalt { get; set; }
    }

    public class UserPasswordEntityMap : ClassMap<UserPasswordEntity>
    {
        public UserPasswordEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            References(x => x.User).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.PasswordSalt).Not.Nullable();
            Table("userpasswords");
        }
    }
}