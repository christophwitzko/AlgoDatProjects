using LinkedListExample;
using System;

namespace SortExample {
  public class MergeSort<T> {
    private readonly System.Collections.Generic.IComparer<T> comparer;

    public MergeSort () {
      this.comparer = System.Collections.Generic.Comparer<T>.Default;
    }

    public LinkedList<T> Merge (LinkedList<T> left, LinkedList<T> right) {
      LinkedList<T> newArr = new LinkedList<T>(left.Count + right.Count);
      ulong i = 0;
      ulong j = 0;
      ulong k = 0;
      while (i < left.Count && j < right.Count) {
        if (this.comparer.Compare(left[i], right[j]) < 0) {
          newArr[k] = left[i];
          i++;
        } else {
          newArr[k] = right[j];
          j++;
        }
        k++;
      }
      while (i < left.Count) {
        newArr[k] = left[i];
        i++;
        k++;
      }
      while (j < right.Count) {
        newArr[k] = right[j];
        j++;
        k++;
      }
      return newArr;
    }

    public LinkedList<T> Sort (LinkedList<T> arr) {
      if (arr.Count <= 1) {
        return arr;
      }
      ulong middle = arr.Count / 2;
      LinkedList<T> left = new LinkedList<T>(middle);
      LinkedList<T> right = new LinkedList<T>(arr.Count - middle);
      for (ulong i = 0; i < middle; i++) {
              left[i] = arr[i];
      }
      for (ulong i = middle; i < arr.Count; i++) {
        right[i - middle] = arr[i];
      }
      return Merge(Sort(left), Sort(right));
    }
  }
}
