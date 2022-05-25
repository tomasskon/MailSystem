using System;
using System.Collections.Generic;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class CourierEntity : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual IList<CourierPasswordEntity> CourierPasswords { get; set; }
    }

    public class CourierEntityMap : ClassMap<CourierEntity>
    {
        public CourierEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.FullName).Length(50).Not.Nullable();
            Map(x => x.Phone).Length(25).Not.Nullable();
            Map(x => x.Email).Length(25).Not.Nullable();
            Table("couriers");
        }
    }
}
