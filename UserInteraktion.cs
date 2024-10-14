namespace GroupProjectBiblotek

{
    public class UserInteraktion
    {
        Library library = new Library();


        // Metod för att logga in användaren
        public bool Login()
        {
            const string korrectKod = "1234"; // Fördefinierad kod

            Console.WriteLine("Välkommen till bibliotek G4\n");
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
            Console.WriteLine("Välj ett alternativ:\n");
            Console.WriteLine("1. Lägg till ny bok");
            Console.WriteLine("2. Visa alla böcker");
            Console.WriteLine("3. Låna en bok");
            Console.WriteLine("4. Lämna tillbaka en bok");
            Console.WriteLine("5. Sök efter en bok i biblioteket");
            Console.WriteLine("6. Sök bok enligt författare");
            Console.WriteLine("7. Ta bort en bok");
            Console.WriteLine("8. Avsluta");
        }

        // Hantera användarens val
        public void HanteraVal(int val)
        {
            switch (val)
            {
                case 1:
                    library.LäggaTillBok();
                    break;
                case 2:
                    library.VisaAllaBöcker();
                    break;
                case 3:
                    library.CheckOutBook();
                    break;
                case 4:
                    library.ReturnBook();
                    break;
                case 5:
                    library.SökEfterBokIListan();
                    break;
                case 6:
                    library.AuthorUserInput();
                    break;
                case 7:
                    library.TaBortBok();
                    break;
                case 8:
                    Console.WriteLine("Avsluta program");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
       

    }
    public static class UserInputHelper
    {
        public static string TakeUserInfo(string checkOutOrReturn)
        {
            string userInput;

            Console.WriteLine($"Vilken bok vill du {checkOutOrReturn}?");
            Console.WriteLine("(Skriv titel)");
            userInput = Console.ReadLine()!;

            return userInput;
        }
    }
}
