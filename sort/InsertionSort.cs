using System;
using System.Collections.Generic;

namespace SortExample {
  public class InsertionSort<T> {
    private readonly IComparer<T> comparer;

    public InsertionSort () {
      this.comparer = Comparer<T>.Default;
    }

    public void Swap (ref T[] arr, int a, int b) {
      T tmp = arr[a];
      arr[a] = arr[b];
      arr[b] = tmp;
    }

    public T[] Sort (T[] arr) {
      for (int i = 0; i < arr.Length - 1; i++) {
        int j = i + 1;
        while (j > 0) {
          if (this.comparer.Compare(arr[j - 1], arr[j]) > 0) {
            Swap(ref arr, j - 1, j);
          }
          j--;
        }
      }
      return arr;
    }
  }
}
