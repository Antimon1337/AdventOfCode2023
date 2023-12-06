using System.Text.RegularExpressions;

String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 6 - Wait For It/input.txt");

int produkt = 1;

List<int> gameTimes = new List<int>();
List<int> records = new List<int>();

foreach(String time in input[0].Split(':')[1].Split(' ')){
    if(time.Trim() == "") continue;
    gameTimes.Add(int.Parse(time.Trim()));
}

foreach(String record in input[1].Split(':')[1].Split(' ')){
    if(record.Trim() == "") continue;
    records.Add(int.Parse(record.Trim()));
}

for(int i = 0; i < gameTimes.Count; i++){
    Console.WriteLine("Game " + (i+1) + ": ");
    int wins = 0;
    for(int timeHeld = 0; timeHeld < gameTimes[i]; timeHeld++){
        int lengthDriven = timeHeld * (gameTimes[i]-timeHeld);
        if(lengthDriven > records[i]){
            Console.WriteLine("Du gewinnst!");
            Console.WriteLine("timeHeld: " + timeHeld);
            Console.WriteLine("lengthDriven: " + lengthDriven);
            Console.WriteLine();
            wins++;
        }
    }
    produkt *= wins;
}

Console.WriteLine(produkt);