using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DeveloperSample.Syncing
{
    public class SyncTest
    {
        private readonly ITestOutputHelper _output;

        public SyncTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task CanInitializeCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string> { "one", "two" };
            var result = await debug.InitializeList(items);
            Assert.Equal(items.Count, result.Count);
        }

        [Fact]
        public void ItemsOnlyInitializeOnce()
        {
            var debug = new SyncDebug();
            var count = 0;
            var dictionary = debug.InitializeDictionary(i =>
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
                _output.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} Count: {count}, i:{i}");
                return i.ToString();
            });

            Assert.Equal(300, count);
            Assert.Equal(100, dictionary.Count);

            var expected = dictionary.Select(v => v.Value)
                .SequenceEqual(Enumerable.Range(0, 99).Select(i => i.ToString()));
        }
    }
}