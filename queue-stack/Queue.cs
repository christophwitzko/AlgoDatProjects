using LinkedListExample;
using System;

namespace QueueExample {
  public class Queue {
    private LinkedList List;

    public Queue () {
      this.List = new LinkedList();
    }

    public void Enqueue (int value) {
      this.List.AddLast(value);
    }

    public int Dequeue () {
      LinkedListNode el = this.List.RemoveFirst();
      if (el == null) {
        throw new Exception("queue is empty");
      }
      return el.Value;
    }

    public int Peek () {
      if (this.List.First == null) {
        throw new Exception("queue is empty");
      }
      return this.List.First.Value;
    }

    public override string ToString () {
      return this.List.ToString();
    }
  }
}
