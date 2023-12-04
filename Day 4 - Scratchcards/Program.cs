List<String> input = File.ReadAllLines("/Users/fabiankrohn/Projects/AdventOfCode2023/Day 4 - Scratchcards/input.txt").ToList();

List<int> copies = new List<int>();
foreach(String s in input){
    copies.Add(1);
}

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

    //Part for Part 1
    // int gewonneneZahlen = -1;
    int gewonneneZahlen = 0;

    //Part of Part 1
    // foreach(int nummer in myNumbers){
    //     if(winningNumbers.Contains(nummer)){
    //         gewonneneZahlen++;
    //     }
    // }
    for(int j = 0; j < myNumbers.Count; j++){
        if(winningNumbers.Contains(myNumbers[j])){
            gewonneneZahlen++;
            
            for(int i = 0; i < copies[input.IndexOf(card)]; i++){
                copies[input.IndexOf(card)+gewonneneZahlen] += 1;
            }
        }
    }
    //Part of Part 1
    //summe += (int)Math.Pow(2, gewonneneZahlen);
}
foreach(int copy in copies){
    summe += copy;
}
Console.WriteLine(summe);