namespace GroupProjectBiblotek
{
    

    class Program
    {
        static void Main(string[] args)
        {
            UserInteraktion userInteraktion = new UserInteraktion();

            // Inloggning med kod
            if (userInteraktion.Login())
            {
                // Om inloggning lyckades, kör menyn
                int val = 0;

                while (val != 4)  // Programmet fortsätter tills användaren väljer att avsluta
                {
                    userInteraktion.VisaMeny();
                    val = LäsMenyVal();  // Anropar en metod för att läsa användarens menyval

                    userInteraktion.HanteraVal(val);
                }

                
            }
            else
            {
                // Om inloggningen misslyckas
                Console.WriteLine("Felaktig kod. Programmet avslutas.");
            }
        }

        // Metod för att läsa och validera menyval
        private static int LäsMenyVal()
        {
            int val = 0;
            bool validerat = false;
            int[] giltigaVal = { 1, 2, 3, 4 };  // Array över tillåtna menyval

            while (!validerat)
            {
                Console.Write("Välj ett alternativ: ");
                string input = Console.ReadLine()!;

                // Manuell validering: kontrollera om inmatningen är ett giltigt heltal
                if (input.Length > 0 && ÄrNumerisk(input))  // Kontrollera om input består av siffror
                {
                    int tempVal = 0;

                    // Manuell konvertering av sträng till heltal
                    foreach (char c in input)
                    {
                        tempVal = tempVal * 10 + (c - '0');  // Omvandlar varje tecken till motsvarande siffra
                    }

                    // Kontrollera om tempVal är ett giltigt alternativ
                    bool giltigtVal = false;
                    foreach (int alternativ in giltigaVal)
                    {
                        if (tempVal == alternativ)
                        {
                            val = tempVal;  // Sätt val till det konverterade värdet
                            giltigtVal = true;
                            validerat = true;  // Om det är ett giltigt nummer och inom intervallet 1–3
                            break;  // Bryt loopen när ett giltigt val hittas
                        }
                    }

                    // Om inget matchande alternativ hittades
                    if (!giltigtVal)
                    {
                        Console.WriteLine("Ogiltigt val. Vänligen ange ett nummer mellan 1 och 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt nummer.");
                }
            }
            return val;
        }        
        private static bool ÄrNumerisk(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')  // Om tecknet inte är en siffra
                {
                    return false;
                }
            }
            return true;
        }
    }

}
