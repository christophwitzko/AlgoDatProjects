using System;
 
namespace LinkedListExample {
  public class Program {
    public static void Main(string[] args) {
      LinkedList list = new LinkedList();
      for (int i = 0; i < 5; i++) {
        list.AddFirst(i);
        list.AddLast(i);
      }
      LinkedListNode node = list.AddAfter(list.First, 222);
      list.AddBefore(node, 111);
      list.PrintRight();
      list.RemoveAll(2);
      Console.WriteLine("DELEGATE TRAVERSE:");
      list.Traverse(list.First, value => {
        Console.WriteLine(value);
      });
    }
  }
}
