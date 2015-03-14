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
      heapifyUp(this.data.Count - 1);
    }

    private void heapifyUp (ulong childIdx) {
      if (childIdx > 0) {
        ulong parentIdx = (childIdx - 1) / 2;
        if (this.data.Compare(childIdx, parentIdx) > 0){
          this.data.Swap(parentIdx, childIdx);
          heapifyUp(parentIdx);
        }
      }
    }

    private string getPrintValue (ulong index) {
      return index >= this.data.Count ? "<null>" : this.data[index].ToString();
    }

    private string print(string initial, ulong index, string prefix = "") {
      if (index < this.data.Count) {
        initial += prefix + "+- " + getPrintValue(index) + "\n";
        initial = print(initial, 2 * index + 1, prefix + "|  ");
        initial = print(initial, 2 * index + 2, prefix + "|  ");
      }
      return initial;
    }

    public override string ToString () {
      return print("<BinaryHeap(" + this.data.Count + ")\n", 0) + ">";
    }
  }
}
