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
    public class FactTests
    {
        [Fact]
        public void SimpleComparisons()
        {
            Assert.True(true);
            Assert.False(false);
        }

        [Fact]
        public void MoreComparisons()
        {
            Assert.Equal(1,1.0);
            Assert.Equal(1.0,1);

            object objOne = new object();
            object objTwo = new object();

            Assert.Same(objOne, objOne);
            Assert.Same(objTwo, objTwo);

            Assert.NotSame(objOne, objTwo);
        }
    }
}
