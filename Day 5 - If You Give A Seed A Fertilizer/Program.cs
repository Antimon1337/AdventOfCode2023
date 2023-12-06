using System.Reflection.Metadata;

String[] input = File.ReadAllLines("/Users/fabiankrohn/Projects/AdventOfCode2023/Day 5 - If You Give A Seed A Fertilizer/input.txt");

Dictionary<String, long> sectionNames = new Dictionary<string, long>
Dictionary<String, long> sectionNames = new Dictionary<string, long>
{
    { "seeds", 0 },
    { "seed-to-soil", 1 },
    { "soil-to-fertilizer", 2 },
    { "fertilizer-to-water", 3 },
    { "water-to-light", 4 },
    { "light-to-temperature", 5 },
    { "temperature-to-humidity", 6 },
    { "humidity-to-location", 7 }
};

Dictionary<long, long> seed2dest = new Dictionary<long, long>();

Dictionary<long, long> seed2dest = new Dictionary<long, long>();

List<List<String>> sections = new List<List<String>>();

List<String> section = new List<string>();

foreach(String line in input){
    if(line == ""){
        sections.Add(section);
        section = new List<string>();
        continue;
    }
    if(line.Contains("seeds")){
        section.Add(line.Split(':')[1].Trim());
    }
    if(line.Contains(":")){
        continue;
    }
    section.Add(line);
}
sections.Add(section);

long anzahl = 0;
long nummer = 0;

for(int s = 0; s<sections[0][0].Split(' ').Length; s+=2){
    long seed = long.Parse(sections[0][0].Split(' ')[s]);
    long seedRange = long.Parse(sections[0][0].Split(' ')[s+1]);
    anzahl += seedRange;
    for(long j = 0; j < seedRange; j++){
        long seedID = seed + j;
        seed2dest.Add(seedID, seedID);
        for(int m = 1; m < sections.Count; m++){
            foreach(String map in sections[m]){
                long source = long.Parse(map.Split(' ')[1]);
                long dest = long.Parse(map.Split(' ')[0]);
                long range = long.Parse(map.Split(' ')[2]);

                if(seed2dest[seedID] >= source && seed2dest[seedID] < source + range){
                    bool alreadyRemapped = false;
                    for(int i = 0; i < range; i++){
                        if(seed2dest[seedID] == source + i){
                            seed2dest[seedID] = dest + i;
                            alreadyRemapped = true;
                            break;
                        }
                    }
                    if(alreadyRemapped) break;
                }
            }
        }
        nummer++;
        Console.WriteLine("Seed " + seedID + " gehört zu " + seed2dest[seedID]);
        Console.WriteLine("Calculated " + nummer + " of " + anzahl + " seeds");
    }
}

long lowestNumber = long.MaxValue;

foreach(KeyValuePair<long, long> entry in seed2dest){
    //Console.WriteLine("Seed " + entry.Key + " gehört zu " + entry.Value);
    if(entry.Value < lowestNumber){
        lowestNumber = entry.Value;
    }
}

Console.WriteLine("Die Location mit dem geringsten Wert ist " + lowestNumber);
Console.WriteLine("Die Location mit dem geringsten Wert ist " + lowestNumber);