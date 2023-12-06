using System.Reflection.Metadata;

String[] input = File.ReadAllLines("C:\\Users\\kro\\Documents\\Projekte\\AdventOfCode2023\\Day 5 - If You Give A Seed A Fertilizer\\input.txt");

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

foreach(String seed in sections[0][0].Split(' ')){
    long seedID = long.Parse(seed);
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
                    }
                }
                if(alreadyRemapped) break;
            }
        }
    }
    Console.WriteLine("Seed " + seedID + " gehört zu " + seed2dest[seedID]);
    Console.WriteLine("Calculated " + (sections[0][0].Split(' ').ToList().IndexOf(seed)+1) + " of " + sections[0][0].Split(' ').Length + " seeds");
}

long lowestNumber = long.MaxValue;

foreach(KeyValuePair<long, long> entry in seed2dest){
    //Console.WriteLine("Seed " + entry.Key + " gehört zu " + entry.Value);
    if(entry.Value < lowestNumber){
        lowestNumber = entry.Value;
    }
}

Console.WriteLine("Die Location mit dem geringsten Wert ist " + lowestNumber);