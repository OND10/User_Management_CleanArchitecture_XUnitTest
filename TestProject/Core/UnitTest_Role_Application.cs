using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.RoleServices;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using Xunit;

namespace TestProject.Core
{
    public class UnitTest_Role_Application:DtoFakeBaseModel
    {
        private readonly Mock<IRoleService> _roleService;
        public UnitTest_Role_Application()
        {
            _roleService= new Mock<IRoleService>();
        }

        [Fact]
        public async Task Role_Get_AllAsync_Method_Test()
        {
            // Arrange
            //Mocked the IRoleService to return the specified method using the Dependency Injection
            _roleService.Setup(role => role.GetAllAsync())
                .ReturnsAsync(await Response<IEnumerable<RoleResponseDTO>>.SuccessAsync(roleresponseDTOs, " ")
                );


            // Acting
            IRoleService mockedrole = _roleService.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.GetAllAsync();

            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<RoleResponseDTO>>>(actualed_value);
            //fetching the data of the Roleresponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task Role_CreateAsync_Method_Test()
        {

            //Arrange
            //Mocked the IRoleService to return the specified method
            _roleService.Setup(role => role.CreateAsync(It.IsAny<RoleRequestDTO>())).
                ReturnsAsync(await Response<RoleResponseDTO>.SuccessAsync(roleresponse));

            //Acting
            IRoleService mockedrole = _roleService.Object;
            //Assigning actualed_value to create method
            var actualed_value = mockedrole.CreateAsync(rolerequest);

            //Asserting
            //Check if actualed_value is not null
            Assert.NotNull(actualed_value);
          
        }


        [Fact]

        public async Task Role_GetById_Method_Test()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _roleService.Setup(role => role.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(await Response<RoleRequestDTO>.SuccessAsync(rolerequest));

            //Acting
            IRoleService mockedrole= _roleService.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = mockedrole.GetByIdAsync(It.IsAny<int>());


            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task Role_Delete_Method_Test()
        {

            //Arrange
            //Mocked the IUserService to return the specified method
            _roleService.Setup(role => role.DeleteAsync(It.IsAny<RoleRequestDTO>())).
                ReturnsAsync(await Response.SuccessAsync());
           
            //Acting
            IRoleService mockedrole= _roleService.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockedrole.DeleteAsync(rolerequest);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
