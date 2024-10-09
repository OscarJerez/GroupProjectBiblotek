using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectBiblotek
{
    public class Library
    {
        public List<Bok> bokLista = new List<Bok>();
        public void CheckOutBook()
        {

            if (bokLista.Count == 0)
            {
                Console.WriteLine("Det finns inga böcker i biblioteket för tillfället...");
                Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
                Console.ReadLine();
                return;
            }

            string userInput = TakeUserInfo("checka ut");

            foreach (var bok in bokLista)
            {
               

                if (userInput == bok.Titel)
                {
                    if (bok.IsCheckedOut == true)
                    {
                        Console.WriteLine("boken är tyvärr redan utlånad");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
                        Console.ReadLine();
                        return;
                    }

                    bok.IsCheckedOut = true;
                    Console.WriteLine($"Du lånar nu {bok.Titel}");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                    return;
                }
                else if (bok == bokLista[bokLista.Count - 1])
                {
                    Console.WriteLine("Boken finns inte i biblioteket" );
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                    return;
                }
            }
        }

        public void ReturnBook()
        {
           
            if (bokLista.Count == 0)
            {
                Console.WriteLine("Du kan inte lämna tillbaka en bok då vi tyvärr inte har någora böcker för tillfället");
                Console.WriteLine("klicka enter för att komma tillbaka till menyn");
                Console.ReadLine();
                return;
            }
            string userInput = TakeUserInfo("returnera");

            foreach (var bok in bokLista)
            {
                if (userInput == bok.Titel)
                {
                    if (bok.IsCheckedOut == false)
                    {
                        Console.WriteLine("du kan inte lämna tillbaka en bok som inte är utlånad...");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("klicka enter för att komma tillbaka till menyn");
                        Console.ReadLine();
                        break;
                    }

                    bok.IsCheckedOut = false;
                    Console.WriteLine($"Inlämning av {bok.Titel} är registrerad");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("klicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                }

                else if (bok == bokLista[bokLista.Count - 1])
                {
                    Console.WriteLine("Boken du försöker lämna tillbaka tillhör inte detta bibliotek...");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("klicka enter för att komma tillbaka till menyn");
                    Console.ReadLine();
                }
            }

        }

        public string TakeUserInfo(string checkOutOrReturn) 
        {
                string userInput;

                Console.WriteLine($"Vilken bok vill du {checkOutOrReturn}");
                Console.WriteLine("(Skriv titel)");
                userInput = Console.ReadLine();

                return userInput;
        }

    }   
}
