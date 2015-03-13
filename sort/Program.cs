using System;

namespace SortExample {
  public class Program {
    public static void Dump (string name, int[] sorted) {
      Console.WriteLine(name);
      for (int i = 0; i < sorted.Length; i++) {
        Console.Write(sorted[i] + " ");
      }
      Console.WriteLine("\n---------------------");
    }
    public static void Main(string[] args) {
      int[] values = {3, 6, 9, 1, 4, 7, 10, 8, 2, 5};
      BubbleSort<int> bsort = new BubbleSort<int>();
      Dump("BubbleSort:", bsort.Sort((int[])values.Clone()));
      SelectionSort<int> ssort = new SelectionSort<int>();
      Dump("SelectionSort:", ssort.Sort((int[])values.Clone()));
      InsertionSort<int> isort = new InsertionSort<int>();
      Dump("InsertionSort:", isort.Sort((int[])values.Clone()));
    }
  }
}
