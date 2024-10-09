namespace GroupProjectBiblotek

{
       public class UserInteraktion
    {
        private List<Bok> bokLista = new List<Bok>();

        // Metod för att logga in användaren
        public bool Login()
        {
            const string korrectKod = "1234"; // Fördefinierad kod

            Console.WriteLine("Välkommen till bibliotek G4");
            Console.WriteLine("Ange din 4 siffriga kod för att logga in:");
            string angivenKod = Console.ReadLine()!;

            if (angivenKod == korrectKod)
            {
                Console.WriteLine("Inloggning lyckades!");
                return true;
            }
            else
            {
                Console.WriteLine("Felaktig kod. Försök igen.");
                return false;
            }
        }

        // Visa meny
        public void VisaMeny()
        {
            Console.Clear();
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Lägg till ny bok");
            Console.WriteLine("2. Visa alla böcker");
            Console.WriteLine("3. Avsluta");
        }

        // Hantera användarens val
        public void HanteraVal(int val)
        {
            switch (val)
            {
                case 1:
                    LäggaTillBok();
                    break;
                case 2:
                    VisaAllaBöcker();
                    break;
                case 3:
                    Console.WriteLine("Avslutar programmet...");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }

        // Lägg till en ny bok
        private void LäggaTillBok()
        {
            Console.WriteLine("Ange boktitel:");
            string titel = Console.ReadLine()!;

            Console.WriteLine("Ange författare:");
            string författare = Console.ReadLine()!;

            Console.WriteLine("Ange ISBN:");
            string isbn = Console.ReadLine()!;

            Console.WriteLine("Ange genre:");
            string genre = Console.ReadLine()!;

            Bok nyBok = new Bok(titel, författare, isbn, genre);
            bokLista.Add(nyBok);
            Console.WriteLine("Boken har lagts till.");
            Console.ReadLine();  // Pausar så användaren kan läsa meddelandet
        }

        // Visa alla böcker
        private void VisaAllaBöcker()
        {
            if (bokLista.Count == 0)
            {
                Console.WriteLine("Ingen bok finns i listan.");
            }
            else
            {
                foreach (var bok in bokLista)
                {
                    bok.VisaInfo();
                }
            }
            Console.ReadLine();  // Pausar så användaren kan läsa
        }
    }

}
