using Xunit.Abstractions;

namespace SimpleImdbEfc;

public class Queries(ITestOutputHelper printer)
{
    private ImdbContext ctx = new();

    // Exercise 1: When was "Black Mirror" first aired 
    [Fact]
    public void Ex1()
    {
        printer.WriteLine("This is how you print to unit test console");
    }

    // Exercise 2: Which actor has id 103785 
    [Fact]
    public void Ex2()
    {
    }

    // Exercise 3: Who are the stars of "The Office" (year 2005)
    [Fact]
    public void Ex3()
    {
    }

    // Exercise 4: List the genres of "Stranger Things" (year 2016)
    [Fact]
    public void Ex4()
    {
    }
    
    // Exercise 5: Which shows has Jennifer Aniston starred in?
    [Fact]
    public void Ex5()
    {
    }
    
    // Exercise 6: List the different kind of genres
    [Fact]
    public void Ex6()
    {
    }
    
    // Ex 7: list the shows from 1970
    [Fact]
    public void Ex7()
    {
    }
    
    // Ex 8: List the stars born between 1955 and 1965
    [Fact]
    public void Ex8()
    {
    }
    
    // Ex 9: Which shows have a rating of 9.9?
    [Fact]
    public void Ex9()
    {
    }
    
    // Ex 10: List the shows that has something to do with "Titanic"
    [Fact]
    public void Ex10()
    {
        
    }
}
