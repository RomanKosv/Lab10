namespace GameLibrary;
public class Game
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
            Name = Input.InputString();
            Console.WriteLine("Input min count of players:");
            MinPlayers = Input.InputNoLess(1);
            Console.WriteLine("Input max count of players:");
            MaxPlayers = Input.InputNoLess(MinPlayers);
        }
        public virtual void RandomInit()
        {
            Name = Rand.RandomString();
            MinPlayers = Rand.rand.Next(0, 10);
            MaxPlayers = Rand.rand.Next(MinPlayers, 15);
        }
        public virtual bool Equals(object other)
        {
            if (other.GetType() != typeof(Game)) return false;
            else
            {
                Game obj2 = (Game)other;
                return (Name == obj2.Name) && MinPlayers == obj2.MinPlayers &&  MaxPlayers == obj2.MaxPlayers;
            }
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