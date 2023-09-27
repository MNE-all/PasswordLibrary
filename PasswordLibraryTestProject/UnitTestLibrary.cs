namespace PasswordLibraryTestProject;
using PasswordLibrary;
public class UnitTestLibrary
{
    [Fact]
    public void TestSoSilly()
    {
        const string password = "test";

        Assert.Equal("Слишком слабый", Password.Check(password));
    }
    
    [Fact]
    public void TestSilly()
    {
        const string password = "default";
        
        Assert.Equal("Слабый", Password.Check(password));
    }
    
    [Fact]
    public void TestMedium()
    {
        const string password = "Default";
        
        Assert.Equal("Средний", Password.Check(password));
    }
    
    [Fact]
    public void TestGood()
    {
        const string password = "Default4";
        
        Assert.Equal("Хороший", Password.Check(password));
    }
    
    [Fact]
    public void TestHigh()
    {
        const string password = "Default4%";
        
        Assert.Equal("Надёжный", Password.Check(password));
    }
}