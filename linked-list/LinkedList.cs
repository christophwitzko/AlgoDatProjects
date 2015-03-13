using System;
using System.Collections.Generic;

namespace LinkedListExample {
  public class LinkedListNode<T> {
    private LinkedList<T> list;
    public LinkedListNode<T> Previous;
    public LinkedListNode<T> Next;
    public T Value;

    public LinkedList<T> List {
      get {
        return this.list;
      }
    }
    public LinkedListNode (LinkedList<T> parrent, LinkedListNode<T> previous, LinkedListNode<T> next, T value) {
      this.list = parrent;
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
    private LinkedListNode<T> first;
    private LinkedListNode<T> last;
    private ulong count;
    private readonly IComparer<T> comparer;

    public LinkedListNode<T> First {
      get {
        return this.first;
      }
    }

    public LinkedListNode<T> Last {
      get {
        return this.last;
      }
    }

    public ulong Count {
      get {
        return this.count;
      }
    }

    public delegate void LinkedListNodeVisitor(T value, LinkedListNode<T> node);

    public LinkedList () {
      this.first = null;
      this.last = null;
      this.count = 0;
      this.comparer = Comparer<T>.Default;
    }

    public LinkedListNode<T> AddFirst (T value) {
      LinkedListNode<T> el = new LinkedListNode<T>(this, null, this.first, value);
      if (this.count == 0) {
        this.last = el;
      } else {
        this.first.Previous = el;
      }
      this.first = el;
      this.count++;
      return el;
    }

    public LinkedListNode<T> AddLast (T value) {
      LinkedListNode<T> el = new LinkedListNode<T>(this, this.last, null, value);
      if (this.count == 0) {
        this.first = el;
      } else {
        this.last.Next = el;
      }
      this.last = el;
      this.count++;
      return el;
    }

    public LinkedListNode<T> AddAfter (LinkedListNode<T> sel, T value) {
      if (sel == null) {
        return AddFirst(value);
      }
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (sel.Next == null) {
        return AddLast(value);
      }
      LinkedListNode<T> el = new LinkedListNode<T>(this, sel, sel.Next, value);
      sel.Next.Previous = el;
      sel.Next = el;
      this.count++;
      return el;
    }

    public LinkedListNode<T> AddBefore (LinkedListNode<T> sel, T value) {
      if (sel == null) {
        return AddLast(value);
      }
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (sel.Previous == null) {
        return AddFirst(value);
      }
      LinkedListNode<T> el = new LinkedListNode<T>(this, sel.Previous, sel, value);
      sel.Previous.Next = el;
      sel.Previous = el;
      this.count++;
      return el;
    }

    private void traverseClear (LinkedListNode<T> el) {
      if (el == null) {
        return;
      }
      el.Previous = null;
      traverseClear(el.Next);
      el.Next = null;
    }

    public void Clear () {
      this.last = null;
      traverseClear(this.first);
      this.first = null;
      this.count = 0;
    }

    private LinkedListNode<T> traverseFind (bool reverse, T value, LinkedListNode<T> el) {
      if (el == null) {
        return null;
      }
      if (EqualityComparer<T>.Default.Equals(el.Value, value)) {
        return el;
      }
      return traverseFind(reverse, value, reverse ? el.Previous : el.Next);
    }

    public LinkedListNode<T> Find (T value) {
      return traverseFind(false, value, this.first);
    }

    public LinkedListNode<T> FindLast (T value) {
      return traverseFind(true, value, this.last);
    }

    public bool Contains(T value) {
      return Find(value) != null;
    }

    public LinkedListNode<T> Remove (LinkedListNode<T> sel) {
      if (this.count < 1) {
        return null;
      }
      if (!sel.List.Equals(this)) {
        throw new InvalidLinkedListNode();
      }
      if (this.count == 1) {
        if (!sel.Equals(this.first)) {
          throw new InvalidLinkedListNode();
        }
        this.first = null;
        this.last = null;
      } else if (sel.Previous == null) {
        this.first = sel.Next;
        sel.Next.Previous = null;
      } else if (sel.Next == null) {
        this.last = sel.Previous;
        sel.Previous.Next = null;
      } else {
        sel.Previous.Next = sel.Next;
        sel.Next.Previous = sel.Previous;
      }
      this.count--;
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
      return Remove(this.first);
    }

    public LinkedListNode<T> RemoveLast () {
      return Remove(this.last);
    }

    public void Traverse (LinkedListNode<T> node, LinkedListNodeVisitor visitor, bool reverse = false) {
      visitor(node.Value, node);
      LinkedListNode<T> next = reverse ? node.Previous : node.Next;
      if (next != null) {
        Traverse(next, visitor, reverse);
      }
    }

    public LinkedListNode<T> GetByIndex (ulong index) {
      if (index < 0 || index >= this.count) {
        throw new IndexOutOfRangeException();
      }
      LinkedListNode<T> current = this.first;
      for (ulong i = 0; i < this.count; i++) {
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

    public void Swap (LinkedListNode<T> a, LinkedListNode<T> b) {
      AddAfter(Remove(a).Previous, b.Value);
      AddAfter(Remove(b).Previous, a.Value);
    }

    public void Swap (ulong a, ulong b) {
      Swap(GetByIndex(a), GetByIndex(b));
    }

    public int Compare (LinkedListNode<T> a, LinkedListNode<T> b) {
      return this.comparer.Compare(a.Value, b.Value);
    }

    public int Compare (ulong a, ulong b) {
      return Compare(GetByIndex(a), GetByIndex(b));
    }

    private string traversePrint (bool reverse, string ret, LinkedListNode<T> el) {
      if (el == null) {
        return ret;
      }
      ret += "\t" + el.Value + "\n";
      return traversePrint(reverse, ret, reverse ? el.Previous : el.Next);
    }

    public void PrintRight () {
      Console.WriteLine(traversePrint(false, "(" + this.count + ")[\n", this.first) + "]");
    }

    public void PrintLeft () {
      Console.WriteLine(traversePrint(true, "(" + this.count + ")[\n", this.last) + "]");
    }

    public override string ToString () {
      return traversePrint(false, "(" + this.count + ")[\n", this.first) + "]";
    }
  }
}
