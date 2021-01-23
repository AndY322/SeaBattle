using DomainModel.Models.Identity;
using FluentNHibernate.Mapping;
using NHibernate.AspNetCore.Identity;

namespace DomainModel.Mappings.Identity
{
    public class UserRoleMap : ClassMap<IdentityUserRole>
    {
        public UserRoleMap()
        {
            Table("AspNetUserRoles");
            LazyLoad();

            CompositeId()
                .KeyProperty(x => x.UserId)
                .KeyProperty(x => x.RoleId);
        }
    }
}