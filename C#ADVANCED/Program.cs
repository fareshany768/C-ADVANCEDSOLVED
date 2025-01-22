using System;

namespace Assignment1
{
    class Program
    {
        #region Optimized Bubble Sort Algorithm
        static void OptimizedBubbleSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                // Perform a pass of the bubble sort
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // Swap the elements
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        swapped = true;
                    }
                }

                // If no two elements were swapped, the array is sorted
                if (!swapped)
                {
                    break;
                }
            }
        }
        #endregion

        #region Main Method
        static void Main(string[] args)
        {
            // Test the Optimized Bubble Sort
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Original Array: " + string.Join(", ", array));

            OptimizedBubbleSort(array);

            Console.WriteLine("Sorted Array: " + string.Join(", ", array));

            // Test the Range<T> class
            Range<int> intRange = new Range<int>(5, 15);

            Console.WriteLine($"Is 10 in range (5, 15): {intRange.IsInRange(10)}");
            Console.WriteLine($"Is 20 in range (5, 15): {intRange.IsInRange(20)}");
            Console.WriteLine($"Length of range (5, 15): {intRange.Length()}");
        }
        #endregion
    }

    #region Generic Range<T> Class
    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; private set; }
        public T Maximum { get; private set; }

        // Constructor
        public Range(T minimum, T maximum)
        {
            if (minimum.CompareTo(maximum) > 0)
            {
                throw new ArgumentException("Minimum value must be less than or equal to Maximum value.");
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        // Check if a value is within the range
        public bool IsInRange(T value)
        {
            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }

        // Calculate the length of the range
        public T Length()
        {
            dynamic min = Minimum;
            dynamic max = Maximum;

            return max - min;
        }
    }
    #endregion
}
