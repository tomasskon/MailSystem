using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace MailSystem.Repositories.Entities
{
    public class CourierEntity : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }
        
        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }
        
        public virtual DateTime? DeletedAt { get; set; }
    }

    public class CourierEntityMap : ClassMap<CourierEntity>
    {
        public CourierEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.FullName).Length(50).Not.Nullable();
            Map(x => x.Phone).Length(25).Not.Nullable();
            Map(x => x.Email).Length(50).Not.Nullable();
            Map(x => x.CreatedAt).CustomType<UtcDateTimeType>();
            Map(x => x.UpdatedAt).CustomType<UtcDateTimeType>();
            Map(x => x.DeletedAt).CustomType<UtcDateTimeType>().Nullable();
            Table("couriers");
        }
    }
}