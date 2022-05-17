﻿using System;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace MailSystem.Repositories.Entities
{
    public class UserEntity : Entity
    {
        public virtual Guid Id { get; set; }
        
        public virtual string Username { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        public virtual bool IsDisabled { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual DateTime DeletedAt { get; set; }
    }

    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Username).Length(50).Not.Nullable();
            Map(x => x.FullName).Length(50).Not.Nullable();
            Map(x => x.Phone).Length(50).Not.Nullable();
            Map(x => x.Email).Length(50).Not.Nullable();
            Map(x => x.IsDisabled);
            Map(x => x.CreatedAt).CustomType<UtcDateTimeType>(); ;
            Map(x => x.UpdatedAt).CustomType<UtcDateTimeType>(); ;
            Map(x => x.DeletedAt).CustomType<UtcDateTimeType>(); ;
            Table("users");
        }
    }
}