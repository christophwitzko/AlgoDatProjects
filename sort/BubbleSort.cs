using System;
using System.Collections.Generic;

namespace SortExample {
  public class BubbleSort<T> {
    private readonly IComparer<T> comparer;

    public BubbleSort () {
      this.comparer = Comparer<T>.Default;
    }

    public void Swap (ref T[] arr, int a, int b) {
      T tmp = arr[a];
      arr[a] = arr[b];
      arr[b] = tmp;
    }

    public T[] Sort (T[] arr) {
      bool swapped = true;
      while (swapped) {
        swapped = false;
        for (int i = 0; i < arr.Length - 1; i++) {
          if (this.comparer.Compare(arr[i], arr[i + 1]) > 0) {
            Swap(ref arr, i, i + 1);
            swapped = true;
          }
        }
      }
      return arr;
    }
  }
}
