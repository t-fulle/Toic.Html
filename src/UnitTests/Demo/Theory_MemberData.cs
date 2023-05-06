using System;
using Xunit;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    // FROM NUGET "System.ComponentModel.Annotations", ValidationResult, ValidationContext, Validator
using System.Text.RegularExpressions;

namespace Demo
{
    public class Theory_MemberData
    {
        [Theory]
        [MemberData(nameof(TestData))]
        [MemberData(nameof(TestDataTwo))]
        public void MainAppDataEquality(object objectOne, int objectTwo, bool boolValue)
        {

        }

        public static TheoryData<object, int, bool> TestData =>
            new TheoryData<object, int, bool>
                {
                    { new object(), 15, true },
                    { "some string", 16, false },
                    { 17, 17, false },
                    { (double)18, 18, false },
                    { new object(), 19, false },
                };

        public static IEnumerable<object[]> TestDataTwo()
        {
            yield return new object[] { new object(), 15, true };
            yield return new object[] { "some string", 16, false };
            yield return new object[] { 17, 17, false };
            yield return new object[] { new object(), 19, false };
        }
    }
}

