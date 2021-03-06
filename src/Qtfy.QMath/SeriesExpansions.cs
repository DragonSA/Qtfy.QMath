﻿// <copyright file="SeriesExpansions.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>
namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A collection of methods used to calculate the series approximations of various functions and constants.
    /// </summary>
    public static class SeriesExpansions
    {
        /// <summary>
        /// Calculates the taylor approximation of eulers constant raised to <paramref name="power"/>,
        /// with the specified number of terms.
        /// </summary>
        /// <param name="power">
        /// The power to raise eulers constant to.
        /// </param>
        /// <param name="terms">
        /// The number of terms to compute.
        /// </param>
        /// <returns>
        /// The taylor approximation of eulers constant raised to <paramref name="power"/>,
        /// with the specified number of terms.
        /// </returns>
        public static BigRational Exp(BigRational power, int terms)
        {
            if (terms < 0)
            {
                throw new ArgumentException("terms must be non-negative");
            }
            else if (terms == 0)
            {
                return 0;
            }
            else if (terms == 1)
            {
                return 1;
            }

            var xn = BigRational.One;
            var factorial = BigInteger.One;
            var sum = BigRational.One;
            for (var t = 1; t != terms; ++t)
            {
                xn *= power;
                factorial *= t;
                sum += xn / factorial;
            }

            return sum;
        }

        /// <summary>
        /// Approximates the natural (base e) logarithm of a specified number using a series expansion of a specified (default = 1000) number of terms.
        /// </summary>
        /// <param name="x">
        /// The number whose logarithm is to be approximated.
        /// </param>
        /// <param name="terms">
        /// The number of terms to compute.
        /// </param>
        /// <returns>
        /// The approximation of the natural (base e) logarithm of a specified number.
        /// </returns>
        public static BigRational Log(BigRational x, int terms)
        {
            var n = 1 / (x - 1);
            var factor = 1 / ((2 * n) + 1);
            var factorSquared = factor * factor;
            var total = factor;
            for (int term = 1, power = 3; term < terms; ++term, power += 2)
            {
                factor *= factorSquared;
                total += factor / power;
            }

            return 2 * total;
        }
    }
}
