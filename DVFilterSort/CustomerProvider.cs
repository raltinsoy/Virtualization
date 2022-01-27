#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataVirtualization;

#endregion

namespace DVFilterSort
{
    public class CustomerProvider : IItemsProvider<Customer>
    {
        private readonly List<Customer> _customers;
        private int _count;

        public CustomerProvider()
        {
            _customers = new List<Customer>();
            for (int i = 0; i < 100000; i++)
            {
                _customers.Add(new Customer
                {
                    Id = i,
                    Name = "Customer " + i
                });
            }
        }

        public int FetchCount()
        {
            Thread.Sleep(100);
            _count = _customers.Count;
            return _count;
        }

        public IList<Customer> FetchRange(int startIndex, int pageCount, out int overallCount)
        {
            //Thread.Sleep(100);

            overallCount = _count; // In this case it's ok not to get the count again because we're assuming the data in the database is not changing.

            return _customers.Skip(startIndex).Take(pageCount).ToList();
        }
    }
}