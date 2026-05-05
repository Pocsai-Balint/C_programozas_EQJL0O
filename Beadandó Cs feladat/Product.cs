using System;

namespace RaktarProjekt
{
    class Product
    {
        public string Nev { get; set; }
        public int Ar { get; set; }

        public Product(string nev, int ar)
        {
            Nev = nev;
            Ar = ar;
        }

        public override string ToString()
        {
            return $"{Nev} - {Ar} Ft";
        }
    }
}