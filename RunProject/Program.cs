using System.Diagnostics;
using GameLibrary;
using InputLibrary;

static Game InputGameType()
{
    Console.WriteLine("Input type of game (no/table/video/vr)");
    switch (ConsoleInput.MEAN_PART.transform(Checks.Check(Checks.Into(["no", "table", "video", "vr"]), "Type of game must be no, table, video or vr")).get())
    {
        case "no":
            return new Game();
        case "table":
            return new TableGame();
        case "video":
            return new VideoGame();
        default:
            return new VRGame();
    }
}

Console.WriteLine("Task 1");
List<Game> gameList = new List<Game>();
Console.WriteLine("Input count of objects:");
int games_count = ConsoleInput.NATURAL.get();
for (int i = 0; i < games_count; i++)
{
    Console.WriteLine("Print method of object crating (input/random)");
    switch (ConsoleInput.MEAN_PART.transform(Checks.Check(Checks.Into(["random", "input"]), "mode must be random or input")).get())
    {
        case "random":
            switch (Rand.rand.Next(2, 5))
            {
                case 2:
                    gameList.Add(new Game());
                    break;
                case 3:
                    gameList.Add(new TableGame());
                    break;
                case 4:
                    gameList.Add(new VideoGame());
                    break;
                case 5:
                    gameList.Add(new VRGame());
                    break;
            }
            gameList[i].RandomInit();
            break;
        case "input":
            gameList.Add(InputGameType());
            gameList[i].Init();
            break;
    }
}

Console.WriteLine("Task 2");
bool stopTask2 = false;
do{
    Console.WriteLine("Input command (show/count_type/max_max_players/min_min_players/stop)");
    switch (ConsoleInput.MEAN_PART.check(Checks.Into(["show", "count_type", "max_max_players", "min_min_players", "stop"]), "Command must be one of show, count_type, max_max_players, min_min_players, stop").get())
    {
        case "show":
            foreach (Game el in gameList) el.Show();
            break;
        case "count_type":
            int count_type = 0;
            Console.WriteLine("Input type of game (table/video/vr)");
            switch (ConsoleInput.MEAN_PART.transform(Checks.Check(Checks.Into(["table", "video", "vr"]), "Type of game must be table, video or vr")).get())
            {
                case "table":
                    foreach (Game el in gameList)
                    {
                        if (el is TableGame)
                        {
                            count_type++;
                        }
                    }
                    break;
                case "video":
                    foreach (Game el in gameList)
                    {
                        if (el is VideoGame)
                        {
                            count_type++;
                        }
                    }
                    break;
                case "vr":
                    foreach (Game el in gameList)
                    {
                        if (el is VRGame)
                        {
                            count_type++;
                        }
                    }
                    break;
            }
            Console.WriteLine($"Count of those games is {count_type}");
            break;
        case "max_max_players":
            Game mx = gameList.MaxBy((game) => game.MaxPlayers);
            Console.WriteLine($"Maximum of maximum count of players is {mx.MaxPlayers} (in game named {mx.Name})");
            break;
        case "min_min_players":
            Game mn = gameList.MinBy((game) => game.MaxPlayers);
            Console.WriteLine($"Minimum of minimum count of players is {mn.MaxPlayers} (in game named {mn.Name})");
            break;
        case "stop":
            stopTask2 = true;
            break;
    }
} while (!stopTask2) ;

Console.WriteLine("Task 3");

gameList.Sort();
Console.WriteLine("Sorteg games list:");
foreach (Game game in gameList) game.Show();

List<IPrintable> commonList = new List<IPrintable>();

Console.WriteLine("Input count of objects:");
int count = ConsoleInput.NATURAL.get();
for (int i = 0; i < count; i++)
{
    Console.WriteLine("Print method of object crating (input/random)");
    switch (ConsoleInput.MEAN_PART.transform(Checks.Check(Checks.Into(["random", "input"]), "mode must be random or input")).get())
    {
        case "random":
            switch (Rand.rand.Next(1, 5))
            {
                case 1:
                    commonList.Add(new Dish());
                    break;
                case 2:
                    commonList.Add(new Game());
                    break;
                case 3:
                    commonList.Add(new TableGame());
                    break;
                case 4:
                    commonList.Add(new VideoGame());
                    break;
                case 5:
                    commonList.Add(new VRGame());
                    break;
            }
            commonList[i].RandomInit();
            break;
        case "input":
            Console.WriteLine("Print type of object (dish/game)");
            switch (ConsoleInput.MEAN_PART.transform(Checks.Check(Checks.Into(["dish", "game"]), "Type must be dish or game")).get())
            {
                case "dish":
                    commonList.Add(new Dish());
                    break;
                case "game":
                    commonList.Add(InputGameType());
                    break;
            }
            commonList[i].Init();
            break;
    }
    commonList[i].Show();
}
foreach (var (name, type) in new SortedDictionary<string, Type>()
{
    { "dishes", typeof(Dish) },
    {"games", typeof(Game) },
    {"table games", typeof(TableGame) },
    {"video games", typeof(VideoGame) },
    {"vr game", typeof(VideoGame) }
})
{
    Console.WriteLine($"Count of {name} is {commonList.Count((obj) => obj.GetType().IsSubclassOf(type))}");
}


