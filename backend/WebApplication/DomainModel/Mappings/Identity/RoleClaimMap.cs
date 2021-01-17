using DomainModel.Models.Identity;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings.Identity
{
    public class RoleClaimMap : ClassMap<RoleClaim>
    {
        public RoleClaimMap()
        {
            Table("AspNetRoleClaims");
            LazyLoad();

            Id(i => i.Id)
                .Column("Id")
                .Length(450)
                .Not.Nullable();

            Map(i => i.ClaimType)
                .Nullable();

            Map(i => i.ClaimValue)
                .Nullable();

            References(i => i.Role)
                .Column("RoleId");
        }
    }
}