String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 9 - Mirage Maintenance/testInput.txt");

for(int i = 0; i < input.Length; i++){
    List<long> sequence = new List<long>();
    foreach(String s in input[i].Split(' ')){
        sequence.Add(int.Parse(s));
    }

    List<long> differenzen = sequence;
    while(!differenzenOK(differenzen)){
        for(int j = 0; j < differenzen.Count-1; j++){
            differenzen.Add(differenzen[j+1] - differenzen[j]);
            Console.WriteLine(differenzen[j+1] - differenzen[j]);
            
        }
    }
    Console.WriteLine();   
}

bool differenzenOK(List<long> diff){
    bool notok = true;
    foreach(long d in diff){
        if(d != 0){
            notok = false;
        }
    }
    return notok;
}