using LinkedListExample;
using System;

namespace StackExample {
  public class Stack {
    private LinkedList<int> List;

    public Stack () {
      this.List = new LinkedList<int>();
    }

    public void Push (int value) {
      this.List.AddLast(value);
    }

    public int Pop () {
      LinkedListNode<int> el = this.List.RemoveLast();
      if (el == null) {
        throw new Exception("stack is empty");
      }
      return el.Value;
    }

    public int Peek () {
      if (this.List.Last == null) {
        throw new Exception("queue is empty");
      }
      return this.List.Last.Value;
    }

    public override string ToString () {
      return this.List.ToString();
    }
  }
}
