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
      if (el != null) {
        el.Previous = null;
        TraverseClear(el.Next);
        el.Next = null;
      }
    }

    public void Clear () {
      this.Last = null;
      TraverseClear(this.First);
      this.First = null;
      this.Count = 0;
    }

    public bool Contains(int value) {
      return false;
    }

    public LinkedListNode Find (int value) {
      return null;
    }

    public LinkedListNode FindLast (int value) {
      return null;
    }

    public LinkedListNode Remove (int value) {
      return null;
    }

    public LinkedListNode Remove (LinkedListNode sel) {
      return null;
    }

    public LinkedListNode RemoveFirst () {
      return null;
    }

    public LinkedListNode RemoveLast () {
      return null;
    }

    private string TraverseLeft (string ret, LinkedListNode el) {
      if (el != null) {
        ret += "\t" + el.Value + "\n";
        return TraverseLeft(ret, el.Next);
      }
      return ret;
    }

    private string TraverseRight (string ret, LinkedListNode el) {
      if (el != null) {
        ret += "\t" + el.Value + "\n";
        return TraverseRight(ret, el.Previous);
      }
      return ret;
    }

    public void PrintLeft () {
      Console.WriteLine(TraverseLeft("(" + this.Count + ")[\n", this.First) + "]");
    }

    public void PrintRight () {
      Console.WriteLine(TraverseRight("(" + this.Count + ")[\n", this.Last) + "]");
    }

    public override string ToString () {
      return TraverseLeft("(" + this.Count + ")[\n", this.First) + "]";
    }
  }
}
