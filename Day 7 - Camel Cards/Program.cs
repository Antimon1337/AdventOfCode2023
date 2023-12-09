String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 7 - Camel Cards/input.txt");

List<String> hands = new List<string>();
List<String> orderedHands = new List<string>();
List<int> bids = new List<int>();
List<String> ranking = new List<String>();

int bestHandIndex = -1;

int summe = 0;

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

    orderedHands.Add(new string(cards.ToArray()));

}

for(int j = 0; j < orderedHands.Count; j++){
    if(bestHandIndex == -1){
        bestHandIndex = j;
        ranking.Insert(0, hands[j]);
        continue;
    }

    bool thisHandIsBetter = isThisHandBetter(j, bestHandIndex);

    if(thisHandIsBetter){
        bestHandIndex = j;
        ranking.Insert(0, hands[j]);
    }else{
        for(int i = 0; i<ranking.Count; i++){
            int rankingHandIndex = hands.IndexOf(ranking[i]);
            if(isThisHandBetter(j, rankingHandIndex)){
                thisHandIsBetter = true;
                ranking.Insert(ranking.IndexOf(ranking[i]), hands[j]);
                break;
            }
        }
        if(!thisHandIsBetter){
            ranking.Insert(ranking.Count, hands[j]);
        }
    }
}

for(int i = 0; i < ranking.Count; i++){
    Console.WriteLine("Rang: " + (i+1) + " \t" + ranking[i] + "\t" + bids[hands.IndexOf(ranking[i])]);
    summe += bids[hands.IndexOf(ranking[i])] * (ranking.Count - i);
}

Console.WriteLine(summe);

bool isThisHandBetter(int handIndex, int bestHandIndex){
    bool thisHandIsBetter = false;

    String[] cardCombo = orderedHands[handIndex].Split(';');
    String[] bestCardCombo = orderedHands[bestHandIndex].Split(';');

    decimal bestCombo = cardCombo.OrderByDescending( s => s.Length).First().Length;
    decimal bestbestCombo = bestCardCombo.OrderByDescending( s => s.Length).First().Length;

    if(bestCombo == 3){
        foreach(String combo in cardCombo){
            if(combo.Length == 2){
                bestbestCombo += 0.5m;
            }
        }
    }
    if(bestbestCombo == 3){
        foreach(String combo in bestCardCombo){
            if(combo.Length == 2){
                bestbestCombo += 0.5m;
            }
        }
    }
    if(bestCombo == 2){
        bool alreadyPair = false;
        foreach(String combo in cardCombo){
            if(combo.Length == 2 && alreadyPair){
                bestCombo += 0.5m;
            }
            if(combo.Length == 2){
                alreadyPair = true;
                continue;
            }
        }
    }
    if(bestbestCombo == 2){
        bool alreadyPair = false;
        foreach(String combo in bestCardCombo){
            if(combo.Length == 2 && alreadyPair){
                bestbestCombo += 0.5m;
            }
            if(combo.Length == 2){
                alreadyPair = true;
                continue;
            }
        }
    }

    if(bestCombo == bestbestCombo){
        for(int i = 0; i < hands[0].Length; i++){
            int cardValue;

            cardPower.TryGetValue(hands[handIndex][i].ToString(), out cardValue);
            
            int bestcardValue;

            cardPower.TryGetValue(hands[bestHandIndex][i].ToString(), out bestcardValue);

            if(cardValue > bestcardValue){
                thisHandIsBetter = true;
                break;
            }
            if(bestcardValue > cardValue){
                thisHandIsBetter = false;
                break;
            }
        }
    }

    if(bestCombo > bestbestCombo){
        thisHandIsBetter = true;
    }

    if(thisHandIsBetter){
        return true;
    }
    return false;
}