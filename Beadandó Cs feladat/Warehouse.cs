using System;

namespace RaktarProjekt
{
    class Warehouse
    {
        private ConcurrentStack _keszlet;
        private Mutex _konzolMutex;

        public Warehouse()
        {
            _keszlet = new ConcurrentStack();
            _konzolMutex = new Mutex();
        }

        public void HozzaadTobb(params Product[] termekek)
        {
            _keszlet.PushRange(termekek);
        }

        public void TermekKivetele()
        {
            // A konzol írását mutex-szel védjük, hogy ne keveredjenek a szálak
            _konzolMutex.MutexWait();
            try
            {
                //csak egy szál lép be ide egyszerre
                if (_keszlet.TryPop(out Product kivett))
                {
                    Console.WriteLine($"[KIADÁS] Eladva: {kivett}");
                }
            }
            finally
            {
                //a szál visszaadja a kulcsot
                _konzolMutex.MutexRelease();
            }
        }

        public void LegfelsoMegtekintese()
        {
            if (_keszlet.TryPeek(out Product legfelso))
            {
                Console.WriteLine($"Legközelebb eladásra kerül: {legfelso}");
            }
        }

        public bool UresE()
        {
            return _keszlet.IsEmpty();
        }

        public int KeszletDarabszam()
        {
            return _keszlet.Count();
        }

        public void RaktarKiurites()
        {
            _keszlet.Clear();
            Console.WriteLine("A raktár készlete teljesen törölve.");
        }

        public void KeszletListazas()
        {
            _konzolMutex.MutexWait();
            try
            {
                Console.WriteLine("--- Jelenlegi raktárkészlet (LIFO sorrend) ---");
                foreach (var t in _keszlet.ToArray())
                {
                    Console.WriteLine(" > " + t);
                }
            }
            finally
            {
                _konzolMutex.MutexRelease();
            }
        }
    }
}