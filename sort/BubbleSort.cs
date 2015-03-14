using LinkedListExample;
using System;

namespace SortExample {
  public class BubbleSort<T> {

    public BubbleSort () {
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      arr = arr.ShallowCopy();
      bool swapped = true;
      while (swapped) {
        swapped = false;
        for (ulong i = 0; i < arr.Count - 1; i++) {
          if (arr.Compare(i, i + 1) > 0) {
            arr.Swap(i, i + 1);
            swapped = true;
          }
        }
      }
      return arr;
    }
  }
}
