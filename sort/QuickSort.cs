using LinkedListExample;
using System;

namespace SortExample {
  public class QuickSort<T> {

    public QuickSort () {
    }

    private ulong partition (ref LinkedList<T> arr, ulong left, ulong right) {
      ulong i = left;
      ulong j = right - 1;
      while (i < j) {
        // find value bigger than pivot
        while (arr.Compare(i, right) <= 0 && i < right) {
          i++;
        }
        // find value smaller than pivot
        while (arr.Compare(j, right) >= 0 && j > left) {
          j--;
        }
        if (i < j) {
          arr.Swap(i, j);
        }
      }
      if (arr.Compare(i, right) > 0) {
        arr.Swap(i, right);
      }
      return i;
    }

    private void qsort (ref LinkedList<T> arr, ulong left, ulong right) {
      if (left >= right) {
        return;
      }
      ulong pindex = partition(ref arr, left, right);
      if (pindex > 0) {
        qsort(ref arr, left, pindex - 1);
      }
      qsort(ref arr, pindex + 1, right);
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      if (arr.Count == 0) {
        return null;
      }
      arr = arr.ShallowCopy();
      qsort(ref arr, 0, arr.Count - 1);
      return arr;
    }
  }
}
