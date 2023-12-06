String[] input = File.ReadAllLines("C:\\Users\\kro\\Documents\\Projekte\\AdventOfCode2023\\Day 5 - If You Give A Seed A Fertilizer\\testInput.txt");

List<List<String>> sections = new List<List<String>>();

List<String> section = new List<string>();

foreach(String line in input){
    if(line == ""){
        sections.Add(section);
        section = new List<string>();
        continue;
    }
    section.Add(line);
}

Console.WriteLine("HI!");