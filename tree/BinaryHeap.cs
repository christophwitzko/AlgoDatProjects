using LinkedListExample;
using System;

namespace BinaryTreeExample {

  public class BinaryHeap<T> {
    private LinkedList<T> data;
    private bool minHeap;

    public ulong Count {
      get {
        return this.data.Count;
      }
    }

    public bool IsMinHeap {
      get {
        return this.minHeap;
      }
    }

    public BinaryHeap (bool min) {
      this.data = new LinkedList<T>();
      this.minHeap = min;
    }

    public BinaryHeap () : this(false) {
      this.data = new LinkedList<T>();
    }

    private bool compare (ulong a, ulong b) {
      int comp = this.data.Compare(a, b);
      if (comp > 0) {
        return !this.minHeap;
      } else if (comp < 0) {
        return this.minHeap;
      }
      return false;
    }

    public void Clear () {
      this.data.Clear();
    }

    public void Insert (T value) {
      this.data.AddLast(value);
      heapifyUp(this.Count - 1);
    }

    public T Peek () {
      return this.data[0];
    }

    public T RemoveTop () {
      this.data.Swap(0, this.Count - 1);
      T value = this.data.RemoveLast().Value;
      heapifyDown(0);
      return value;
    }

    private void heapifyUp (ulong childIdx) {
      if (childIdx > 0) {
        ulong parentIdx = (childIdx - 1) / 2;
        if (compare(childIdx, parentIdx)){
          this.data.Swap(parentIdx, childIdx);
          heapifyUp(parentIdx);
        }
      }
    }

    private void heapifyDown (ulong parentIdx) {
      ulong leftChildIdx = 2 * parentIdx + 1;
      ulong rightChildIdx = leftChildIdx + 1;
      ulong largestChildIdx = parentIdx;
      if (leftChildIdx < this.Count && compare(leftChildIdx, largestChildIdx)) {
        largestChildIdx = leftChildIdx;
      }
      if (rightChildIdx < this.Count && compare(rightChildIdx, largestChildIdx)) {
        largestChildIdx = rightChildIdx;
      }
      if (largestChildIdx != parentIdx) {
        this.data.Swap(parentIdx, largestChildIdx);
        heapifyDown(largestChildIdx);
      }
    }

    private string getPrintValue (ulong index) {
      return index < this.Count ? this.data[index].ToString() : "<null>";
    }

    private string print(string initial, ulong index, string prefix = "") {
      if (index < this.Count) {
        initial += prefix + "+- " + getPrintValue(index) + "\n";
        initial = print(initial, 2 * index + 1, prefix + "|  ");
        initial = print(initial, 2 * index + 2, prefix + "|  ");
      }
      return initial;
    }

    public override string ToString () {
      return print("<BinaryHeap(" + this.Count + ")\n", 0) + ">";
    }
  }
}
