using LinkedListExample;
using System;

namespace BinarySearchExample {
  public class Program {
    public static void Main(string[] args) {
      LinkedList<int> list = new LinkedList<int>();
      // skipped sorting
      for (int i = 0; i < 20; i++) {
        list.AddLast(i);
      }
      list.PrintRight();
      BinarySearch<int> bsearch = new BinarySearch<int>();
      Console.WriteLine(bsearch.Search(list, 1));
      Console.WriteLine(bsearch.Search(list, 6));
      Console.WriteLine(bsearch.Search(list, 100));
    }
  }
}
