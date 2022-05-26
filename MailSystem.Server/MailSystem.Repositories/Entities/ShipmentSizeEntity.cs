using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class ShipmentSizeEntity : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Weight { get; set; }
        
        public virtual int Height { get; set; }
        
        public virtual int Width { get; set; }
        
        public virtual int Length { get; set; }
        
        public class ShipmentSizeEntityMap : ClassMap<ShipmentSizeEntity>
        {
            public ShipmentSizeEntityMap()
            {
                Id(x => x.Id).GeneratedBy.Guid();
                Map(x => x.Name).Length(50).Not.Nullable();
                Map(x => x.Weight).Not.Nullable();
                Map(x => x.Height).Not.Nullable();
                Map(x => x.Width).Not.Nullable();
                Map(x => x.Length).Not.Nullable();
                Table("shipmentsizes");
            }
        }
        
    }
}