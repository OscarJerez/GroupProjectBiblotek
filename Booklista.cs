public class BookFinder
{
    private Library library;

    public BookFinder(Library library)
    {
        this.library = library; 
    }

    public void SökEfterBokIListan()
    {
        Console.Write("Ange boktitel:  "); //Söka efter bok
        string userInput = Console.ReadLine();

        bool finnsILista = false; 

        foreach (var bok in library.bokLista) // Använd bokLista från Library klassen
        {
            if (userInput == bok.Titel)
            {
                Console.WriteLine($"{bok.VisaInfo()} finns i din boklista!");
                finnsIListaILista = true;
                break;
            }
        }

        if (!finnsILista) // Ifall boken inte hittades
        {
            Console.WriteLine($"{userInput} finns inte i din boklista.");
        }
    }
}