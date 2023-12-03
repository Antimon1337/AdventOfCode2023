// See https://aka.ms/new-console-template for more information
String[] input = File.ReadAllLines("/Users/fabiankrohn/Projects/AdventOfCode2023/Day 3 - Gear Ratios/input.txt");

int zeilenLänge = 0;

foreach(String s in input){
    if(s.Length > zeilenLänge){
        zeilenLänge = s.Length;
    }
}

int summe = 0;


String gefundeneZahl;
bool valid;

for(int i = 0; i < zeilenLänge; i++){

    gefundeneZahl = "";
    valid = false;
    for(int j = 0; j < input.Length; j++){
        String zeichen = input[i].ElementAt(j).ToString();
        //Console.Write(zeichen);

        if(int.TryParse(zeichen, out int zahl)){
            gefundeneZahl += zahl.ToString();
            valid = RundrumSchaun(j, i);
            
        }else{
            if(valid){
                int.TryParse(gefundeneZahl, out int summand);
                summe += summand;
                Console.Write("Zeile " + (i+1) + ": ");
                Console.Write(gefundeneZahl);
                Console.WriteLine(" YAY!");
            }

            gefundeneZahl = "";
            valid = false;
        }

    }
    if(valid){
        int.TryParse(gefundeneZahl, out int summand);
        summe += summand;
        Console.Write("Zeile " + (i+1) + ": ");
        Console.Write(gefundeneZahl);
        Console.WriteLine(" YAY!");
    }
    Console.WriteLine();
}

Console.WriteLine(summe);

bool RundrumSchaun(int x, int y){
    if(valid){
        return true;
    }

    if(x >= 1 && y >= 1){
        if(IsSymbol(input[y-1].ElementAt(x-1).ToString())){
            return true;
        }
    }
    if(y >= 1 && x < input.Length-1){
        if(IsSymbol(input[y-1].ElementAt(x+1).ToString())){
            return true;
        }
    }
    if(y >= 1){
        if(IsSymbol(input[y-1].ElementAt(x).ToString())){
            return true;
        }
    }
    if(x >= 1){
        if(IsSymbol(input[y].ElementAt(x-1).ToString())){
            return true;
        }
    }
    if(x < input.Length-1){
        if(IsSymbol(input[y].ElementAt(x+1).ToString())){
            return true;
        }
    }
    if(y < zeilenLänge-1 && x > 1){
        if(IsSymbol(input[y+1].ElementAt(x-1).ToString())){
            return true;
        }
    }
    if(y < zeilenLänge-1){
        if(IsSymbol(input[y+1].ElementAt(x).ToString())){
            return true;
        }
    }
    if(y < zeilenLänge-1 && x < input.Length-1){
        if(IsSymbol(input[y+1].ElementAt(x+1).ToString())){
            return true;
        }
    }

    return false;
}

bool IsSymbol(String zeichen){
    if(!int.TryParse(zeichen, out _) && zeichen != "."){
        return true;
    }
    return false;
}