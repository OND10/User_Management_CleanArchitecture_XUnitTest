using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;

namespace TestProject.FakeEntities
{
    public class DomainFakeModels
    {

        //User 
        public User user = new User
        {
            Id = 1,
            Name = "User1",
            Username = "OND",
            Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
            Gender = Convert.ToBoolean(GenderEnum.Male),
            PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
        };

        public List<User> userlist = new List<User>()
        {
             new User
                {
                    Id = 1,
                    Name = "User1",
                    Username = "OND",
                    Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
                    Gender = Convert.ToBoolean(GenderEnum.Male),
                    PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
                },

                new User
                {
                    Id = 2,
                    Name = "User2",
                    Username = "shellyuser",
                    Email = UnitTest_User_Domain.Email_Unit_Test_Validation("user@gmail.com"),
                    Gender = Convert.ToBoolean(GenderEnum.Female),
                    PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-777777548")
                },

        };


        //Role
        public Role role = new Role
        {
            Id = Convert.ToInt16(RolesEnum.Admin),
            Name = "Admin",
            Description = "Controlling all users,endusers and managers in the system"
        };

        public List<Role> rolelist = new List<Role>()
        {
             new Role
                {
                    Id = Convert.ToInt16(RolesEnum.Admin),
                    Name ="Admin",
                    Description = "Controlling all users,endusers and managers in the system"
                },
                new Role
                {
                    Id = Convert.ToInt16(RolesEnum.User),
                    Name ="User",
                    Description = "Interacting with system as other users"
                }

        };


        //UserRole
        public UserRole userRole = new UserRole
        {
            Id = 1,
            UserId = 1,
            RoleId = 1,
        };

        public List<UserRole> userrolelist = new List<UserRole>()
        {
             new UserRole
                {
                   Id = 1,
                   UserId = 1,
                   RoleId = 1,
                },
                new UserRole
                {
                   Id = 2,
                   UserId = 2,
                   RoleId = 2,
                }
        };


        //Group
        public Group group = new Group
        {
                    Id = 1,
                    Name = "SupervisonGroup",
                    Description = "Menitoring employees who recently got employeed",
                    UserGroups = new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=1,
                            UserId=1,
                            GroupId=1,
                        }
                    }
        };

        public List<Group> grouplist = new List<Group>()
        {
                 new Group
                 {
                    Id = 1,
                    Name = "SupervisonGroup",
                    Description = "Menitoring employees who recently got employeed",
                    UserGroups= new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=1,
                            UserId=1,
                            GroupId=1,
                        }
                    }
                 },
                new Group
                {
                    Id = 2,
                    Name = "TestingGroup",
                    Description = "Test and Deploy Software",
                    UserGroups= new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=2,
                            UserId=2,
                            GroupId=2,
                        }
                    }
                }
        };


        //UserGroup
        public UserGroup userGroup = new UserGroup
        {
            Id = 1,
            UserId = 1,
            GroupId = 1,
        };

        public List<UserGroup> usergrouplist = new List<UserGroup>()
        {
             new UserGroup
                {
                    Id = 1,
                    UserId = 1,
                    GroupId = 1,
                },
                new UserGroup
                {
                    Id = 2,
                    UserId = 2,
                    GroupId = 2,
                }
        };


        //Permission
        public Permission permission = new Permission
        {
            Id = 1,
            Name = PermissionsEnum.Create.ToString(),
            Description = "The ability to create many funds",
            PermissionRoles = new List<PermissionRole>()
                   {
                       new PermissionRole
                       {
                         Id = 1,
                         PermissionId = 1,
                         RoleId = 1,
                       }
                   }
        };

        public List<Permission> permissionlist = new List<Permission>()
        {
             new Permission
                {
                   Id = 1,
                   Name = PermissionsEnum.Create.ToString(),
                   Description = "The ability to create many funds",
                   PermissionRoles = new List<PermissionRole>()
                   {
                       new PermissionRole
                       {
                         Id = 1,
                         PermissionId = 1,
                         RoleId = 1,
                       }
                   }
                },
                new Permission
                {
                   Id = 2,
                   Name = PermissionsEnum.Edit.ToString(),
                   Description = "The ability to update many funds",
                   PermissionRoles = new List<PermissionRole>()
                   {
                       new PermissionRole
                       {
                         Id = 2,
                         PermissionId = 2,
                         RoleId = 2,
                       }
                   }
                }
        };

        //PermissionRole
        public PermissionRole permissionrole = new PermissionRole
        {
            Id = 1,
            PermissionId = 1,
            RoleId = 1,
        };

        public List<PermissionRole> permissionrolelist = new List<PermissionRole>()
        {
             new PermissionRole
                {
                    Id = 1,
                    PermissionId = 1,
                    RoleId = 1,
                },
                new PermissionRole
                {
                    Id = 2,
                    PermissionId = 2,
                    RoleId = 2,
                }
        };

    }
}
