using GameLibrary;

class TestCollection{
    Queue<Game> gameQueue = new Queue<Game>();
    Queue<string> stringQueue = new Queue<string>();
    SortedDictionary<Game, TableGame> gameDictionary = new SortedDictionary<Game, TableGame>();
    SortedDictionary<string, TableGame> stringDictionary = new SortedDictionary<string, TableGame>();
    public TestCollection(int size = 1000) {
        for(int i = 0; i < size; i++) {
            TableGame tableGame = new TableGame();
            tableGame.RandomInit();
            gameQueue.Enqueue((TableGame)tableGame.Clone());
            stringQueue.Enqueue(tableGame.Name);
            gameDictionary[tableGame.GetBase()] = (TableGame) tableGame.Clone();
            stringDictionary[tableGame.Name] = (TableGame) tableGame.Clone();
        }

    }
}