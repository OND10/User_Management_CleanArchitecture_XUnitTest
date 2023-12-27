using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_WebApi.Controllers;

namespace TestProject.Api
{
    public class UnitTest_UserController_Api:DtoFakeBaseModel
    {

        [Fact]
        public async Task GetAllAsync_Test_UserController_Api()
        {

            //Arrange
            //mocked the IUserService to get the specific method for test
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(ctr => ctr.GetAllAsync()).ReturnsAsync(Response<IEnumerable<UserResponseDTO>>.Success(userresponseDTOs, " "));

            //Acting
            var usercontroller = new UserController(callmocking.Object,null);
            var actualed_value = await usercontroller.Get();

            //Asserting
            //Makesure if it is null or not
            Assert.NotNull(actualed_value);

        }

        [Fact]

        public async Task CreateAsync_Test_UserController_Api()
        {

            //Arrange
            //mocked the IUserService to get the specific method for test
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(ctr => ctr.CreateAsync(It.IsAny<UserRequestDTO>())).ReturnsAsync(Response<UserResponseDTO>.Success(userresponse));

            //Acting
            var usercontroller = new UserController(callmocking.Object, null);
            var actualed_value = await usercontroller.Post(It.IsAny<UserRequestDTO>());

            //Asserting
            Assert.True(actualed_value);

        }


        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task DeleteAsync_Test_UserController_Api(int id)
        {

            //Arrange
            //mocked the IUserService to get the specific method for test
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(ctr => ctr.DeleteAsync(It.IsAny<UserRequestDTO>())).ReturnsAsync(Response.Success());

            //Acting
            var usercontroller = new UserController(callmocking.Object, null);
            var actualed_value = await usercontroller.Delete(id);

            //Asserting
            Assert.True(actualed_value);
        }


    }
}
