using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Globalization;
using System.IO;
using System.Collections;

namespace Demo
{
    public class AsyncTests
    {
        [Fact]
        public async Task AsyncTest()
        {
            List<Task> tasks = new List<Task>();

            for (uint i = 0; i < 100; i++)
                tasks.Add(AssertTrue());

            await Task.WhenAll(tasks);
        }

        private async Task AssertTrue()
        {
            await Task.Delay(1000);
            Assert.True(true);
        }
    }
}
