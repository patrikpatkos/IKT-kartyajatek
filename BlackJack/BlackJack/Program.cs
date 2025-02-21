using System;
using System.Collections.Generic;

class Blackjack
{
    static Random random = new Random();
    static string[] suits = { "♥", "♦", "♠", "♣" };
    static string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    static void Main()
    {
        Console.WriteLine("\r\n███████████████████████████████████████████████████████\r\n█▄─▄─▀█▄─▄████▀▄─██─▄▄▄─█▄─█─▄███▄─▄██▀▄─██─▄▄▄─█▄─█─▄█\r\n██─▄─▀██─██▀██─▀─██─███▀██─▄▀██─▄█─███─▀─██─███▀██─▄▀██\r\n▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀\n");
        int penz = 5000;
        Console.WriteLine("\nRules:\n~ Try to get as close to 21 without going over. \n~ Dealer stops hitting at 17.\n");

        while (penz > 0)
        {
            Console.WriteLine($"Money: {penz}");
            int tet = GetBet(penz);
            List<string> kartyak = GetDeck();
            List<string> osztoLap = new List<string> { HuzottLap(kartyak), HuzottLap(kartyak) };
            List<string> jatekosLap = new List<string> { HuzottLap(kartyak), HuzottLap(kartyak) };

            Console.WriteLine($"\nDealer's visible card: {osztoLap[1]}");
            Console.WriteLine($"\nYour cards: {string.Join(", ", jatekosLap)}");

            while (GetHandErtek(jatekosLap) <= 21)
            {
                Console.Write("\n[H]it or [S]tand : ");
                char move = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (move == 'H' || move == 'h')
                {
                    jatekosLap.Add(HuzottLap(kartyak));
                    Console.WriteLine($"\nYou drew: {jatekosLap[jatekosLap.Count - 1]}");
                    Console.WriteLine($"Your hand: {string.Join(",",jatekosLap)}");
                }
                else if (move == 'S' || move == 's')
                {
                    break;
                }
            }
        }
        
    }
    static int GetBet(int maxTet)
    {
        int tet;
        do
        {
            Console.Write("Enter your bet (1 - 5000): ");
        } while (!int.TryParse(Console.ReadLine(), out tet) || tet < 1 || tet > maxTet);
        return tet;
    }

    static List<string> GetDeck()
    {
        List<string> kartyak = new List<string>();
        foreach (var suit in suits)
            foreach (var rank in ranks)
                kartyak.Add($"{rank}{suit}");
        kartyak = Keveres(kartyak);
        return kartyak;
    }

    static string HuzottLap(List<string> kartyak)
    {
        string card = kartyak[0];
        kartyak.RemoveAt(0);
        return card;
    }
}


