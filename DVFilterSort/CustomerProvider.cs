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

        int totalCount;

        public CustomerProvider()
        {
            _customers = new List<Customer>();

            totalCount = 1000000;
            /*for (int i = 0; i < 1000000; i++)
            {
                _customers.Add(new Customer
                {
                    Id = i,
                    Name = "Customer " + i
                });
            }*/
        }

        public int FetchCount()
        {
            //Thread.Sleep(100);
            _count = totalCount;
            return _count;
        }

        public IList<Customer> FetchRange(int startIndex, int pageCount, out int overallCount)
        {
            //Thread.Sleep(1000);

            overallCount = _count; // In this case it's ok not to get the count again because we're assuming the data in the database is not changing.

            //return _customers.Skip(startIndex).Take(pageCount).ToList();

            var list = new List<Customer>();

            for (int i = startIndex; i < startIndex + pageCount; i++)
            {
                list.Add(new Customer
                {
                    Id = i,
                    Name = "Customer " + i
                });
            }

            return list;
        }
    }
}