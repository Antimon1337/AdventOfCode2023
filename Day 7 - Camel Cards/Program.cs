String[] input = File.ReadAllLines("C:\\Users\\kro\\Documents\\Projekte\\AdventOfCode2023\\Day 7 - Camel Cards\\testInput.txt");

List<String> hands = new List<string>();
List<int> bids = new List<int>();

Dictionary<String, int> cardPower = new Dictionary<string, int>{
    {"A", 14},
    {"K", 13},
    {"Q", 12},
    {"J", 11},
    {"T", 10},
    {"9", 9},
    {"8", 8},
    {"7", 7},
    {"6", 6},
    {"5", 5},
    {"4", 4},
    {"3", 3},
    {"2", 2}
};

foreach(String s in input){
    hands.Add(s.Split(' ')[0]);
    bids.Add(int.Parse(s.Split(' ')[1]));
}

foreach(String hand in hands){
    List<char> cards = hand.ToList();
    cards.Sort();
    int count = cards.Count;

    for(int c = 0; c < cards.Count-1; c++){
        if(cards[c] != cards[c+1]){
            cards.Insert(c+1, ';');
            c+=1;
        }
    }

    for(int c = 0; c < cards.Count; c++){
        Console.Write(cards[c]);
    }

    String[] cardCombos = new string(cards.ToArray()).Split(';');



    Console.WriteLine();
}