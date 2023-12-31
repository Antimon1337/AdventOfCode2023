﻿// See https://aka.ms/new-console-template for more information
String[] input = File.ReadAllLines("/Users/fabiankrohn/Projects/AdventOfCode2023/Day 2 - Cube Conundrum/input.txt");

String[] cubeColors = new String[]{
    "red",
    "green",
    "blue"
};


Dictionary<String, int> availableCubes = new Dictionary<string, int>();
availableCubes.Add("red", 12);
availableCubes.Add("green", 13);
availableCubes.Add("blue", 14);


int summe = 0;
int summepower = 0;

foreach(String line in input){
    int gameID = int.Parse(line.Split(':')[0].Split(' ')[1]);

    // Console.WriteLine("GameID: " + gameID);
    
    bool stillValid = true;

    String gameResult = line.Split(':')[1];

    String[] pullResults = gameResult.Split(';');

    Dictionary<String, int> highestShownCubeColor = new Dictionary<string, int>();
    highestShownCubeColor.Add("red", 0);
    highestShownCubeColor.Add("blue", 0);
    highestShownCubeColor.Add("green", 0);

    foreach(String pull in pullResults){
        //Console.WriteLine(pull);

        String[] cubePull = pull.Split(',');

        foreach(String c in cubePull){
            //Console.WriteLine(cubes);

            String cubes = c.Trim();

            String color = cubes.Split(' ')[1];
            int number = int.Parse(cubes.Split(' ')[0]);

            availableCubes.TryGetValue(color, out int verfügbar);

            if(number > verfügbar){
                stillValid = false;
            }

            highestShownCubeColor.TryGetValue(color, out int highNumber);
            if(number > highNumber){
                highestShownCubeColor[color] = number;
            }
        }

        //Console.WriteLine();
    }
    if(stillValid){
        Console.WriteLine("GameID " + gameID + " ist ok!");
        summe += gameID;
    }
    int produkt = 1;
    foreach(int value in highestShownCubeColor.Values){
        produkt *= value;
    }
    Console.WriteLine("Produkt: " + produkt);
    summepower += produkt;
    //Console.WriteLine();
    //Console.WriteLine();
}

Console.WriteLine("Ergebnis Part 1: " + summe);
Console.WriteLine("Ergebnis Part 2: " + summepower);