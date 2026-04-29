using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace RaktarProjekt
{
    class Warehouse
    {
        
        private ConcurrentStack<Product> keszlet;
        private Mutex konzolMutex;

        public Warehouse()
        {
            keszlet = new ConcurrentStack<Product>();
            konzolMutex = new Mutex();
        }

        
        public void HozzaadTobb(params Product[] termekek)
        {
            keszlet.PushRange(termekek);
        }

                public void TermekKivetele()
        {
            konzolMutex.WaitOne(); // Mutex használata
            try
            {
                if (keszlet.TryPop(out Product kivett)) // LIFO kivétel
                {
                    Console.WriteLine($"[KIADÁS] Eladva: {kivett}");
                }
            }
            finally
            {
                konzolMutex.ReleaseMutex();
            }
        }

                public void LegfelsoMegtekintese()
        {
            if (keszlet.TryPeek(out Product legfelso)) // LIFO megtekintés
            {
                Console.WriteLine($"Legközelebb eladásra kerül: {legfelso}");
            }
        }

        
        public bool UresE()
        {
            return keszlet.IsEmpty;
        }

        
        public int KeszletDarabszam()
        {
            return keszlet.Count;
        }

        
        public void RaktarKiurites()
        {
            keszlet.Clear();
            Console.WriteLine("A raktár készlete teljesen törölve.");
        }

        
        public void KeszletListazas()
        {
            konzolMutex.WaitOne();
            try
            {
                Console.WriteLine("--- Jelenlegi raktárkészlet (LIFO sorrend) ---");
                foreach (var t in keszlet)
                {
                    Console.WriteLine(" > " + t);
                }
            }
            finally
            {
                konzolMutex.ReleaseMutex();
            }
        }
    }
}