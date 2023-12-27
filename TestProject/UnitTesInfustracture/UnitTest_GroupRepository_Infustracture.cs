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
    public class UnitTest_GroupRepository_Infustracture: DomainFakeModels
    {

        [Fact]
        public async Task GroupRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IGroupRepository>();
            callmocking.Setup(repo => repo.GetAllAsync()).ReturnsAsync(grouplist);

            //Acting
            IGroupRepository mockedrepo = callmocking.Object;
            var actualed_value = await mockedrepo.GetAllAsync();

            //Asserting
            var grouplisth = Assert.IsAssignableFrom<List<Group>>(actualed_value);
            //fetching the data from the User as a list
            var models = grouplisth.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task GroupRepository_CreateAsync_Metod_Test()
        {


            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IGroupRepository>();
            callmocking.Setup(repo => repo.AddAsync(It.IsAny<Group>())).ReturnsAsync(group);

            //Making a new instance of a User 


            //Acting
            IGroupRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockedrepo.AddAsync(group);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task GroupRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IGroupRepository>();
            callmocking.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(group);

            //Acting
            IGroupRepository mockedrepo = callmocking.Object;
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
            var callmocking = new Mock<IGroupRepository>();
            callmocking.Setup(repo => repo.DeleteAsync(It.IsAny<Group>())).ReturnsAsync(group);

            //Acting
            IGroupRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockedrepo.DeleteAsync(It.IsAny<Group>());

            //Asserting
            Assert.NotNull(actualed_value);

        }
    }
}
