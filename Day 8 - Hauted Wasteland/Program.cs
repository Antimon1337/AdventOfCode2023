String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 8 - Hauted Wasteland/input.txt");

String steps = input[0];
String ort = "AAA";
Dictionary<String, String[]> map = new Dictionary<string, string[]>();

int stepCount = 0;

foreach(String direction in input){
    if(!direction.Contains("=")) continue;

    String start = direction.Split('=')[0].Trim();

    String[] ziele = direction.Split('=')[1].Replace(" ", "").Replace("(", "").Replace(")", "").Split(',');

    map.Add(start, ziele);
}

while(ort != "ZZZ"){
    foreach(char step in steps){
        stepCount++;
        String[] neuerOrt;
        map.TryGetValue(ort, out neuerOrt);

        if(step == 'L'){
            ort = neuerOrt[0];
        }
        if(step == 'R'){
            ort = neuerOrt[1];
        }
        if(ort == "ZZZ") break;
    }
}

Console.WriteLine(stepCount);