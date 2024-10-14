using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GroupProjectBiblotek
{
    public class Library
    {
        public List<Bok> bokLista = new List<Bok>();

        // Lägg till en ny bok
        public void LäggaTillBok()
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
            Console.WriteLine("\nBoken har lagts till.");
            Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
            Console.ReadLine();  // Pausar så användaren kan läsa meddelandet
        }
        // Visa alla böcker
        public void VisaAllaBöcker()
        {
            if (bokLista.Count == 0)
            {
                Console.WriteLine("\nIngen bok finns i listan.");
                
            }
            else
            {
                foreach (var bok in bokLista)
                {
                    bok.VisaInfo();
                }
            }
            Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
            Console.ReadLine();  // Pausar så användaren kan läsa
        }
        public void CheckOutBook()
        {

            if (bokLista.Count == 0)
            {
                Console.WriteLine("\nDet finns inga böcker i biblioteket för tillfället...");
                Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                Console.ReadLine();
                return;
            }

            string userInput = UserInputHelper.TakeUserInfo("checka ut");

            foreach (var bok in bokLista)
            {
               

                if (userInput == bok.Titel)
                {
                    if (bok.IsCheckedOut == true)
                    {
                        Console.WriteLine("\nBoken är tyvärr redan utlånad");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                        Console.ReadLine();
                        return;
                    }

                    bok.IsCheckedOut = true;
                    Console.WriteLine($"\nDu lånar nu {bok.Titel}");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                    return;
                }
                else if (bok == bokLista[bokLista.Count - 1])
                {
                    Console.WriteLine("\nBoken finns inte i biblioteket" );
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                    return;
                }
            }
        }

        public void ReturnBook()
        {
           
            if (bokLista.Count == 0)
            {
                Console.WriteLine("\nDu kan inte lämna tillbaka en bok då vi tyvärr inte har någora böcker för tillfället");
                Console.WriteLine("\nklicka enter för att komma tillbaka till menyn");
                Console.ReadLine();
                return;
            }
            string userInput = UserInputHelper.TakeUserInfo("returnera");

            foreach (var bok in bokLista)
            {
                if (userInput == bok.Titel)
                {
                    if (bok.IsCheckedOut == false)
                    {
                        Console.WriteLine("\nDu kan inte lämna tillbaka en bok som inte är utlånad...");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                        Console.ReadLine();
                        break;
                    }

                    bok.IsCheckedOut = false;
                    Console.WriteLine($"\nInlämning av {bok.Titel} är registrerad");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                }

                else if (bok == bokLista[bokLista.Count - 1])
                {
                    Console.WriteLine("\nBoken du försöker lämna tillbaka tillhör inte detta bibliotek...");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\nKlicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                }
            }

        }
        public void SökEfterBokIListan()
        {
            Console.Write("Ange boktitel:  "); //Söka efter bok
            string userInput = Console.ReadLine()!;

            bool finnsILista = false;

            foreach (var bok in bokLista) // Använd bokLista från Library klassen
            {
                if (userInput == bok.Titel)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\nBoken finns i biblioteket:");
                    bok.VisaInfo();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("\nKlicka enter för att komma tillbaks till menyn");
                    Console.ReadLine();
                    finnsILista = true;
                    break;
                }
            }

            if (!finnsILista) // Ifall boken inte hittades
            {
                Console.WriteLine();
                Console.WriteLine($"\n{userInput} finns inte i vårat bibliotek");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("\nKlicka enter för att komma tillbaks till menyn");
                Console.ReadLine();

            }
        }
        public string AuthorUserInput()
        {
            Console.WriteLine("\nAnge författare");
            string userinput = Console.ReadLine()!;
            return userinput;
        }
        public void TaBortBok()
        {
            Console.WriteLine("\nAnge titeln på boken du vill ta bort:");
            string titelAttTaBort = Console.ReadLine()!;

            Bok? bokAttTaBort = null;

            // Leta efter boken i listan
            foreach (var bok in bokLista)  // Ensure bokLista is accessed correctly
            {
                if (bok.Titel.Equals(titelAttTaBort, StringComparison.OrdinalIgnoreCase))
                {
                    bokAttTaBort = bok;
                    break;
                }
                // Om boken hittades, ta bort den
                if (bokAttTaBort != null)
                {
                    bokLista.Remove(bokAttTaBort);  // Access the correct list
                    Console.WriteLine($"\nBoken '{titelAttTaBort}' har tagits bort.");
                }
                else
                {
                    Console.WriteLine($"\nIngen bok med titeln '{titelAttTaBort}' hittades.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att gå tillbaka till menyn.");
                Console.ReadLine();  // Pauses the screen so the user can read the message
            }
        }

        public void searchByAuthor(string author)
        {
            bool authorexict = false;

            foreach (var book in bokLista)

            {            
               
                if (book.Författare == author)
                
                {
                    authorexict = true;
                    book.VisaInfo();
                    Console.ReadLine();
                }
            }
             if ( authorexict == false)

                {
                Console.WriteLine($"\nbiblioteket har inga böcker enligt {author}.");
                Console.ReadLine();
                }
        }
    }   
}
