# Simple IMDB Entity Framework Core Exercises

The purpose of this repository is to train some simple EFC LINQ queries. 

I have a Queries class, with 10 unit tests, each test is an exercise.

I have the DbContext, called ImdbContext, with defined DbSets for the entities.

You clone the repository, and then you probably need to the the Data Source path to the absolute path of the imdb.db file.

I.e., you update the following in ImdbContext:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = Imdb.db");
}
```

To something like:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = C:\MyDrive\Projects\SimpleImdbEfc\SimpleImdbEfc\Imdb.db");
}
```
