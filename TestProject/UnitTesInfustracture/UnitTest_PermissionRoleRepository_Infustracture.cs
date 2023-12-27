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
    public class UnitTest_PermissionRoleRepository_Infustracture: DomainFakeModels
    {
        [Fact]
        public async Task PermissionRoleRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IPermissionRoleRepository>();
            callmocking.Setup(repo => repo.GetAllAsync()).ReturnsAsync(permissionrolelist);

            //Acting
            IPermissionRoleRepository mockedrepo = callmocking.Object;
            var actualed_value = await mockedrepo.GetAllAsync();

            //Asserting
            var permrolelisth = Assert.IsAssignableFrom<List<PermissionRole>>(actualed_value);
            //fetching the data from the User as a list
            var models = permrolelisth.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task PermissionRepository_CreateAsync_Metod_Test()
        {


            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IPermissionRoleRepository>();
            callmocking.Setup(repo => repo.AddAsync(It.IsAny<PermissionRole>())).ReturnsAsync(permissionrole);

            //Making a new instance of a User 


            //Acting
            IPermissionRoleRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockedrepo.AddAsync(permissionrole);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task PermissionRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IPermissionRoleRepository>();
            callmocking.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(permissionrole);

            //Acting
            IPermissionRoleRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockedrepo.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task PermissionRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            var callmocking = new Mock<IPermissionRoleRepository>();
            callmocking.Setup(repo => repo.DeleteAsync(It.IsAny<PermissionRole>())).ReturnsAsync(permissionrole);

            //Acting
            IPermissionRoleRepository mockedrepo = callmocking.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockedrepo.DeleteAsync(It.IsAny<PermissionRole>());

            //Asserting
            Assert.NotNull(actualed_value);

        }
    }
}
