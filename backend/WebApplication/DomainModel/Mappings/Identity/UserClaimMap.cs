using DomainModel.Models.Identity;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings.Identity
{
    public class UserClaimMap : ClassMap<UserClaim>
    {
        public UserClaimMap()
        {
            Table("AspNetUserClaims");
            LazyLoad();

            Id(i => i.Id)
                .Column("Id")
                .Length(450)
                .Not.Nullable();
            
            Map(i => i.ClaimType)
                .Nullable();

            Map(i => i.ClaimValue)
                .Nullable();

            References(i => i.User)
                .Column("UserId")
                .Not.Nullable();

            Map(x => x.UserId).Formula("UserId");
        }
    }
}