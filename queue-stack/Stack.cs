using LinkedListExample;
using System;

namespace StackExample {
  public class Stack {
    private LinkedList List;

    public Stack () {
      this.List = new LinkedList();
    }

    public void Push (int value) {
      this.List.AddLast(value);
    }

    public int Pop () {
      LinkedListNode el = this.List.RemoveLast();
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
