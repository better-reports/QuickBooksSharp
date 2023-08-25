using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace QuickBooksSharp
{
    internal class FifoSemaphore
    {
        private SemaphoreSlim _semaphore;

        private ConcurrentQueue<TaskCompletionSource<bool>> queue = new ConcurrentQueue<TaskCompletionSource<bool>>();

        public FifoSemaphore(int maxConcurrency)
        {
            _semaphore = new SemaphoreSlim(maxConcurrency, maxConcurrency);
        }

        public Task WaitAsync()
        {
            var tcs = new TaskCompletionSource<bool>();
            queue.Enqueue(tcs);
            _semaphore.WaitAsync().ContinueWith(t =>
            {
                if (queue.TryDequeue(out var popped))
                    popped.SetResult(true);
            });
            return tcs.Task;
        }

        public void Release()
        {
            _semaphore.Release();
        }
    }
}
