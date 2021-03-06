﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    public struct Fraction : IComparable<Fraction>
    {
        //private fields
        private int numerator;
        private int denominator;

        //auto-implemented properties
        public int Numerator { get; set; }

        public int Denominator
        {
            //lambda notation in properties
            get => denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator must be greater than zero");
                denominator = value;
            }
        }

        //constructor with default argument
        public Fraction(int numerator, int denominator = 1) : this()
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        //CompareTo method return values range {-1, 0, 1}
        public int CompareTo(Fraction f)
        {
            double diff = this.ToDouble() - f.ToDouble();
            if (diff != 0) diff /= Math.Abs(diff);
            return (int)(diff);
        }

        //instances of Fraction struct
        public static readonly Fraction Zero = new Fraction(0);
        public static readonly Fraction One = new Fraction(1);
        public static readonly Fraction Half = new Fraction(1, 2);
        public static readonly Fraction Quarter = new Fraction(1, 4);

        //info about struct
        public static string Info()
        {
            return "This is my first test implementation of fraction\t(c)macmle45 2019";
        }

        //override ToString method
        public override string ToString()
        {
            return $"{Numerator.ToString()}/{Denominator.ToString()}";
        }

        //converting method
        public double ToDouble()
        {
            return Numerator / (double)Denominator;
        }

        //euclids algorithm
        public void SimplifyFraction()
        {
            int a = Numerator;
            int b = Denominator;

            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            Numerator /= a;
            Denominator /= a;

            //sign
            if ( Numerator * Denominator < 0)
            {
                Numerator = -Math.Abs(Numerator);
                Denominator = Math.Abs(Denominator);
            }
            else
            {
                Numerator = Math.Abs(Numerator);
                Denominator = Math.Abs(Denominator);
            }
        }

        #region Arithmetic Operators
        //negative
        public static Fraction operator - (Fraction f)
        {
            return new Fraction(-f.Numerator, f.Denominator);
        }

        //plus
        public static Fraction operator + (Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
            result.SimplifyFraction();
            return result;
        }

        //minus
        public static Fraction operator - (Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
            result.SimplifyFraction();
            return result;
        }

        //multiplication
        public static Fraction operator * (Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
            result.SimplifyFraction();
            return result;
        }

        //divide
        public static Fraction operator / (Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
            result.SimplifyFraction();
            return result;
        }
        #endregion

        #region Logic Operators

        public static bool operator == (Fraction f1, Fraction f2)
        {
            return (f1.ToDouble() == f2.ToDouble());
        }

        public static bool operator != (Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction)) return false;
            Fraction f = (Fraction)obj;
            return (this == f);
        }

        public override int GetHashCode()
        {
            return Numerator ^ Denominator;
        }

        public static bool operator > (Fraction f1, Fraction f2)
        {
            return (f1.ToDouble() > f2.ToDouble());
        }

        public static bool operator >= (Fraction f1, Fraction f2)
        {
            return (f1.ToDouble() >= f2.ToDouble());
        }

        public static bool operator < (Fraction f1, Fraction f2)
        {
            return (f1.ToDouble() < f2.ToDouble());
        }

        public static bool operator <= (Fraction f1, Fraction f2)
        {
            return (f1.ToDouble() <= f2.ToDouble());
        }
        #endregion

        #region Conversion Operators

        //explicit conversion from Fraction to double
        public static explicit operator double(Fraction f)
        {
            return f.ToDouble();
        }

        //implicit conversion from int to Fraction
        public static implicit operator Fraction(int f)
        {
            return new Fraction(f);
        }

        #endregion
    }
}
