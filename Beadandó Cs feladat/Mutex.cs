namespace RaktarProjekt
{
    class Mutex
    {
        private System.Threading.Mutex _mutex;

        public Mutex()
        {
            _mutex = new System.Threading.Mutex();
        }

        public void MutexWait()
        {
            _mutex.WaitOne();
        }

        public void MutexRelease()
        {
            _mutex.ReleaseMutex();
        }
    }
}