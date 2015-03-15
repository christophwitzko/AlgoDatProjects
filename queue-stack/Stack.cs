using LinkedListExample;
using System;

namespace StackExample {
  public class Stack<T> {
    private LinkedList<T> List;

    public ulong Count {
      get {
        return this.List.Count;
      }
    }

    public Stack () {
      this.List = new LinkedList<T>();
    }

    public void Push (T value) {
      this.List.AddLast(value);
    }

    public T Pop () {
      if (this.Count == 0) {
        throw new Exception("stack is empty");
      }
      return this.List.RemoveLast().Value;
    }

    public T Peek () {
      if (this.Count == 0) {
        throw new Exception("queue is empty");
      }
      return this.List.Last.Value;
    }

    public override string ToString () {
      return this.List.ToString();
    }
  }
}
