namespace SimpleImdbEfc;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Birth { get; set; }
    public List<Show> StarsIn { get; set; }
    public List<Show> Writes { get; set; }

    private Person()
    {
    }
}

public class Show
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int Episodes { get; set; }
    public Review? Review { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Person> Stars { get; set; }
    public List<Person> Writers { get; set; }
}

public class Review
{
    public int ShowId { get; set; }
    public decimal Rating { get; set; }
    public int Votes { get; set; }
    public Show Show { get; set; }
}

public class Genre
{
    public int ShowId { get; set; }
    public string Name { get; set; }
    public Show Show { get; set; }
}