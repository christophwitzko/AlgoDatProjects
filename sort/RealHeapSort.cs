using LinkedListExample;
using System;

namespace SortExample {
  public class RealHeapSort<T> {

    public RealHeapSort () {
    }

    private void heapify (LinkedList<T> arr, ulong heapSize, ulong parentIdx) {
      ulong leftChildIdx = 2 * parentIdx + 1;
      ulong rightChildIdx = leftChildIdx + 1;
      ulong largestChildIdx = parentIdx;
      if (leftChildIdx < heapSize && arr.Compare(leftChildIdx, largestChildIdx) > 0) {
        largestChildIdx = leftChildIdx;
      }
      if (rightChildIdx < heapSize && arr.Compare(rightChildIdx, largestChildIdx) > 0) {
        largestChildIdx = rightChildIdx;
      }
      if (largestChildIdx != parentIdx) {
        arr.Swap(parentIdx, largestChildIdx);
        heapify(arr, heapSize, largestChildIdx);
      }
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      arr = arr.ShallowCopy();
      ulong heapSize = arr.Count;
      for (ulong p = (heapSize - 1) / 2 + 1; p > 0; p--) {
        heapify(arr, heapSize, p - 1);
      }
      for (ulong i = arr.Count - 1; i > 0; i--) {
        arr.Swap(i, 0);
        heapSize--;
        heapify(arr, heapSize, 0);
      }
      return arr;
    }
  }
}
