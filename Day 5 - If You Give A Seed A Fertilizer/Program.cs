String[] input = File.ReadAllLines("C:\\Users\\kro\\Documents\\Projekte\\AdventOfCode2023\\Day 5 - If You Give A Seed A Fertilizer\\testInput.txt");

Dictionary<String, int> sectionNames = new Dictionary<string, int>
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
    bool seedRemap = false;
    int seedID = int.Parse(seed);
    foreach(String soilMap in sections[1]){
        int source = int.Parse(soilMap.Split(' ')[1]);
        int dest = int.Parse(soilMap.Split(' ')[0]);
        int range = int.Parse(soilMap.Split(' ')[2]);

        if(seedID >= source && seedID < source + range){
            for(int i = 0; i < range; i++){
                if(seedID == source + i){
                    Console.WriteLine("Seed " + seedID + " gehört zu Soil " + (dest + i));
                    seedRemap = true;
                    break;
                }
            }
        }
    }
    if(!seedRemap){
        Console.WriteLine("Seed " + seedID + " gehört zu Soil " + seedID);
    }else{
        seedRemap = false;
    }
}



Console.WriteLine("HI!");