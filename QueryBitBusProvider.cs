using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace BitCoin.BitBus.Linq
{
    /// <summary>
    /// Marker interface for LINQ to Bitcoin BitBus query providers.  
    /// Implement this query provider for each fork/chain BitBus implementation.
    /// </summary>
    public interface IQueryBitBusProvider : IQueryProvider { }

    /// <summary>
    /// Default BitBus LINQ QueryProvider, for BitCoin SV.
    /// </summary>
    public class QueryBitBusProvider : IQueryBitBusProvider
    {
        public string BusHash = @"da96583d02df9083643249ed001eb2d3282f85f6b74705cfaa32f9c8f6ea9b4f";
        public string Server = @"http://localhost";
        public int? Port = 3007;
        public string Host => $"{Server}" + (Port.Value == 80 ? "" : $":{Port.Value}");
        public string BusUrl => $"{Host}/b/{BusHash}";

        private static QueryBitBusProvider instance = default(QueryBitBusProvider);
        public static QueryBitBusProvider Instance => instance ?? QueryBitBusProvider.CreateProvider("localhost", 3007, "da96583d02df9083643249ed001eb2d3282f85f6b74705cfaa32f9c8f6ea9b4f");


        public static QueryBitBusProvider CreateProvider(string server, int port, string busHash)
        {
            var provider = new QueryBitBusProvider
            {
                BusHash = busHash,
                Server = server,
                Port = port
            };
            if (QueryBitBusProvider.instance == null)
                QueryBitBusProvider.instance = provider;
            return provider;
        }

        public static async IAsyncEnumerable<string> GetBlockUrls()
        {   
            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using var http = new HttpClient();
            http.BaseAddress = new Uri(Instance.Server);
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var itemsRoot = JObject.Parse(await http.GetStringAsync(QueryBitBusProvider.Instance?.BusUrl));
            var urls = itemsRoot["items"].Select(item => item["url"].Value<string>());
            foreach (var url in urls)
                yield return url;
        }

        public static async IAsyncEnumerable<IAsyncEnumerable<Transaction>> GetTransactions()
        {
            await foreach (var blockUrl in GetBlockUrls())
            {
                using var http = new HttpClient();
                var transactions = JsonConvert.DeserializeObject<Transaction[]>(await http.GetStringAsync(QueryBitBusProvider.Instance.Host + blockUrl));
                yield return transactions.ToAsyncEnumerable();
            }
        }

        /// <summary>
        /// Returns all transactions from the BitBus block urls passed in.
        /// </summary>
        /// <returns></returns>
        public static async IAsyncEnumerable<IAsyncEnumerable<Transaction>> GetTransactions(params string[] blockUrls)
        {
            foreach (var blockUrl in blockUrls)
            {
                using var http = new HttpClient();
                var transactions = JsonConvert.DeserializeObject<Transaction[]>(await http.GetStringAsync(QueryBitBusProvider.Instance.Host + blockUrl));
                yield return transactions.ToAsyncEnumerable();
            }
        }

        public static async IAsyncEnumerable<Transaction> GetFlattedTransactions()
        {
            await foreach (var transactions in GetTransactions())
            {
                await foreach (var transaction in transactions)
                {
                    yield return transaction;
                }
            }
        }

        /// <summary>
        /// Gets all the outputs from all the transactions indexed by the current BitBus instance.
        /// </summary>
        /// <returns></returns>
        public static async IAsyncEnumerable<Out> GetOutputs()
        {
            await foreach (var transactions in GetTransactions())
            {
                await foreach (var transaction in transactions)
                {
                    var outputs = transaction.@out;

                    foreach (var output in outputs)
                    {
                        yield return output;
                    }
                }
            }
        }

        public static IObservable<Transaction> ObservableTransactions =
            Observable.Create<Transaction>(async o =>
            {
                await foreach (var transactions in GetTransactions())
                    await foreach (var transaction in transactions) o.OnNext(transaction);

                o.OnCompleted();
                return Disposable.Empty;
            });

        public virtual IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public virtual object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public virtual TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
