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
        
        public virtual ShipmentEntity Shipment { get; set; }
        
        public virtual MailboxEntity Mailbox { get; set; }
        
        public virtual DateTime EventDate { get; set; }
        
        public virtual ShipmentStatus ShipmentStatus { get; set; }
    }

    public class ShipmentEventMap : ClassMap<ShipmentEventEntity>
    {
        public ShipmentEventMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            References(x => x.Shipment).Not.Nullable();
            References(x => x.Mailbox).Nullable();
            Map(x => x.EventDate).CustomType<UtcDateTimeType>().Not.Nullable();
            Map(x => x.ShipmentStatus).CustomType<ShipmentStatus>().Not.Nullable();
            Table("shipmentevents");
        }
    }
}