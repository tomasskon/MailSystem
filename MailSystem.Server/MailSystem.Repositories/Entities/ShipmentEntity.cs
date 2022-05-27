using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class ShipmentEntity : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual UserEntity User { get; set; }
        
        public virtual string TrackingId { get; set; }
        
        public virtual string Description { get; set; }
        
        public virtual string ReceiverFullName { get; set; }
        
        public virtual string ReceiverEmail { get; set; }
        
        public virtual string ReceiverPhoneNumber { get; set; }
        
        public virtual MailboxEntity MailBox { get; set; }
        
        public virtual ShipmentSizeEntity ShipmentSize { get; set; }
    }

    public class ShipmentEntityMap : ClassMap<ShipmentEntity>
    {
        public ShipmentEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            References(x => x.User).Not.Nullable();
            Map(x => x.TrackingId).Length(255).Not.Nullable();
            Map(x => x.Description).Length(150).Nullable();
            Map(x => x.ReceiverFullName).Length(50).Not.Nullable();
            Map(x => x.ReceiverEmail).Length(50).Not.Nullable();
            Map(x => x.ReceiverPhoneNumber).Length(15).Not.Nullable();
            References(x => x.MailBox).Not.Nullable();
            References(x => x.ShipmentSize).Not.Nullable();
            Table("shipments");
        }
    }
}