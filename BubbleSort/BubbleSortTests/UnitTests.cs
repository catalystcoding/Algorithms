using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using Xunit;

namespace BubbleSortTests
{
    public class UnitTests
    {
        [Description("Ensures swap of two integers properly occurs")]
        [Fact]
        public void TestSwapMethod() {
            var number1 = 15d;
            var number2 = 10d;
            // ensure variables were properly assigned
            Assert.Equal(15d, number1);
            Assert.Equal(10d, number2);
            // Process swap
            var client = new BubbleSort.BubbleSort();
            client.Swap(ref number1,ref number2);
            // ensure variables do not equal their original value
            Assert.NotEqual(15d, number1);
            Assert.NotEqual(10d, number2);
            // ensure variables were properly swapped: eg. 15 in number2, 10 in number1
            Assert.Equal(10d, number1);
            Assert.Equal(15d, number2);
        }

        [Description("Processes a simple sort and ensures correctness")]
        [Fact]
        public void TestSortMethod() {
            // new object
            var client = new BubbleSort.BubbleSort();
            // add unsorted numbers
            client.numbers.Add(6.00);
            client.numbers.Add(5.13);
            client.numbers.Add(5.131);
            // attempt to sort
            client.Sort();
            // ensure numbers are sorted
            Assert.Equal(client.numbers[0],5.13);
            Assert.Equal(client.numbers[1],5.131);
            Assert.Equal(client.numbers[2], 6.00);
        }

        [Description("Ensures IsSortedMethod is working as intended")]
        [Fact]
        public void TestIsSortedMethod()
        {
            // create two objects
            var isNotSorted = new BubbleSort.BubbleSort();
            var isSorted = new BubbleSort.BubbleSort();
            // add numbers to each object
            isNotSorted.numbers.Add(1.00);
            isNotSorted.numbers.Add(0.90);
            isNotSorted.numbers.Add(1.20);
            //
            isSorted.numbers.Add(1.00);
            isSorted.numbers.Add(1.20);
            isSorted.numbers.Add(9.00);
            // check method
            Assert.Equal(isNotSorted.IsSorted(), false);
            Assert.Equal(isSorted.IsSorted(),true);
        }
    }
}
