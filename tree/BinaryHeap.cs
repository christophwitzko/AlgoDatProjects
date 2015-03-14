using LinkedListExample;
using System;

namespace BinaryTreeExample {

  public class BinaryHeap<T> {
    private LinkedList<T> data;

    public BinaryHeap () {
      this.data = new LinkedList<T>();
    }

    public ulong Count {
      get {
        return this.data.Count;
      }
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
      if (this.Count > 1) {
        this.data.Swap(0, this.Count - 1);
      }
      T value = this.data.RemoveLast().Value;
      heapifyDown(0);
      return value;
    }

    private void heapifyUp (ulong childIdx) {
      if (childIdx > 0) {
        ulong parentIdx = (childIdx - 1) / 2;
        if (this.data.Compare(childIdx, parentIdx) < 0){
          this.data.Swap(parentIdx, childIdx);
          heapifyUp(parentIdx);
        }
      }
    }

    private void heapifyDown (ulong parentIdx) {
      ulong leftChildIdx = 2 * parentIdx + 1;
      ulong rightChildIdx = leftChildIdx + 1;
      ulong smallestChildIdx = parentIdx;
      if (leftChildIdx < this.Count && this.data.Compare(leftChildIdx, smallestChildIdx) < 0) {
        smallestChildIdx = leftChildIdx;
      }
      if (rightChildIdx < this.Count && this.data.Compare(rightChildIdx, smallestChildIdx) < 0) {
        smallestChildIdx = rightChildIdx;
      }
      if (smallestChildIdx != parentIdx) {
        this.data.Swap(parentIdx, smallestChildIdx);
        heapifyDown(smallestChildIdx);
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
