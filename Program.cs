using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Välkommen till transaktionsprogrammet!");
        Console.Write("Är det inkommande(1) eller utgående(2) transaktion? ");
        string transaktionstyp = Console.ReadLine();

        List<string> transaktioner = new List<string>();

        while (true)
        {
            Console.Write("Ange datum (YYYY-MM-DD) eller tryck Enter för att avsluta: ");
            string datum = Console.ReadLine();
            if (string.IsNullOrEmpty(datum))
                break;

            Console.Write("Ange belopp: ");
            double belopp = double.Parse(Console.ReadLine());

            Console.Write("Ange typ: ");
            string typ = Console.ReadLine();

            // Beräkna momsen och skatten
            double moms = belopp * 0.20;
            double skatt = belopp * 0.25;

            // Formatera transaktionsdata
            string transaktion = $"{datum}\t{belopp} kr\t\t{typ}\t\t{moms} kr moms\t\t{skatt} kr skatt";

            if (transaktionstyp.Equals("inkommande", StringComparison.OrdinalIgnoreCase) || transaktionstyp.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                // Lägg till i Inkommande.txt
                File.AppendAllText(@"C:\Users\jacob\Desktop\Thosell\Inkommande.txt", transaktion + Environment.NewLine, Encoding.UTF8);
            }
           else if (transaktionstyp.Equals("utgående", StringComparison.OrdinalIgnoreCase) || transaktionstyp.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                // Lägg till i Utgående.txt
                File.AppendAllText(@"C:\Users\jacob\Desktop\Thosell\Utgående.txt", transaktion + Environment.NewLine, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("Ogiltig transaktionstyp. Ange 'inkommande' eller 'utgående'.");
            }
        }
    }
}
