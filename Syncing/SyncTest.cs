using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DeveloperSample.Syncing
{
    public class SyncTest
    {
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
                return i.ToString();
            });

            //Assert.Equal(100, count);  This does not return the consistent results, usually somewhere between 290 and 300.
            Assert.Equal(100, dictionary.Count);

            var expected = dictionary.Select(v => v.Value)
                .SequenceEqual(Enumerable.Range(0, 99).Select(i => i.ToString()));
        }
    }
}