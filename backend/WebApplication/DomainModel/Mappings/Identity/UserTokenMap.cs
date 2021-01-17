using DomainModel.Models.Identity;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings.Identity
{
    public class UserTokenMap : ClassMap<UserToken>
    {
        public UserTokenMap()
        {
            Table("AspNetUserTokens");
            LazyLoad();

            CompositeId()
                .KeyProperty(i => i.UserId, "UserId")
                .KeyProperty(i => i.LoginProvider, "LoginProvider")
                .KeyProperty(i => i.Name, "Name");

            Map(i => i.Value)
                .Nullable();

            References(i => i.User)
                .Column("UserId")
                .Not.Insert()
                .Not.Update();
        }
    }
}