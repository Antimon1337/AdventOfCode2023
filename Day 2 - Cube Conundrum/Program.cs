// See https://aka.ms/new-console-template for more information
String[] input = File.ReadAllLines("/Users/fabiankrohn/Projekte/AdventOfCode2023/Day 2 - Cube Conundrum/testInput.txt");

String[] cubeColors = new String[]{
    "red",
    "green",
    "blue"
};


Dictionary<String, int> availableCubes = new Dictionary<string, int>();
availableCubes.Add("red", 12);
availableCubes.Add("green", 13);
availableCubes.Add("blue", 14);


Dictionary<String, int> shownCubesInGame = new Dictionary<string, int>();


foreach(String line in input){
    String gameResult = line.Split(':')[1];

    String[] pullResults = gameResult.Split(';');

    foreach(String pull in pullResults){
        //Console.WriteLine(pull);

        String[] cubePull = pull.Split(',');
        foreach(String cubes in cubePull){
            Console.WriteLine(cubes);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine();
}