using System;
 
namespace LinkedListExample {
  public class LinkedListNode {
    public LinkedList List;
    public LinkedListNode Previous;
    public LinkedListNode Next;
    public int Value;

    public LinkedListNode (LinkedList list, LinkedListNode previous, LinkedListNode next, int value) {
      this.List = list;
      this.Previous = previous;
      this.Next = next;
      this.Value = value;
    }

    public override string ToString () {
      return this.Value.ToString();
    }
  }

  public class LinkedList {
    public LinkedListNode First;
    public LinkedListNode Last;
    public ulong Count;

    public LinkedList () {
      this.First = null;
      this.Last = null;
      this.Count = 0;
    }

    public LinkedListNode AddFirst (int value) {
      LinkedListNode el = new LinkedListNode(this, null, this.First, value);
      if (this.Count == 0) {
        this.Last = el;
      } else {
        this.First.Previous = el;
      }
      this.First = el;
      this.Count++;
      return el;
    }

    public LinkedListNode AddLast (int value) {
      LinkedListNode el = new LinkedListNode(this, this.Last, null, value);
      if (this.Count == 0) {
        this.First = el;
      } else {
        this.Last.Next = el;
      }
      this.Last = el;
      this.Count++;
      return el;
    }

    public LinkedListNode AddAfter (LinkedListNode sel, int value) {
      if (!sel.List.Equals(this)) {
        throw new Exception("invalid list node");
      }
      if (sel.Next == null) {
        return AddLast(value);
      }
      LinkedListNode el = new LinkedListNode(this, sel, sel.Next, value);
      sel.Next.Previous = el;
      sel.Next = el;
      this.Count++;
      return el;
    }

    public LinkedListNode AddBefore (LinkedListNode sel, int value) {
      if (!sel.List.Equals(this)) {
        throw new Exception("invalid list node");
      }
      if (sel.Previous == null) {
        return AddFirst(value);
      }
      LinkedListNode el = new LinkedListNode(this, sel.Previous, sel, value);
      sel.Previous.Next = el;
      sel.Previous = el;
      this.Count++;
      return el;
    }

    private void TraverseClear (LinkedListNode el) {
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

    private LinkedListNode TraverseFind (bool reverse, int value, LinkedListNode el) {
      if (el == null) {
        return null;
      }
      if (el.Value == value) {
        return el;
      }
      return TraverseFind(reverse, value, reverse ? el.Previous : el.Next);
    }

    public LinkedListNode Find (int value) {
      return TraverseFind(false, value, this.First);
    }

    public LinkedListNode FindLast (int value) {
      return TraverseFind(true, value, this.Last);
    }

    public bool Contains(int value) {
      return Find(value) != null;
    }

    public LinkedListNode Remove (LinkedListNode sel) {
      if (this.Count < 1) {
        return null;
      }
      if (!sel.List.Equals(this)) {
        throw new Exception("invalid list node");
      }
      if (this.Count == 1) {
        if (!sel.Equals(this.First)) {
          throw new Exception("invalid list node");
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

    public LinkedListNode RemoveAll (int value) {
      LinkedListNode fnd;
      while ((fnd = Find(value)) != null) {
        Remove(fnd);
      }
      return null;
    }

    public LinkedListNode RemoveFirst () {
      return Remove(this.First);
    }

    public LinkedListNode RemoveLast () {
      return Remove(this.Last);
    }

    private string TraversePrint (bool reverse, string ret, LinkedListNode el) {
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
