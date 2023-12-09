String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 8 - Hauted Wasteland/input.txt");

String steps = input[0];
List<String> orte = new List<string>();
List<long> orteLoop = new List<long>();
List<String> seenOrte = new List<string>();
Dictionary<String, String[]> map = new Dictionary<string, string[]>();

int stepCount = 0;

foreach(String direction in input){
    if(!direction.Contains("=")) continue;

    String start = direction.Split('=')[0].Trim();

    String[] ziele = direction.Split('=')[1].Replace(" ", "").Replace("(", "").Replace(")", "").Split(',');

    map.Add(start, ziele);
}

foreach(KeyValuePair<String, String[]> direction in map){
    if(direction.Key.EndsWith("A")){
        orte.Add(direction.Key);
    }
}

Console.WriteLine("Startorte: " + orte.Count);

foreach(String ort in orte){
    orteLoop.Add(0);
}


for(int i = 0; i < orte.Count; i++){
    bool loopGefunden = false;
    while(orteLoop[i] == 0){
        foreach(char step in steps){
            stepCount++;

            String[] neuerOrt;
            map.TryGetValue(orte[i], out neuerOrt);

            if(step == 'L'){
                orte[i] = neuerOrt[0];
            }
            if(step == 'R'){
                orte[i] = neuerOrt[1];
            }

            if(seenOrte.Contains(neuerOrt[0]) || seenOrte.Contains(neuerOrt[1])){
                if(loopGefunden){
                    orteLoop[i] = stepCount;
                    stepCount = 0;
                    break;
                }
                stepCount = 0;
                seenOrte.Clear();
                loopGefunden = true;
            }

            seenOrte.Add(orte[i]);
        }
    }
}

Console.WriteLine(calculateLCM(orteLoop.ToArray()));

return;

long gcd(long n1, long n2)
    {
        if (n2 == 0)
        {
            return n1;
        }
        else
        {
            return gcd(n2, n1 % n2);
        }
    }

long calculateLCM(long[] numbers)
{
    return numbers.Aggregate((S, val) => S * val / gcd(S, val));
}

//
//Old brute force solution
//
while(!allOnZ()){
    foreach(char step in steps){
        stepCount++;
        for(int i = 0; i<orte.Count; i++){
            //if(orte[i].EndsWith("Z")) Console.WriteLine("Ich wäre bei einem Z");
            String[] neuerOrt;
            map.TryGetValue(orte[i], out neuerOrt);

            if(step == 'L'){
                orte[i] = neuerOrt[0];
            }
            if(step == 'R'){
                orte[i] = neuerOrt[1];
            }
            //if(orte[i] == "ZZZ") break;
        }
    }
}

Console.WriteLine(stepCount);

bool allOnZ(){
    int orteBeiZ = 0;
    foreach(String ort in orte){
        if(!ort.EndsWith("Z")){
            //Console.WriteLine("Orte bei Z: " + orteBeiZ);
            return false;
        }else{
            orteBeiZ++;
        }
    }
    return true;
}