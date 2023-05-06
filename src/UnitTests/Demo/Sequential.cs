using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo
{
    [Collection("Sequential")] // Attribute, that will execute this class and all others in the collection "Sequential" sequentially and not parralel
    // see: https://stackoverflow.com/a/47174842/13986881
    internal class Sequential
    {
        // Some unittest, that cannot be performed in parallel with certain other tests.

    }
}
