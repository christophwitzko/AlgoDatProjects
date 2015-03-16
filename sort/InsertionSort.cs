using LinkedListExample;
using System;

namespace SortExample {
  // O(n^2)
  public class InsertionSort<T> {

    public InsertionSort () {
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      arr = arr.ShallowCopy();
      for (ulong i = 0; i < arr.Count - 1; i++) {
        ulong j = i + 1;
        while (j > 0) {
          if (arr.Compare(j - 1, j) > 0) {
            arr.Swap(j - 1, j);
          }
          j--;
        }
      }
      return arr;
    }
  }
}
