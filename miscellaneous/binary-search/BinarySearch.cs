using LinkedListExample;
using System;

namespace BinarySearchExample {
  public class BinarySearch<T> {
    private readonly System.Collections.Generic.IComparer<T> comparer;

    public BinarySearch () {
      this.comparer = System.Collections.Generic.Comparer<T>.Default;
    }

    private long search(LinkedList<T> arr, T value, ulong low, ulong high) { 
      if (low > high) {
        return -1;
      }
      ulong mid = (low + high) / 2;
      int comp = this.comparer.Compare(arr[mid], value);
      if (comp == 0) {
        return (long) mid;
      } else if (comp < 0) {
        return search(arr, value, mid + 1, high);
      } else {
        return search(arr, value, low, mid - 1);
      }  
    }

    public long Search(LinkedList<T> arr, T value) {
      return search(arr, value, 0, arr.Count - 1);
    }
  }
}