using LinkedListExample;
using System;
 
namespace LinkedListClient {
  class Program {
    static void Main(string[] args) {
      LinkedList list = new LinkedList();
      for (int i = 0; i < 5; i++) {
        list.AddFirst(i);
        list.AddLast(i);
      }
      LinkedListNode node = list.AddAfter(list.First, 222);
      list.AddBefore(node, 111);
      //LinkedListNode found = list.Find(111);
      list.PrintRight();
      //list.Remove(found);
      list.RemoveAll(2);
      list.PrintRight();
      list.PrintLeft();
    }
  }
}
