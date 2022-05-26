using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace MailSystem.Repositories.Entities
{
    public class MailboxEntity : Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string Location { get; set; }
        
        public class MailboxEntityMap : ClassMap<MailboxEntity>
        {
            public MailboxEntityMap()
            {
                Id(x => x.Id).GeneratedBy.Guid();
                Map(x => x.Location).Length(255).Not.Nullable();
                Table("mailboxes");
            }
        }
        
    }
}