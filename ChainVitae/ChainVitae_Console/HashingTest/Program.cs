using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingTest
{
    class Program
    {
        //Sourced from https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2
        //03/03/19 @21:12
        //The below will always return 28 and 37
        static void Main(string[] args)
        {
            Point pt = new Point(5, 8);
            Console.WriteLine(pt.GetHashCode());

            pt = new Point(8, 5);
            Console.WriteLine(pt.GetHashCode());
            Console.Read();
            
            //Tested against memory addressing:
            //Consider manual memory allocation to test this
            //for (int i = 0; i < 10; i++)
            //{
            //    Point pt = new Point(5, 8);
            //    Console.WriteLine(pt.GetHashCode());
            //    pt = new Point(8, 5);
            //    Console.WriteLine(pt.GetHashCode());
            //    Console.Read();
            //}
        }
        public struct Point
        {
            private int x;
            private int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override bool Equals(Object obj)
            {
                if (!(obj is Point)) return false;

                Point p = (Point)obj;
                return x == p.x & y == p.y;
            }

            public override int GetHashCode()
            {
                return ShiftAndWrap(x.GetHashCode(), 2) ^ y.GetHashCode();
            }

            private int ShiftAndWrap(int value, int positions)
            {
                positions = positions & 0x1F;

                // Save the existing bit pattern, but interpret it as an unsigned integer.
                uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
                // Preserve the bits to be discarded.
                uint wrapped = number >> (32 - positions);
                // Shift and wrap the discarded bits.
                return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
            }
        }
    }
}
