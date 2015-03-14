using LinkedListExample;
using BinaryTreeExample;
using System;

namespace SortExample {
  public class HeapSort<T> {

    public HeapSort () {
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      BinaryHeap<T> heap = new BinaryHeap<T>(true);
      for (ulong i = 0; i < arr.Count; i++) {
        heap.Insert(arr[i]);
      }
      LinkedList<T> oarr = new LinkedList<T>();
      for (ulong i = 0; i < arr.Count; i++) {
        oarr.AddLast(heap.RemoveTop());
      }
      return oarr;
    }
  }
}
