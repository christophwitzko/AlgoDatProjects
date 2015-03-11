using LinkedListExample;
using System;
 
namespace LinkedListClient {
  class Program {
    static void Main(string[] args) {
      LinkedList list = new LinkedList();
      for (int i = 0; i < 5; i++) {
        list.AddFirst(i);
        list.AddLast(i * 2);
      }
      LinkedListNode node = list.AddAfter(list.AddAfter(list.First, 111), 222);
      list.AddBefore(node, 333);
      list.PrintLeft();
      LinkedListNode found = list.Find(2);
      LinkedListNode foundLast = list.FindLast(2);
      Console.WriteLine(found.Previous);
      Console.WriteLine(foundLast.Next);
      //list.Clear();
      list.PrintRight();
    }
  }
}
