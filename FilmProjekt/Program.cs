using System;
using System.Diagnostics;

namespace FilmProjekt
{
    internal class Program
    {
        static List<Film> filmek = new List<Film>();
        public static void Main(string[] args)
        {
            FajlBeolvasasa("filmadatbazis.csv");
            foreach (var item in filmek)
            {
                Debug.WriteLine(item.Cim);
            }
        }

        private static void FajlBeolvasasa(string fajlNev)
        {
            using (var fileReader = new StreamReader(fajlNev))
            {
                //fejléc beolvasása
                fileReader.ReadLine();
                while (!fileReader.EndOfStream)
                {
                    string sor = fileReader.ReadLine();
                    Film film = new Film(sor);
                    filmek.Add(film);
                }
            }
        }
    }
}