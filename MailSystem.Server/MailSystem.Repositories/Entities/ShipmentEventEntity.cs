using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;
using MailSystem.Domain.Enums;
using NHibernate.Type;

namespace MailSystem.Repositories.Entities
{
    public class ShipmentEventEntity : Entity
    {
        public virtual Guid Id { get; set; }
        
        public virtual string TrackingId { get; set; }
        
        public virtual MailboxEntity Mailbox { get; set; }
        
        public virtual DateTime EventDate { get; set; }
        
        public virtual ShipmentStatus ShipmentStatus { get; set; }
    }

    public class ShipmentEventMap : ClassMap<ShipmentEventEntity>
    {
        public ShipmentEventMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.TrackingId).Length(255).Not.Nullable();
            References(x => x.Mailbox).Nullable();
            Map(x => x.EventDate).CustomType<UtcDateTimeType>().Not.Nullable();
            Map(x => x.ShipmentStatus).CustomType<ShipmentStatus>().Not.Nullable();
            Table("shipmentevents");
        }
    }
}