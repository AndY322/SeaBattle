using DomainModel.Identity;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings.Identity
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(i => i.Id)
                .GeneratedBy.Assigned()
                .Length(450)
                .Not.Nullable();

            Map(i => i.Name)
                .Column("Name")
                .Nullable()
                .Unique()
                .Length(256);

            Map(i => i.NormalizedName)
                .Column("NormalizedName")
                .Nullable()
                .Length(256);

            Map(i => i.ConcurrencyStamp)
                .Column("ConcurrencyStamp")
                .Nullable();

            HasManyToMany(i => i.Users)
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Cascade.All()
                .Inverse()
                .Table("AspNetUserRoles");

            HasMany(i => i.RoleClaims)
                .Cascade.All()
                .KeyColumn("RoleId");

            Table("AspNetRoles");
            LazyLoad();
        }
    }
}