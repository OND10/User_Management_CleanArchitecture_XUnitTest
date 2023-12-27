using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.UserRoleServices.Interface;
using UserManagement_Application.Utly;

namespace TestProject.Core
{
    public class UnitTest_UserRole_Application:DtoFakeBaseModel
    {

        private readonly Mock<IUserRoleService> _userRoleService;

        public UnitTest_UserRole_Application()
        {
               _userRoleService=new Mock<IUserRoleService>(); 
        }


        [Fact]
        public async Task UserRole_Get_AllAsync_Method_Test()
        {
            // Arrange
            //Mocked the IRoleService to return the specified method using the Dependency Injection
            _userRoleService.Setup(userrole => userrole.GetAllAsync())
                .ReturnsAsync(await Response<IEnumerable<UserRoleResponseDTO>>.SuccessAsync(userroleresponseDTOs, " ")
                );


            // Acting
            IUserRoleService mockedrole = _userRoleService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<UserRoleResponseDTO>>>(actualed_value);
            //fetching the data of the Roleresponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task UserRole_CreateAsync_Test_Method()
        {
            //Arrange
           
            //mocking the IUserRoleService to get the specified method
            _userRoleService.Setup(userrole => userrole.CreateAsync(It.IsAny<UserRoleRequestDTO>())).
                ReturnsAsync(await Response<UserRoleResponseDTO>.SuccessAsync(userroleresponse, ""));


            //Acting
            IUserRoleService mockedrole = _userRoleService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.CreateAsync(userrolerequest);

            //Asserting
            //Check if actualed_value is not null
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task UserRole_GetById_Method_Test()
        {

            //Arrange
           
            //mocking the IUserRoleService to get the specified method
            _userRoleService.Setup(role => role.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(await Response<UserRoleRequestDTO>.SuccessAsync(userrolerequest));

            //Acting
            IUserRoleService mockedrole = _userRoleService.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = mockedrole.GetByIdAsync(It.IsAny<int>());


            //Asserting
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task UserRole_Delete_Method_Test()
        {

            //Arrange
            //mocking the IUserRoleService to get the specified method
            _userRoleService.Setup(role => role.DeleteAsync(It.IsAny<UserRoleRequestDTO>())).
                ReturnsAsync(await Response.SuccessAsync());
         
            //Acting
            IUserRoleService mockedrole = _userRoleService.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockedrole.DeleteAsync(userrolerequest);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }

    }
}
