using System;
 
namespace LinkedListExample {
  public class Program {
    public static void Main(string[] args) {
      LinkedList<int> list = new LinkedList<int>();
      for (int i = 0; i < 5; i++) {
        list.AddLast(i);
      }
      LinkedListNode<int> nodea = list.AddAfter(list.First, 222);
      list.AddAfter(nodea, 111);
      list.PrintRight();
      list.Swap(nodea, list.Last);
      Console.WriteLine(list.Compare(0, list.Count - 1));
      list.PrintRight();
      /*LinkedList<int> list2 = list.ShallowCopy();
      list.Clear();
      list.PrintRight();
      list2.PrintRight();*/
      /*Console.WriteLine("DELEGATE TRAVERSE:");
      list.Traverse(list.GetByIndex(list.Count / 2), (value, owner) => {
        Console.WriteLine(value);
      });*/
    }
  }
}
