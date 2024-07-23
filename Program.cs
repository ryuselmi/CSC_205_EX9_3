using System;

namespace CSC_205_EX9_3
{
    public class Rational
    {
        private int numerator;
        private int denominator;

        // Default constructor
        public Rational()
        {
            numerator = 0;
            denominator = 1;
        }

        // Parametric constructor
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        // Method to write the Rational number
        public void WriteRational()
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }

        // Method to negate the Rational number
        public void Negate()
        {
            numerator = -numerator;
        }

        // Method to invert the Rational number
        public void Invert()
        {
            if (numerator == 0)
            {
                throw new InvalidOperationException("Cannot invert a rational number with a numerator of zero.");
            }
            int temp = numerator;
            numerator = denominator;
            denominator = temp;
        }

        // Method to convert the Rational number to double
        public double ToDouble()
        {
            return (double)numerator / denominator;
        }

        // Method to reduce the Rational number to its lowest terms
        public Rational Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            return new Rational(numerator / gcd, denominator / gcd);
        }

        // Method to add two Rational numbers
        public static Rational Add(Rational r1, Rational r2)
        {
            int commonDenominator = r1.denominator * r2.denominator;
            int numeratorSum = r1.numerator * r2.denominator + r2.numerator * r1.denominator;
            Rational result = new Rational(numeratorSum, commonDenominator);
            return result.Reduce();
        }

        // Helper method to calculate the greatest common divisor
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static void Main(string[] args)
        {
            // Create a new Rational object and test the methods
            Rational r = new Rational(6, 8);
            Console.WriteLine("Initial Rational number:");
            r.WriteRational();

            r.Negate();
            Console.WriteLine("After Negate:");
            r.WriteRational();

            r.Invert();
            Console.WriteLine("After Invert:");
            r.WriteRational();

            Console.WriteLine($"As a double: {r.ToDouble()}");

            Rational reduced = r.Reduce();
            Console.WriteLine("After Reduce:");
            reduced.WriteRational();

            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(2, 3);
            Rational sum = Rational.Add(r1, r2);
            Console.WriteLine("Sum of 1/2 and 2/3:");
            sum.WriteRational();

            Console.ReadKey();
        }
    }
}
