using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BitCoin.BitBus.Linq
{
    /// <summary>
    /// A BitBus LINQ QueryProvider for BTC.
    /// </summary>
    public class QueryBitBusBtcProvider : QueryBitBusProvider
    {
        public override IQueryable CreateQuery(Expression expression)
        {
            return base.CreateQuery(expression);
        }

        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return base.CreateQuery<TElement>(expression);
        }

        public override object Execute(Expression expression)
        {
            return base.Execute(expression);
        }

        public override TResult Execute<TResult>(Expression expression)
        {
            return base.Execute<TResult>(expression);
        }
    }
}
