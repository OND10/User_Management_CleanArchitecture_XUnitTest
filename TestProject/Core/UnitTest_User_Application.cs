using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestProject.FakeEntities;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;
using Xunit;
namespace TestProject.Core
{
    public class UnitTest_User_Application: DtoFakeBaseModel
    {
        private readonly Mock<IUserService> _userServiceMock;
        public UnitTest_User_Application()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task User_Get_AllAsync_Method_Test()
        {
            // Arrange
            //var callmocking = new Mock<IUserService>();
            //Mocked the IUserService to return the specified method using the _userServiceMock
            _userServiceMock.Setup(user => user.GetAllAsync())
                .ReturnsAsync(Response<IEnumerable<UserResponseDTO>>.Success(userresponseDTOs, " ")
                );


            // Acting
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to getall method
            var actualed_value = await mockeduser.GetAllAsync();


            // Asserting
            //This IsAssignableFrom is used to check if its parameter equals the actualed_value
            var responses = Assert.IsAssignableFrom<Response<IEnumerable<UserResponseDTO>>>(actualed_value);
            //fetching the data of the UserResponse as a list
            var models = responses.Data;
            //To check times of data recorded => measn how many recors are returned
            Assert.Equal(2, models.Count());
        }


        [Fact]
        public async Task User_CreateAsync_Method_Test()
        {
            // Arrange
            //Mocked the IUserService to return the specified method using the _userServiceMock
            _userServiceMock.Setup(user => user.CreateAsync(It.IsAny<UserRequestDTO>()))
                .ReturnsAsync(Response<UserResponseDTO>.Success(userresponse));

        
            // Acting
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to create method
            var actualed_value = await mockeduser.CreateAsync(userrequest);


            // Asserting
            Assert.NotNull(actualed_value);
        }


        [Fact]
        public async Task User_GetById_Test_Method()
        {

            //Arrange
            //Mocked the IUserService to return the specified method using the _userServiceMock
            _userServiceMock.Setup(user => user.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Response<UserRequestDTO>.Success(userrequest));

            //Acting
            //making an object of IUserService
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to getbyid method
            var actualed_value = await mockeduser.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task User_Delete_Test_Method()
        {

            //Arrange
            //Mocked the IUserService to return the specified method using the _userServiceMock
            _userServiceMock.Setup(user => user.DeleteAsync(It.IsAny<UserRequestDTO>())).ReturnsAsync(await Response.SuccessAsync());
           
            //Acting
            //making an object of IUserService
            IUserService mockeduser = _userServiceMock.Object;
            //Assigning actualed_value to delete method
            var actualed_value = await mockeduser.DeleteAsync(userrequest);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
