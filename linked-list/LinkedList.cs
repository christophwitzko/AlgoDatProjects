using System;
using System.Collections.Generic;

namespace LinkedListExample {
  public class LinkedListNode<T> {
    public LinkedList<T> List;
    public LinkedListNode<T> Previous;
    public LinkedListNode<T> Next;
    public T Value;

    public LinkedListNode (LinkedList<T> list, LinkedListNode<T> previous, LinkedListNode<T> next, T value) {
      this.List = list;
      this.Previous = previous;
      this.Next = next;
      this.Value = value;
    }

    public override string ToString () {
      return this.Value.ToString();
    }
  }

  public class InvalidLinkedListNode: Exception {
    public InvalidLinkedListNode () {
    }

    public InvalidLinkedListNode (string message): base(message){
    }

    public InvalidLinkedListNode (string message, Exception inner): base(message, inner) {
    }
  }

  public class LinkedList<T> {
    public LinkedListNode<T> First;
    public LinkedListNode<T> Last;
    public ulong Count;

    public delegate void LinkedListNodeVisitor(T value);

    public LinkedList () {
      this.First = null;
      this.Last = null;
      this.Count = 0;
    }

    public LinkedListNode<T> AddFirst (T value) {
      LinkedListNode<T> el = new LinkedListNode<T>(this, null, this.First, value);
      if (this.Count == 0) {
        this.Last = el;
      } else {
        this.First.Previous = el;
      }
      this.First = el;
      this.Count++;
      return el;
    }

    public LinkedListNode<T> AddLast (T value) {
      LinkedListNode<T> el = new LinkedListNode<T>(this, this.Last, null, value);
      if (this.Count == 0) {
        this.First = el;
      } else {
        this.Last.Next = el;
      }
      this.Last = el;
      this.Count++;
      return el;
    }

    public LinkedListNode<T> AddAfter (LinkedListNode<T> sel, T value) {
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (sel.Next == null) {
        return AddLast(value);
      }
      LinkedListNode<T> el = new LinkedListNode<T>(this, sel, sel.Next, value);
      sel.Next.Previous = el;
      sel.Next = el;
      this.Count++;
      return el;
    }

    public LinkedListNode<T> AddBefore (LinkedListNode<T> sel, T value) {
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (sel.Previous == null) {
        return AddFirst(value);
      }
      LinkedListNode<T> el = new LinkedListNode<T>(this, sel.Previous, sel, value);
      sel.Previous.Next = el;
      sel.Previous = el;
      this.Count++;
      return el;
    }

    private void TraverseClear (LinkedListNode<T> el) {
      if (el == null) {
        return;
      }
      el.Previous = null;
      TraverseClear(el.Next);
      el.Next = null;
    }

    public void Clear () {
      this.Last = null;
      TraverseClear(this.First);
      this.First = null;
      this.Count = 0;
    }

    private LinkedListNode<T> TraverseFind (bool reverse, T value, LinkedListNode<T> el) {
      if (el == null) {
        return null;
      }
      if (EqualityComparer<T>.Default.Equals(el.Value, value)) {
        return el;
      }
      return TraverseFind(reverse, value, reverse ? el.Previous : el.Next);
    }

    public LinkedListNode<T> Find (T value) {
      return TraverseFind(false, value, this.First);
    }

    public LinkedListNode<T> FindLast (T value) {
      return TraverseFind(true, value, this.Last);
    }

    public bool Contains(T value) {
      return Find(value) != null;
    }

    public LinkedListNode<T> Remove (LinkedListNode<T> sel) {
      if (this.Count < 1) {
        return null;
      }
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (this.Count == 1) {
        if (!sel.Equals(this.First)) {
          throw new InvalidLinkedListNode();
        }
        this.First = null;
        this.Last = null;
      } else if (sel.Previous == null) {
        this.First = sel.Next;
        sel.Next.Previous = null;
      } else if (sel.Next == null) {
        this.Last = sel.Previous;
        sel.Previous.Next = null;
      } else {
        sel.Previous.Next = sel.Next;
        sel.Next.Previous = sel.Previous;
      }
      this.Count--;
      return sel;
    }

    public LinkedListNode<T> RemoveAll (T value) {
      LinkedListNode<T> fnd;
      while ((fnd = Find(value)) != null) {
        Remove(fnd);
      }
      return null;
    }

    public LinkedListNode<T> RemoveFirst () {
      return Remove(this.First);
    }

    public LinkedListNode<T> RemoveLast () {
      return Remove(this.Last);
    }

    public void Traverse (LinkedListNode<T> node, LinkedListNodeVisitor visitor, bool reverse = false) {
      visitor(node.Value);
      LinkedListNode<T> next = reverse ? node.Previous : node.Next;
      if (next != null) {
        Traverse(next, visitor, reverse);
      }
    }

    public LinkedListNode<T> GetByIndex (ulong index) {
      if (index < 0 || index >= this.Count) {
        throw new IndexOutOfRangeException();
      }
      LinkedListNode<T> current = this.First;
      for (ulong i = 0; i < this.Count; i++) {
        if (index == i) {
          return current;
        }
        current = current.Next;
      }
      return null;
    }

    public T this[ulong index] {
      get {
        return GetByIndex(index).Value;
      }
      set {
        GetByIndex(index).Value = value;
      }
    }

    private string TraversePrint (bool reverse, string ret, LinkedListNode<T> el) {
      if (el == null) {
        return ret;
      }
      ret += "\t" + el.Value + "\n";
      return TraversePrint(reverse, ret, reverse ? el.Previous : el.Next);
    }

    public void PrintRight () {
      Console.WriteLine(TraversePrint(false, "(" + this.Count + ")[\n", this.First) + "]");
    }

    public void PrintLeft () {
      Console.WriteLine(TraversePrint(true, "(" + this.Count + ")[\n", this.Last) + "]");
    }

    public override string ToString () {
      return TraversePrint(false, "(" + this.Count + ")[\n", this.First) + "]";
    }
  }
}
