using System;
using System.Threading;

namespace RaktarProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Osztály példányosítása
            Warehouse raktar = new Warehouse();

            
            raktar.HozzaadTobb(
                new Product("Alaplap", 50000), 
                new Product("Processzor", 120000),
                new Product("RAM 16GB", 25000), 
                new Product("SSD 1TB", 30000),
                new Product("Ház", 15000), 
                new Product("Tápegység", 22000),
                new Product("Monitor", 60000), 
                new Product("Billentyűzet", 10000),
                new Product("Egér", 8000), 
                new Product("Fejhallgató", 18000),
                new Product("Videókártya", 250000), 
                new Product("Hűtőborda", 12000),
                new Product("Ventilátor", 4000), 
                new Product("HDMI Kábel", 3000),
                new Product("Webkamera", 15000), 
                new Product("Mikrofon", 25000),
                new Product("Hangszóró", 12000), 
                new Product("Egérpad", 5000),
                new Product("USB Hub", 7000), 
                new Product("Külső HDD", 20000)
            );

            Console.WriteLine("Raktár inicializálva.");
            raktar.KeszletListazas();

            Console.WriteLine($"\nTermékek száma: {raktar.KeszletDarabszam()}");
            raktar.LegfelsoMegtekintese();

            // Szálak indítása a Mutex-es művelet teszteléséhez
            Console.WriteLine("\n--- Eladások indítása két szálon ---");
            Thread t1 = new Thread(raktar.TermekKivetele);
            Thread t2 = new Thread(raktar.TermekKivetele);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"\nMaradék darabszám eladások után: {raktar.KeszletDarabszam()}");

            raktar.RaktarKiurites();
            Console.WriteLine("Üres a raktár? " + (raktar.UresE() ? "Igen" : "Nem"));

            Console.ReadLine();
        }
    }
}