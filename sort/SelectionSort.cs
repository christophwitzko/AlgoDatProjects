using System;
using System.Collections.Generic;

namespace SortExample {
  public class SelectionSort<T> {
    private readonly IComparer<T> comparer;

    public SelectionSort () {
      this.comparer = Comparer<T>.Default;
    }

    public void Swap (ref T[] arr, int a, int b) {
      T tmp = arr[a];
      arr[a] = arr[b];
      arr[b] = tmp;
    }

    public int MinRangeIndex (T[] arr, int from, int to) {
      int min = from;
      for (int i = from + 1; i < to; i++) {
        if (this.comparer.Compare(arr[i], arr[min]) < 0) {
          min = i;
        }
      }
      return min;
    }

    public T[] Sort (T[] arr) {
      int length = arr.Length;
      int left = 0;
      while (left < length) {
        Swap(ref arr, MinRangeIndex(arr, left, length), left);
        left++;
      }
      return arr;
    }
  }
}
