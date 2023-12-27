using Moq;
using UserManagement_Application.Services;
using UserManagement_Domain.Entities;
using Xunit;
namespace TestProject
{
    public class UnitTest_User_Domain
    {


        private  readonly Mock<IUserService> _userServiceMock;
        //public UnitTest_User_Domain(Mock<IUserService> userServiceMock)
        //{
        //    _userServiceMock = userServiceMock;
        //}

        public UnitTest_User_Domain()
        {
            _userServiceMock=new Mock<IUserService>();
        }

        [Theory]
        [InlineData("osama@gmail.com")]
        [InlineData("john.doe@example.com")]

        public static string Email_Unit_Test_Validation(string defaultEmail)
        {
           
            
           //Arrange
           //mocking for use case IUser to check for its attributes
            var callmocking = new Mock<IUserService>();
            //setup the mocked data which is email attribute and give it an actual data
            callmocking.Setup(user => user.Email).Returns(defaultEmail);
            
            //Act
            //make an object of the IUser use case of the application layer
            IUserService mockeduser= callmocking.Object;
            defaultEmail = mockeduser.Email;

            //Assert
            //Assigning var defaultEmail to the actualed email
            Assert.Matches(@"^[a-z0-9._%+-]+@[a-z]+\.[a-z]{2,}$", defaultEmail);
            return defaultEmail;
            
        }



        [Theory]
        [InlineData("+967-779136337")]
        [InlineData("+20-449875231")]

        public static string Phone_Unit_Test_Validation(string defaultphone)
        {
            //Arrange
            var callmocking= new Mock<IUserService>();
            callmocking.Setup(user => user.Phonenumber).Returns(defaultphone);
           
            //Act
            IUserService mockeduser= callmocking.Object;
            defaultphone = mockeduser.Phonenumber; 
            
            //Assert
            Assert.Matches(@"^\+[0-9.-]{9,}$", defaultphone);
            return defaultphone;
        }



        [Theory]
        [InlineData("Osamadammag2002$")]
        [InlineData("Ond123dammag@")]

        public static string Password_Unit_Test_Validation(string defaultPassword)
        {
            //Arrange
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(user => user.Password).Returns(defaultPassword);
            
            //Act
            IUserService mockeduser=callmocking.Object;
            defaultPassword = mockeduser.Password;
            
            //Assertion
            Assert.Matches(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[a-zA-Z0-9@$!%*?&]{8,}$", defaultPassword);
            return defaultPassword;

        }




        [Theory]
        [InlineData("Osamadammag2002$")]
        [InlineData("Ond123dammag@")]

        public static string Password_Unit_Test_Confirm_Validation(string defaultConfirmPassword)
        {
            //Arrange
            var callmocking = new Mock<IUserService>();
            callmocking.Setup(user => user.ConfirmPassword).Returns(defaultConfirmPassword);

            //Acting
            IUserService mockeduser = callmocking.Object;
            defaultConfirmPassword= mockeduser.ConfirmPassword;

            //Asserting
            Assert.Matches("", defaultConfirmPassword);

            return defaultConfirmPassword;
        }


    }
}