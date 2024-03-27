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

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoegmailcom",
            DateTime.Parse("1982-03-21"),
            1
        );
        
        // Assert
        Assert.False(result);
    }
    

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("2005-03-21"),
            1
        );
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("2000-03-21"),
            2
        );
        
        // Assert
        Assert.True(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("2000-03-21"),
            3
        );
        
        // Assert
        Assert.True(result);
    }

    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "johndoe@gmail.com",
            DateTime.Parse("2000-03-21"),
            1
        );
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        
        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalskiiii",
            "johndoe@gmail.com",
            DateTime.Parse("1982-03-21"),
            1
        );
        
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}