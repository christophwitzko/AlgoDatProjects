using System;
 
namespace LinkedListExample {
  public class LinkedListNode {
    public LinkedList List;
    public LinkedListNode Previous;
    public LinkedListNode Next;
    public int Value;

    public LinkedListNode (LinkedList list, int value, LinkedListNode next) {
      this.List = list;
      this.Value = value;
      this.Next = next;
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

    public void AddFirst (int value) {
      LinkedListNode el = new LinkedListNode(this, value, this.First);
      this.First = el;
      if (this.Count == 0) {
        this.Last = el;
      }
      this.Count++;
    }

    public void AddLast (int value) {
      LinkedListNode el = new LinkedListNode(this, value, null);
      if (this.Count == 0) {
        this.First = el;
      } else {
        this.Last.Next = el;
      }
      this.Last = el;
      this.Count++;
    }

    public void AddAfter (LinkedListNode sel, int value) {
      if (!sel.List.Equals(this)) {
        throw new Exception("invalid list node");
      }
      if (sel.Next == null) {
        AddLast(value);
        return;
      }
      LinkedListNode el = new LinkedListNode(this, value, sel.Next);
      sel.Next = el;
      this.Count++;
    }

    public void AddBefore (LinkedListNode eel, int value) {
      
    }

    private string Traverse (string ret, LinkedListNode el) {
      if (el != null) {
        ret += "\t" + el.Value + "\n";
        return Traverse(ret, el.Next);
      }
      return ret;
    }

    public override string ToString() {
      string ret = Traverse("(" + this.Count + ")[\n", this.First);
      ret += "]";
      return ret;
    }
  }
}
