using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class CourierPasswordEntity : Entity
    {        
        public virtual Guid Id { get; set; }
        
        public virtual CourierEntity Courier { get; set; }
        
        public virtual string PasswordHash { get; set; }
        
        public virtual byte[] PasswordSalt { get; set; }
    }

    public class CourierPasswordEntityMap : ClassMap<CourierPasswordEntity>
    {
        public CourierPasswordEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            References(x => x.Courier).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.PasswordSalt).Not.Nullable();
            Table("courierpasswords");
        }
    }
}