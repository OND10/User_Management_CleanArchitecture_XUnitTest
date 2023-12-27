using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.UserGroupServices.Interface;
using UserManagement_Application.Utly;

namespace TestProject.Core
{
    public class UnitTest_UserGroup_Application:DtoFakeBaseModel
    {

        private readonly Mock<IUserGroupService> _mockUserGroupService;

        public UnitTest_UserGroup_Application()
        {
                _mockUserGroupService = new Mock<IUserGroupService>();
        }

        [Fact]
        public async Task UserGroup_Get_AllAsync_Method_Test()
        {
            // Arrange
            //Mocked the IRoleService to return the specified method using the Dependency Injection
            _mockUserGroupService.Setup(userrole => userrole.GetAllAsync())
                .ReturnsAsync(await Response<IEnumerable<UserGroupResponseDTO>>.SuccessAsync(usergroupresponsedto, " ")
                );


            // Acting
            IUserGroupService mockedrole = _mockUserGroupService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<UserGroupResponseDTO>>>(actualed_value);
            //fetching the data of the Roleresponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task UserGroup_CreateAsync_Test_Method()
        {
            //Arrange
            //mocking the IUserRoleService to get the specified method
            _mockUserGroupService.Setup(userrole => userrole.CreateAsync(It.IsAny<UserGroupRequestDTO>())).
                ReturnsAsync(await Response<UserGroupResponseDTO>.SuccessAsync(usergroupresponse, ""));


            //Acting
            IUserGroupService mockedrole = _mockUserGroupService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.CreateAsync(usergrouprequest);

            //Asserting
            //Check if actualed_value is not null
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task UserGroup_GetById_Method_Test()
        {

            //Arrange
            //mocking the IUserRoleService to get the specified method
            _mockUserGroupService.Setup(role => role.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(await Response<UserGroupRequestDTO>.SuccessAsync(usergrouprequest));

            //Acting
            IUserGroupService mockedrole = _mockUserGroupService.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = mockedrole.GetByIdAsync(It.IsAny<int>());


            //Asserting
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task UserGroup_Delete_Method_Test()
        {

            //Arrange
            //mocking the IUserRoleService to get the specified method
            _mockUserGroupService.Setup(role => role.DeleteAsync(It.IsAny<UserGroupRequestDTO>())).
                ReturnsAsync(await Response.SuccessAsync());

            //Acting
            IUserGroupService mockedrole = _mockUserGroupService.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockedrole.DeleteAsync(usergrouprequest);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }

    }
}
