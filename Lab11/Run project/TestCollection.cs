using System.Diagnostics;
using GameLibrary;

class TestCollection{
    TableGame[] array;
    Queue<Game> gameQueue = new Queue<Game>();
    Queue<string> stringQueue = new Queue<string>();
    SortedDictionary<Game, TableGame> gameDictionary = new SortedDictionary<Game, TableGame>();
    SortedDictionary<string, TableGame> stringDictionary = new SortedDictionary<string, TableGame>();
    public TestCollection(int size = 1000) {
        array = new TableGame[size];
        for(int i = 0; i < size; i++) {
            TableGame tableGame = new TableGame();
            array[i] = tableGame;
            tableGame.RandomInit();
            gameQueue.Enqueue((TableGame)tableGame.Clone());
            stringQueue.Enqueue(tableGame.Name);
            gameDictionary[tableGame.GetBase()] = (TableGame) tableGame.Clone();
            stringDictionary[tableGame.Name] = (TableGame) tableGame.Clone();
        }
    }
    public void Find() {
        Console.WriteLine("First:");
        Find(array[0]);
        Console.WriteLine("Center:");
        Find(array[array.Length/2]);
        Console.WriteLine("Last:");
        Find(array[^1]);
    }
    public void Find(TableGame game) {
        Stopwatch 
            sgq = Find(game, gameQueue),
            ssq = Find(game.Name, stringQueue),
            sgdk = FindKey(game.GetBase(), gameDictionary),
            ssdk = FindKey(game.Name, stringDictionary), 
            sgdv = FindVal(game, gameDictionary), 
            ssdv = FindVal(game, stringDictionary);
        Console.WriteLine(
            $"""
            Find in game queue taken {sgq.ElapsedTicks}.
            Find in string queue taken {ssq.ElapsedTicks}.
            Find key in game dict taken {sgdk.ElapsedTicks}.
            Find key in string dict taken {ssdk.ElapsedTicks}.
            Find value in game dict taken {sgdv.ElapsedTicks}.
            Find value in string dict taken {ssdv.ElapsedTicks}.
            """
        );
    }
    public Stopwatch Find<T>(T obj, Queue<T> queue) {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        bool found = queue.Contains(obj);
        stopwatch.Stop();
        if (!found) Console.WriteLine("Object not found!");
        return stopwatch;
    }
    public Stopwatch FindKey<T>(T key, SortedDictionary<T, TableGame> dict) {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        bool found = dict.ContainsKey(key);
        stopwatch.Stop();
        if (!found) Console.WriteLine("Object not found!");
        return stopwatch;
    }
    public Stopwatch FindVal<T>(TableGame val, SortedDictionary<T, TableGame> dict) {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        bool found = dict.ContainsValue(val);
        stopwatch.Stop();
        if (!found) Console.WriteLine("Object not found!");
        return stopwatch;
    }
}