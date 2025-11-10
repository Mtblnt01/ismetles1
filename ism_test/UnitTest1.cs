using ism_core;
using System.Runtime.Intrinsics.X86;

namespace ism_test
{
    public class UnitTest1
    {
        [Fact]
        public void CreateUser_ShouldAddUserToList()
        {
            //Arrange
            var users = new List<User>();
            UserService service = new UserService(users);

            //Act
            var user = service.CreateUser("Teszt Elek", "jelszo123", "teszt@example.com", DateTime.Now.ToString(), "3");
            //Assert
            Assert.Equal("Teszt Elek", user.Name);
            Assert.Equal("jelszo123", user.Password);
            Assert.Equal("teszt@example.com", user.Email);
            Assert.Equal(3, user.Level);
        }
        [Fact]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            //Arrange
            var user1 = new User(1, "Felh1", "password", "felh1@example.com", DateTime.Now.ToString(), 4);
            var users = new List<User> { user1};
            UserService service = new UserService(users);
            
            //Act
            var resultUser = service.GetUserById(1);
            //Assert
            Assert.NotNull(resultUser);
            Assert.Equal("Felh1", resultUser.Name);
        }

        [Fact]
        public void UpdateUserName_ShouldChangeUserName() 
        {
            //Arrange
            var user1 = new User(1, "Felh1", "password", "felh1@example.com", DateTime.Now.ToString(), 4);
            var users = new List<User> { user1 };
            UserService service = new UserService(users);

            //Act
            bool result = service.UpdateUserName(1, "Sanyi");
            //Assert
            Assert.True(result);
            Assert.Equal("Sanyi", user1.Name);
        }

        [Fact]
        public void UpdateUserName_NonExistentUser_ShouldReturnFalse()
        {
            //Arrange
            var users = new List<User>();
            UserService service = new UserService(users);
            //Act
            bool result = service.UpdateUserName(99, "Sanyi");
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteUserById_ShouldRemoveUser_WhenExists()
        {
            //Arrange
            var user1 = new User(1, "Felh1", "password", "felh1@example.com", DateTime.Now.ToString(), 4);
            var users = new List<User> { user1 };
            UserService service = new UserService(users);
            //Act
            bool result = service.DeleteUserById(1);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteUserById_ShouldReturnFalse_WhenUserNotFound()
        {
            //Arrange
            var users = new List<User>()    ;
            UserService service = new UserService(users);
            //Act
            bool result = service.DeleteUserById(42);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ParseFromCsv_ShouldReturnValidUser()
        {
            //Arrange
            string csv = "Teszt Elek; jelszo123; teszt@example.com; 2025-11-10; 3";
            //Act
            User user = UserService.ParseFromCsv(csv, ';');
            //Assert
            Assert.Equal("Teszt Elek", user.Name);
            Assert.Equal("jelszo123", user.Password);
            Assert.Equal("teszt@example.com", user.Email);
            Assert.Equal(3, user.Level);
        }




    }
}