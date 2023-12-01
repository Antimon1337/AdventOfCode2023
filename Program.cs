// See https://aka.ms/new-console-template for more information
String[] input = File.ReadAllLines("/Users/fabiankrohn/Projects/Day 1 - Trebuchet/input.txt");
String[] digits = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

int zeile = 1;
int summe = 0;

foreach(String s in input){
    Console.Write(zeile + ": " + s + " ");
    zeile++;
    List<int> gefundenePositionen = new List<int>();
    int d1 = 0;
    int d2 = 0;

    foreach(String zahl in digits){
        if (s.Contains(zahl)){
            int ort = s.IndexOf(zahl);
            gefundenePositionen.Add(ort);
        }
    }
    
    for(int i = 0; i<s.Length; i++){
        String c = s[i].ToString();
        if(int.TryParse(c, out _)){
            gefundenePositionen.Add(i);
        }
    }
    
    gefundenePositionen.Sort();

    d1 = GetIntAtPosition(s, gefundenePositionen.First());

    d2 = GetIntAtPosition(s, gefundenePositionen.Last());
    

    // for(int i = 0; i<s.Length; i++){
    //     String c = s[i].ToString();
    //     if(int.TryParse(c, out d1)){
    //         break;
    //     }
    // }

    // for(int i = s.Length-1; i>=0; i--){
    //     String c = s[i].ToString();
    //     if(int.TryParse(c, out d2)){
    //         break;
    //     }
    // }
    int wert = int.Parse(d1.ToString() + d2.ToString());
    Console.WriteLine(wert);
    summe += wert;
}
Console.WriteLine(summe);

bool ContainsAny(String s, String [] liste, out String outStr){
    foreach(String str in liste){
        if (s.Contains(str)){
            Console.WriteLine(s.IndexOf(str));
            outStr = str;
            return true;
        }
    }
    outStr = "";
    return false;
}

int ConvertWordToInt(String zahl){
    switch(zahl){
        case "one":
            return 1;
        case "two":
            return 2;
        case "three":
            return 3;
        case "four":
            return 4;
        case "five":
            return 5;
        case "six":
            return 6;
        case "seven":
            return 7;
        case "eight":
            return 8;
        case "nine":
            return 9;
        default:
            return 0;
    }
}

int GetIntAtPosition(String s, int pos){
    if(int.TryParse(s[pos].ToString(), out int temp)){
        
    }else{
        temp = 0;
        int länge = 0;
        while(temp == 0){
            String str = s.Substring(pos, länge);
            temp = ConvertWordToInt(str);
            länge++;
        }
    }
    return temp;
}