using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;

namespace TestProject.FakeEntities
{
    public class DtoFakeBaseModel
    {

        //---------------------------------------------------------
        //                     User with DTOs
        //---------------------------------------------------------

        public UserResponseDTO userresponse = new UserResponseDTO
        {
            Id = 1,
            Name = "User1",
            Username = "OND",
            Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
            Gender = Convert.ToBoolean(GenderEnum.Male),
            PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
        };

        public UserRequestDTO userrequest = new UserRequestDTO
        {
            Id = 1,
            Name = "User1",
            Username = "OND",
            Email = UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),
            Gender = Convert.ToBoolean(GenderEnum.Male),
            PhoneNumber = UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
        };

      

        public List<UserResponseDTO> userresponseDTOs = new List<UserResponseDTO>() {
                    new UserResponseDTO
                    {
                            Id=1,Name="User1",Username="OND",Email=UnitTest_User_Domain.Email_Unit_Test_Validation("osama@gmail.com"),Gender=Convert.ToBoolean(GenderEnum.Male),
                            PhoneNumber=UnitTest_User_Domain.Phone_Unit_Test_Validation("+967-779136337")
                    },
                    
                    //Making another new object of the UserResponse
                    new UserResponseDTO
                    {
                            Id=2,Name="User2",Username="Shelly",Email="user2@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Female),
                            PhoneNumber="+967-777777254"
                    },
        };

        //---------------------------------------------------------
        //                    End User with DTOs
        //---------------------------------------------------------


        //---------------------------------------------------------
        //                     Role with DTOs
        //---------------------------------------------------------


        public List<RoleResponseDTO> roleresponseDTOs = new List<RoleResponseDTO>()
        {
                    new RoleResponseDTO
                    {
                            Id=Convert.ToInt16(RolesEnum.Admin),Name="Admin",Description = "Controlling all users,endusers and managers in the system"
                    },
                    
                    //Making another new object of the Roleresponse
                    new RoleResponseDTO
                    {
                            Id=Convert.ToInt16(RolesEnum.User),Name="User",Description = "Interacting with system as other users"
                    },

        };


        public RoleResponseDTO roleresponse = new RoleResponseDTO
        {
            Id = Convert.ToInt16(RolesEnum.Admin),
            Name = "Admin",
            Description = "Controlling all users,endusers and managers in the system"
        };

       public RoleRequestDTO rolerequest = new RoleRequestDTO
        {

            Id = Convert.ToInt16(RolesEnum.Admin),
            Name = "Admin",
            Description = "Controlling all users,endusers and managers in the system"
        };

        //---------------------------------------------------------
        //                     End Role with DTOs
        //---------------------------------------------------------


        //---------------------------------------------------------
        //                     UserRole with DTOs
        //---------------------------------------------------------


        public List<UserRoleResponseDTO> userroleresponseDTOs = new List<UserRoleResponseDTO>()
        {
                    new UserRoleResponseDTO
                    {
                        Id = 1,UserId = 1,RoleId = 1,
                    },
                    
                    //Making another new object of the Roleresponse
                    new UserRoleResponseDTO
                    {
                        Id = 2,UserId = 2,RoleId = 2,
                    },
        };

        public UserRoleResponseDTO userroleresponse = new UserRoleResponseDTO
        {
            Id = 1,
            UserId = 1,
            RoleId = 1,
        };

        public UserRoleRequestDTO userrolerequest = new UserRoleRequestDTO
        {
            UserId = 1,
            RoleId = 1,
        };

        //---------------------------------------------------------
        //                     End UserRole with DTOs
        //---------------------------------------------------------


        //---------------------------------------------------------
        //                     Group with DTOs
        //---------------------------------------------------------

        public List<GroupResponseDTO> groupresponseDTOs = new List<GroupResponseDTO>()
        {
               new GroupResponseDTO
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
                new GroupResponseDTO
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


        public GroupRequestDTO groupRequest = new GroupRequestDTO
        {
            Name = "SupervisonGroup",
            Description = "Menitoring employees who recently got employeed",
        };

        public GroupResponseDTO groupresponse = new GroupResponseDTO
        {
                    Id = 1,
                    Name = "SupervisonGroup",
                    Description = "Menitoring employees who recently got employeed",
                    UserGroups = new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=1,UserId=1, GroupId=1,
                        }
                    }
        };

        //---------------------------------------------------------
        //                     End Group with DTOs
        //---------------------------------------------------------


        //---------------------------------------------------------
        //                      UserGroup with DTOs
        //---------------------------------------------------------

        public List<UserGroupResponseDTO> usergroupresponsedto = new  List<UserGroupResponseDTO>()
            {
                new UserGroupResponseDTO
                {
                    Id = 1,
                    UserId = 1,
                    GroupId = 1,
                },
                new UserGroupResponseDTO
                {
                    Id = 2,
                    UserId = 2,
                    GroupId = 2,
                }
            };

        public UserGroupRequestDTO usergrouprequest = new UserGroupRequestDTO
        {
            UserId = 1,
            GroupId= 1,
        };

        public UserGroupResponseDTO usergroupresponse = new UserGroupResponseDTO
        {

            Id = 1,
            UserId = 1,
            GroupId = 1,
        };

        //---------------------------------------------------------
        //                     End UserGroup with DTOs
        //---------------------------------------------------------



        //---------------------------------------------------------
        //                     Permission with DTOs
        //---------------------------------------------------------

        public List<PermissionResponseDTO> permissionresponsedtos = new List<PermissionResponseDTO>()
        {

                new PermissionResponseDTO
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
                new PermissionResponseDTO
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

        public PermissionResponseDTO permissionresponse = new PermissionResponseDTO
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

        public PermissionRequestDTO permissionrequest = new PermissionRequestDTO
        {
            Name = PermissionsEnum.Create.ToString(),
            Description = "The ability to create many funds",
        };

        //---------------------------------------------------------
        //                    End Permission with DTOs
        //---------------------------------------------------------



        //---------------------------------------------------------
        //                     PermissionRole with DTOs
        //---------------------------------------------------------

        public List<PermissionRoleResponseDTO> permissionroleresponsedtos = new List<PermissionRoleResponseDTO>()
        {
                new PermissionRoleResponseDTO
                {
                    Id = 1,
                    PermissionId = 1,
                    RoleId = 1,
                },
                new PermissionRoleResponseDTO
                {
                    Id = 2,
                    PermissionId = 2,
                    RoleId = 2,
                }
        };

        public PermissionRoleResponseDTO permissionroleresponse = new PermissionRoleResponseDTO
        {
            Id = 1,
            PermissionId = 1,
            RoleId = 1,
        };

        public PermissionRoleRequestDTO permissionrolerequest = new PermissionRoleRequestDTO
        {
            PermissionId = 1,
            RoleId = 1,
        };


        //---------------------------------------------------------
        //                    End PermissionRole with DTOs
        //---------------------------------------------------------


    }
}
