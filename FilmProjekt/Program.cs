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
            Feladat01();
            Feladat02();
        }

        private static void Feladat02()
        {
            Film leghosszabbFilm = GetLeghosszabbFilm();

            Console.WriteLine($"2. A leghosszabb film: {leghosszabbFilm.Cim} - {leghosszabbFilm.Hossz} perc");
        }

        private static Film GetLeghosszabbFilm()
        {
            Film leghosszabbFilm = filmek[0];
            for (int i = 1; i < filmek.Count; i++)
            {
                if (filmek[i].Hossz > leghosszabbFilm.Hossz)
                {
                    leghosszabbFilm = filmek[i];
                }
            }
            return leghosszabbFilm;
        }

        private static void Feladat01()
        {
            Console.WriteLine($"1. Filmek átlagos hossza: {GetAtlagosHossz()} perc");
        }

        private static object GetAtlagosHossz()
        {
            int osszHossz = 0;
            foreach (var film in filmek) 
            {
                osszHossz += film.Hossz;
            }
            return osszHossz / filmek.Count;
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