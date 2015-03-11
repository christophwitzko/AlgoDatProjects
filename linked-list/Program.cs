using LinkedListExample;
using System;
 
namespace LinkedListClient {
  class Program {
    static void Main(string[] args) {
      LinkedList list = new LinkedList();
      for (int i = 0; i < 10; i++) {
        list.AddFirst(i);
      }
      for (int i = 0; i < 10; i++) {
        list.AddLast(i);
      }
      list.AddAfter(list.First, 111);
      Console.WriteLine(list);
    }
  }
}