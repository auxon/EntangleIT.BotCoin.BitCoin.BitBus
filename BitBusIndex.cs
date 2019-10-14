using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitCoin.BitBus
{
    public class Index : IAsyncEnumerable<Item>
    {
        public ValueTask<Item> this[int index] => Items.ElementAtAsync(index);

        public IAsyncEnumerable<Item> Items { get; private set; }

        public IAsyncEnumerator<Item> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return Items.GetAsyncEnumerator(cancellationToken);
        }
    }

    public class Item
    {
        public string Url { get; set; }
    }
}
