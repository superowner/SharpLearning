﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.InputOutput.Csv;
using System.IO;

namespace SharpLearning.FeatureTransformations.Test
{
    /// <summary>
    /// Summary description for DateTimeFeatureTransformerTest
    /// </summary>
    [TestClass]
    public class DateTimeFeatureTransformerTest
    {
        [TestMethod]
        public void DateTimeFeatureTransformer_Transform()
        {
            var sut = new DateTimeFeatureTransformer();
            
            var writer = new StringWriter();

            new CsvParser(() => new StringReader(Input))
            .EnumerateRows()
            .Transform(r => sut.Transform(r, "Date"))
            .Write(() => writer);

            var actual = writer.ToString();

            Assert.AreEqual(Expected, actual);
        }

        string Expected = 
@"Date;Year;Month;DayOfMonth;DayOfWeek;HourOfDay;TotalDays;TotalHours
2015-01-17;2015;1;17;6;0;16452;394848
2015-02-21;2015;2;21;6;0;16487;395688
2015-03-13;2015;3;13;5;0;16507;396168
2015-05-12;2015;5;12;2;0;16567;397608
2015-04-4;2015;4;4;6;0;16529;396696
2015-03-12;2015;3;12;4;0;16506;396144
2015-02-14;2015;2;14;6;0;16480;395520
2015-01-16;2015;1;16;5;0;16451;394824";

        string Input =
@"Date
2015-01-17
2015-02-21
2015-03-13
2015-05-12
2015-04-4
2015-03-12
2015-02-14
2015-01-16
";
    }
}
