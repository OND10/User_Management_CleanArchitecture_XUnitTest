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
    public class UnitTest_UserGroupRepository_Infustracture: DomainFakeModels
    {
        [Fact]
        public async Task UserGroupRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserGroupRepository>();
            callmocking.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usergrouplist);

            //Acting
            IUserGroupRepository mockedrepo = callmocking.Object;
            var actualed_value = await mockedrepo.GetAllAsync();

            //Asserting
            var usergrouplisth = Assert.IsAssignableFrom<List<UserGroup>>(actualed_value);
            //fetching the data from the User as a list
            var models = usergrouplisth.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task GroupRepository_CreateAsync_Metod_Test()
        {


            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserGroupRepository>();
            callmocking.Setup(repo => repo.AddAsync(It.IsAny<UserGroup>())).ReturnsAsync(userGroup);

            //Making a new instance of a User 


            //Acting
            IUserGroupRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockedrepo.AddAsync(userGroup);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task GroupRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserGroupRepository>();
            callmocking.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(userGroup);

            //Acting
            IUserGroupRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockedrepo.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task GroupRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IUserGroupRepository>();
            callmocking.Setup(repo => repo.DeleteAsync(It.IsAny<UserGroup>())).ReturnsAsync(userGroup);

            //Acting
            IUserGroupRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockedrepo.DeleteAsync(It.IsAny<UserGroup>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

    }
}
