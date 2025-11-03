using ism_core;

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
        }
    }
}