using System;
using System.Collections.Generic;
using System.Xml.Schema;

//- Man bestämmer ett ord
//- Man skriver ut så många streck som det finns bokstäver i ordet
//- Man gissar en bokstav
//- Kolla om det är rätt eller fel (finns med minst 1 gång i ordet)
//  -Rätt: skriver ut bokstaven på rätt plats
//  -Fel: Man blir av med 1 gissning, ritar ut en till dwel av gubben och bokstaven skrivs upp
//- Ny gissning
//  Om inte de står en bokstav på alla streck
//  Eller om man fått slut på gissningar

string[] possibleWords = { "alhamdulillah", "bil", "stålö", "flaska", "hund" };

Random rand = new Random();
string guessWord = possibleWords[rand.Next(0, possibleWords.Length)];
int maxGuesses = 10;

List<string> wrongGuesses = new();
List<string> underScores = MakeUnderscores(guessWord);

//string.Join("",underScores) != guessWord

while (wrongGuesses.Count < maxGuesses || underScores.Contains("_"))
{
    System.Console.WriteLine("Gissa vilket ord du fått!");
    System.Console.WriteLine(string.Join(" ", underScores));

    string guess = GiveMeAGuess();

    System.Console.WriteLine($"Du gissade {guess}!");

    if (guessWord.Contains(guess))
    {
        for (int i = 0; i < guessWord.Length; i++)
        {
            if (guessWord[i].ToString() == guess)
            {
                underScores[i] = guess;
            }
        }
        System.Console.WriteLine("Rätt!");
    }
    else
    {
        wrongGuesses.Add(guess);
        System.Console.WriteLine("Fel!");
        System.Console.WriteLine($"Du har {maxGuesses - wrongGuesses.Count} gissningar kvar");
    }
    System.Console.WriteLine("");
}
System.Console.WriteLine("DU VANN");


Console.ReadLine();

static List<string> MakeUnderscores(string guessWord)
{
    List<string> underScores = new();
    for (int i = 0; i < guessWord.Length; i++)
    {
        underScores.Add("_");
    }

    return underScores;
}

static string GiveMeAGuess()
{
    string guess = "";


    while (guess.Length != 1)
    {
        guess = Console.ReadLine();
    }

    return guess;
}