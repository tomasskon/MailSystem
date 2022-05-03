using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class UserEntity : Entity
    {
        public virtual Guid Id { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual string Surname { get; set; }
    }

    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name).Length(60);
            Map(x => x.Surname).Length(60);
            Table("users");
        }
    }
}