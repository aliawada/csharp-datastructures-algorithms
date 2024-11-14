﻿

namespace GettingStarted.Classes
{
    internal  class SelectionSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minIndex = i;
                int minValue = a[i];
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < minValue)
                    {
                        minIndex = j;
                        minValue = a[j];
                    }
                }
                (a[i], a[minIndex]) = (a[minIndex], a[i]);
            }
        }
    }
}
