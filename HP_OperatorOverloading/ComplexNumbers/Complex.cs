using System;
using System.Collections.Generic;
using System.Text;
using WhatsNewAttributes;

[assembly: SupportsWhatsNew]

namespace ComplexNumbers
{
    [LastModified("2007. 07. 01. 12:34:56", "Oszt�ly l�trehoz�sa")]
    public class Complex
    {
        private double real;
        public double Real
        {
            get { return real; }
            set { real = value; }
        }
        private double imaginary;
        public double Imaginary
        {
            get { return imaginary; }
            set { imaginary = value; }
        }

        public Complex()
            : this(0.0, 0.0)
        {
        }

        public Complex(double real)
            : this(real, 0.0)
        {
        }

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            Complex result = new Complex();
            result.real = lhs.real + rhs.real;
            result.imaginary = lhs.imaginary + rhs.imaginary;
            return result;
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            //Complex result = new Complex();
            //result.real = lhs.real - rhs.real;
            //result.imaginary = lhs.imaginary - rhs.imaginary;
            //return result;

            return new Complex(lhs.real - rhs.real, lhs.imaginary - rhs.imaginary);
        }

        public static implicit operator Complex(double source)
        {
            return new Complex(source);
        }

        public static explicit operator double(Complex source)
        {
            if (Math.Abs(source.imaginary) <= double.Epsilon)
                return source.real;
            else
                throw new InvalidCastException("Null�t�l k�l�nb�z� imagin�rius r�sszel rendelkez� komplex sz�m nem alak�that� �t val�s sz�mm�");
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return !(lhs == rhs);
        }

        [LastModified("2007. 07. 03. 23:45:01", "Az == �s != oper�torok mellett erre a met�dusra is sz�ks�g van")]
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            if (real != ((Complex) obj).real || imaginary != ((Complex) obj).imaginary)
                return false;
            // Mivel �s�nk az Object oszt�ly, most nincs sz�ks�g az �r�k�lt Equals() met�dus megh�v�s�ra
            return true;
        }

        [LastModified("2007. 07. 03. 23:45:01", "Az == �s != oper�torok mellett erre a met�dusra is sz�ks�g van")]
        public override int GetHashCode()
        {
            return Convert.ToInt32(imaginary) ^ Convert.ToInt32(real);
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}i", real, imaginary < 0.0 ? " - " : " + ", Math.Abs(imaginary));
        }
    }
}