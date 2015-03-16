using LinkedListExample;
using System;

namespace SortExample {
  // O(n^2)
  public class SelectionSort<T> {

    public SelectionSort () {
    }

    public ulong MinRangeIndex (LinkedList<T> arr, ulong from, ulong to) {
      ulong min = from;
      for (ulong i = from + 1; i < to; i++) {
        if (arr.Compare(i, min) < 0) {
          min = i;
        }
      }
      return min;
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      arr = arr.ShallowCopy();
      ulong length = arr.Count;
      ulong left = 0;
      while (left < length) {
        arr.Swap(MinRangeIndex(arr, left, length), left);
        left++;
      }
      return arr;
    }
  }
}
