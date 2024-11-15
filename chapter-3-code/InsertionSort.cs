﻿
namespace GettingStarted.Classes
{
    internal class InsertionSort : AbstractSort
    {
        public override void Sort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int j = i;
                while (j > 0 && a[j] < a[j - 1])
                {
                    (a[j], a[j - 1]) = (a[j - 1], a[j]);
                    j--;
                }
            }
        }
    }
}
