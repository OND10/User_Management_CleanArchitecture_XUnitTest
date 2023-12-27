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
    public class UnitTest_UserRoleRepository_Infustracture : DomainFakeModels
    {
        [Fact]
        public async Task UserRoleRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserRoleRepository>();
            callmocking.Setup(repo => repo.GetAllAsync()).ReturnsAsync(userrolelist);

            //Acting
            IUserRoleRepository mockeduserrepo = callmocking.Object;
            var actualed_value = await mockeduserrepo.GetAllAsync();

            //Asserting
            var userroleh = Assert.IsAssignableFrom<List<UserRole>>(actualed_value);
            //fetching the data from the User as a list
            var models = userroleh.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task UserRoleRepository_CreateAsync_Metod_Test()
        {


            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserRoleRepository>();
            callmocking.Setup(repo => repo.AddAsync(It.IsAny<UserRole>())).ReturnsAsync(userRole);

            //Making a new instance of a User 


            //Acting
            IUserRoleRepository mockeduserrepo = callmocking.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockeduserrepo.AddAsync(userRole);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task UserRoleRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserRoleRepository>();
            callmocking.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(userRole);

            //Acting
            IUserRoleRepository mockeduserrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduserrepo.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task UserRoleRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserRoleRepository>();
            callmocking.Setup(repo => repo.DeleteAsync(It.IsAny<UserRole>())).ReturnsAsync(userRole);

            //Acting
            IUserRoleRepository mockeduserrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduserrepo.DeleteAsync(It.IsAny<UserRole>());

            //Asserting
            Assert.NotNull(actualed_value);

        }


    }
}
