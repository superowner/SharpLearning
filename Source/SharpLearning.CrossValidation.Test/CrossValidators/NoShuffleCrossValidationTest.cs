﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.Test;
using System;
using System.Linq;

namespace SharpLearning.CrossValidation.CrossValidators.Test
{
    [TestClass]
    public class NoShuffleCrossValidationTest
    {
        [TestMethod]
        public void NoShuffleCrossValidation_CrossValidate_Folds_2()
        {
            var actual = AssertCrossValidation(2);
            var expected = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoShuffleCrossValidation_CrossValidate_Folds_10()
        {
            var actual = AssertCrossValidation(10);
            var expected = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoShuffleCrossValidation_CrossValidate_Too_Many_Folds()
        {
            AssertCrossValidation(20);
        }

        double[] AssertCrossValidation(int folds)
        {
            var observations = new F64Matrix(10, 10);
            var targets = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var indices = Enumerable.Range(0, targets.Length).ToArray();

            var sut = new NoShuffleCrossValidation<double>(folds);
            var actual = sut.CrossValidate(new CrossValidationTestLearner(indices), observations, targets);
            return actual;
        }
    }
}