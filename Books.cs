namespace GroupProjectBiblotek
{
    public class Bok
    {
        public string Titel { get; set; }
        public string Författare { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }

        public bool IsCheckedOut { get; set; }

        public Bok(string titel, string författare, string isbn, string genre)
        {
            Titel = titel;
            Författare = författare;
            ISBN = isbn;
            Genre = genre;

            IsCheckedOut = false;
        }

        public void VisaInfo()
        {
            Console.WriteLine($"\nTitel: {Titel}, Författare: {Författare}, ISBN: {ISBN}, Genre: {Genre}");
        }
    }
}