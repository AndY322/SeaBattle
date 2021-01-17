using DomainModel.Models.Identity;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings.Identity
{
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            Table("AspNetUserLogins");
            LazyLoad();

            CompositeId()
                .KeyProperty(i => i.LoginProvider, "LoginProvider")
                .KeyProperty(i => i.ProviderKey, "ProviderKey");

            Map(i => i.ProviderDisplayName)
                .Nullable();

            References(i => i.User)
                .Column("UserId")
                .Not.Nullable();
        }
    }
}