using System;
using Xunit;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    // FROM NUGET "System.ComponentModel.Annotations", ValidationResult, ValidationContext, Validator
using System.Text.RegularExpressions;
using System.Collections;

namespace Demo
{
    public class Theory_ClassData
    {
        [Theory]
        [ClassData(typeof(ClassData))]
        public void MainAppDataEquality(object objectOne, int objectTwo, bool boolValue)
        {

        }

        public class ClassData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 1, 2, 3 };
                yield return new object[] { -4, -6, -10 };
                yield return new object[] { -2, 2, 0 };
                yield return new object[] { int.MinValue, -1, int.MaxValue };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}

