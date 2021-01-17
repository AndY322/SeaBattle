// using DomainModel.Models.Identity;
// using FluentNHibernate.Mapping;
//
// namespace DomainModel.Mappings.Identity
// {
//     public class UserRoleMap : ClassMap<UserRole>
//     {
//         public UserRoleMap()
//         {
//             Table("AspNetUserRoles");
//             LazyLoad();
//
//             CompositeId()
//                 .KeyProperty(x => x.UserId)
//                 .KeyReference(x => x.RoleId);
//         }
//     }
// }