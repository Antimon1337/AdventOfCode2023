String[] input = File.ReadAllLines("/Users/fabiankrohn/Projects/AdventOfCode2023/Day 4 - Scratchcards/input.txt");

int summe = 0;
foreach(String card in input){
    String[] winningNumbersStr = card.Split(':')[1].Split('|')[0].Trim().Split(' ');
    String[] myNumbersStr = card.Split(':')[1].Split('|')[1].Trim().Split(' ');

    List<int> winningNumbers = new List<int>();
    foreach(String number in winningNumbersStr){
        if(number == "") continue;
        winningNumbers.Add(int.Parse(number));
    }

    List<int> myNumbers = new List<int>();
    foreach(String number in myNumbersStr){
        if(number == "") continue;
        myNumbers.Add(int.Parse(number));
    }

    int gewonneneZahlen = -1;

    foreach(int nummer in myNumbers){
        if(winningNumbers.Contains(nummer)){
            gewonneneZahlen++;
        }
    }
    summe += (int)Math.Pow(2, gewonneneZahlen);
}

Console.WriteLine(summe);