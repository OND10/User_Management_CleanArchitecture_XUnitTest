using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.FakeEntities;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Interfaces;

namespace TestProject.UnitTesInfustracture
{
    public class UnitTest_RoleRepository_Infustracture: DomainFakeModels
    {

        [Fact]
        public async Task RoleRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IRoleRepository>();
            callmocking.Setup(repo => repo.GetAllAsync()).ReturnsAsync(rolelist);

            //Acting
            IRoleRepository mockeduserrepo = callmocking.Object;
            var actualed_value = await mockeduserrepo.GetAllAsync();

            //Asserting
            var rolelisth = Assert.IsAssignableFrom<List<Role>>(actualed_value);
            //fetching the data from the User as a list
            var models = rolelisth.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task RoleRepository_CreateAsync_Metod_Test()
        {


            //Arrange

            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IRoleRepository>();
            callmocking.Setup(repo => repo.AddAsync(It.IsAny<Role>())).ReturnsAsync(role);

            //Making a new instance of a User 


            //Acting
            IRoleRepository mockeduser = callmocking.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockeduser.AddAsync(role);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task RoleRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IRoleRepository>();
            callmocking.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(role);

            //Acting
            IRoleRepository mockeduser = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task RoleRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IRoleRepository>();
            callmocking.Setup(repo => repo.DeleteAsync(It.IsAny<Role>())).ReturnsAsync(role);

            //Acting
            IRoleRepository mockeduser = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.DeleteAsync(It.IsAny<Role>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

    }
}
