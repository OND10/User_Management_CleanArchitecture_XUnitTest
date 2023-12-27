using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.GroupServices.Interface;
using UserManagement_Application.Utly;

namespace TestProject.Core
{
    public class UnitTest_Group_Application:DtoFakeBaseModel
    {

        [Fact]
        public async Task Group_Get_AllAsync_Method_Test()
        {
            // Arrange
            var callmocking = new Mock<IGroupService>();
            //Mocked the IRoleService to return the specified method using the Dependency Injection
            callmocking.Setup(userrole => userrole.GetAllAsync())
                .ReturnsAsync(await Response<IEnumerable<GroupResponseDTO>>.SuccessAsync(groupresponseDTOs, " ")
                );


            // Acting
            IGroupService mockedrole = callmocking.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<GroupResponseDTO>>>(actualed_value);
            //fetching the data of the Roleresponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task Group_CreateAsync_Test_Method()
        {
            //Arrange
            var callmocking = new Mock<IGroupService>();
            //mocking the IUserRoleService to get the specified method
            callmocking.Setup(userrole => userrole.CreateAsync(It.IsAny<GroupRequestDTO>())).
                ReturnsAsync(await Response<GroupResponseDTO>.SuccessAsync(groupresponse, ""));


            //Acting
            IGroupService mockedrole = callmocking.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockedrole.CreateAsync(groupRequest);

            //Asserting
            //Check if actualed_value is not null
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task Group_GetById_Method_Test()
        {

            //Arrange
            var callmocking = new Mock<IGroupService>();
            //mocking the IUserRoleService to get the specified method
            callmocking.Setup(role => role.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(await Response<GroupRequestDTO>.SuccessAsync(groupRequest));

            //Acting
            IGroupService mockedrole = callmocking.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = mockedrole.GetByIdAsync(It.IsAny<int>());


            //Asserting
            Assert.NotNull(actualed_value);

        }


        [Fact]

        public async Task Group_Delete_Method_Test()
        {

            //Arrange
            var callmocking = new Mock<IGroupService>();
            //mocking the IUserRoleService to get the specified method
            callmocking.Setup(role => role.DeleteAsync(It.IsAny<GroupRequestDTO>())).
                ReturnsAsync(await Response.SuccessAsync());

            //Acting
            IGroupService mockedrole = callmocking.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockedrole.DeleteAsync(groupRequest);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }

    }
}
