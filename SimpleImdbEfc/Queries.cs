using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace SimpleImdbEfc;

public class Queries(ITestOutputHelper printer)
{
    private ImdbContext ctx = new();

    // Exercise 1: When was "Black Mirror" first aired 
    [Fact]
    public void Ex1()
    {
        Show first = ctx.Shows.First(s => s.Title == "Black Mirror");
        printer.WriteLine(first.Year.ToString());
    }

    // Exercise 2: Which actor has id 103785 
    [Fact]
    public void Ex2()
    {
        Person single = ctx.People.Single(p => p.Id == 103785);
        printer.Print(single);
    }

    // Exercise 3: Who are the stars of "The Office" (year 2005)
    [Fact]
    public void Ex3()
    {
        var stars = ctx.Shows
            .Include(s => s.Stars)
            .Single(s => s.Title == "The Office" && s.Year == 2005)
            .Stars
            .Select(s => new
            {
                s.Id,
                s.Name,
                s.Birth
            });
        printer.Print(stars);
    }

    // Exercise 4: List the genres of "Stranger Things" (year 2016)
    [Fact]
    public void Ex4()
    {
        List<Genre> genres = ctx.Shows
            .Include(s => s.Genres)
            .Where(s => s.Title == "Stranger Things" && s.Year == 2016)
            .SelectMany(s => s.Genres)
            .ToList();
        printer.Print(genres);
    }

    // Exercise 5: Which shows has Jennifer Aniston starred in?
    [Fact]
    public void Ex5()
    {
        var list = ctx.People
            .Where(p => p.Name == "Jennifer Aniston")
            .SelectMany(p => p.StarsIn)
            .Select(show => new
            {
                show.Id,
                show.Title,
                show.Episodes,
                show.Year
            })
            .ToList();
        
        printer.Print(list);
    }

    // Exercise 6: List the different kind of genres
    [Fact]
    public void Ex6()
    {
        var hashSet = ctx.Genres
            .Select(g => g.Name)
            .Distinct()
            .OrderBy(s => s)
            .ToList();
        printer.Print(hashSet);
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

public static class PrintExts
{
    public static void Print<T>(this ITestOutputHelper helper, T obj) where T : class
    {
        helper.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }
}