using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using UserManagement_Domain.Interfaces;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Common.Enums;
using TestProject;
using AutoMapper;
using TestProject.FakeEntities;

namespace TestProject
{
    public class UnitTest_UserRepository_Infustracture:DomainFakeModels
    {
        private readonly Mock<IUserRepository> _userRepository;
        
        public UnitTest_UserRepository_Infustracture(Mock<IUserRepository> repository)
        {
            _userRepository=repository;
        }


        [Fact]
        public async Task UserRepository_GetAll_Method_Test()
        {

            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(userlist);

            //Acting
            IUserRepository mockeduserrepo = _userRepository.Object;
            var actualed_value = await mockeduserrepo.GetAllAsync();

            //Asserting
            var userlisth = Assert.IsAssignableFrom<List<User>>(actualed_value);
            //fetching the data from the User as a list
            var models = userlisth.ToList();
            Assert.Equal(2, models.Count);

        }


        [Fact]

        public async Task UserRepository_CreateAsync_Metod_Test()
        {


            //Arrange

            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

            //Making a new instance of a User 
         

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the create method
            var actualed_value = await mockeduser.AddAsync(user);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task UserRepository_GetByIdAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.GetByIdAsync(It.IsAny<int>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task UserRepository_DeleteAsync_Metod_Test()
        {
            //Arrange
            //Mocked the IUserRepository to get the specified method
            _userRepository.Setup(repo => repo.DeleteAsync(It.IsAny<User>())).ReturnsAsync(user);

            //Acting
            IUserRepository mockeduser = _userRepository.Object;
            //mocking the IUserRepository to call the getbyid method
            var actualed_value = await mockeduser.DeleteAsync(It.IsAny<User>());

            //Asserting
            Assert.NotNull(actualed_value);

        }

    }
}