namespace RDI.Test.ConsoleApp
{
    public class RotateArray
    {
        public int[] RotateTheArray(int[] array)
        {
            var temp = array[0];
            for (var i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;
            return array;
        }
    }
}