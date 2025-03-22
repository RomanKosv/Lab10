using InputLibrary;

namespace GameLibrary;
public class Game : IInit
{
    public string Name
    {
        get;
        protected set;
    } = "";
    public int MinPlayers { get; protected set; } = 0;
    public int MaxPlayers { get; protected set; } = 0;



    public virtual void Init()
    {
        Console.WriteLine("Input paramethers of game:");
        Console.WriteLine("Input name:");
        Name = ConsoleInput.LINE.get();
        Console.WriteLine("Input min count of players:");
        MinPlayers = ConsoleInput.NATURAL.get();
        Console.WriteLine("Input max count of players:");
        MaxPlayers = ConsoleInput.GetNoLess(MinPlayers).get();
    }
    public virtual void RandomInit()
    {
        Name = Rand.RandomString();
        MinPlayers = Rand.rand.Next(0, 10);
        MaxPlayers = Rand.rand.Next(MinPlayers, 15);
    }
    public override bool Equals(object? obj)
    {
        if (obj is Game other)
            return Name.Equals(other.Name) && MinPlayers == other.MinPlayers && MaxPlayers == other.MaxPlayers;
        else return false;
    }
    public virtual void Show()
    {
        Console.WriteLine($"Game({StringProperties()})");
    }

    protected string StringProperties()
    {
        return $"name - {Name}, min count of players - {MinPlayers}, max - {MaxPlayers}";
    }
}