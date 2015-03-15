using LinkedListExample;
using System;

namespace QueueExample {
  public class Queue<T> {
    private LinkedList<T> List;

    public ulong Count {
      get {
        return this.List.Count;
      }
    }

    public Queue () {
      this.List = new LinkedList<T>();
    }

    public void Enqueue (T value) {
      this.List.AddLast(value);
    }

    public T Dequeue () {
      if (this.Count == 0) {
        throw new Exception("queue is empty");
      }
      return this.List.RemoveFirst().Value;
    }

    public T Peek () {
      if (this.Count == 0) {
        throw new Exception("queue is empty");
      }
      return this.List.First.Value;
    }

    public override string ToString () {
      return this.List.ToString();
    }
  }
}
