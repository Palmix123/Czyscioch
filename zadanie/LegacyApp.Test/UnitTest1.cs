namespace LegacyApp.Test;

public class UnitTest1
{
    [Fact]
    public void AddUser_ReturnFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();
        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("1982-03-21"),
            1
            );
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("1982-03-21"),
            100
        );
        
        
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}