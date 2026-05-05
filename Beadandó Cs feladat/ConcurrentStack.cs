namespace RaktarProjekt
{
    class ConcurrentStack
    {
        private System.Collections.Concurrent.ConcurrentStack<Product> _stack;

        public ConcurrentStack()
        {
            _stack = new System.Collections.Concurrent.ConcurrentStack<Product>();
        }

        public void PushRange(Product[] products)
        {
            _stack.PushRange(products);
        }

        public bool TryPop(out Product result)
        {
            //zárolásmentes algoritmus
            return _stack.TryPop(out result);
        }

        public bool TryPeek(out Product result)
        {
            return _stack.TryPeek(out result);
        }

        public bool IsEmpty()
        {
            return _stack.IsEmpty;
        }

        public int Count()
        {
            return _stack.Count;
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public Product[] ToArray()
        {
            return _stack.ToArray();
        }
    }
}