using System;

namespace RDI.Test.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 3, 4, 5 };

            var rotateArray = new RotateArray();

            var firstRotate = rotateArray.RotateTheArray(array);
            var secondRotate = rotateArray.RotateTheArray(firstRotate);

            foreach (var item in secondRotate)
            {
                Console.WriteLine(item);
            }
        }
    }
}
