using System;

namespace HashTableExample {
  public class Program {

    public static void Main(string[] args) {
      HashTable<string> htable = new HashTable<string>();
      htable.Insert(324, "A");
      htable.Insert(11, "B");
      htable.Insert(55, "C");
      htable.Insert(110, "D");
      Console.WriteLine(htable + "\n");
      Console.WriteLine("324: " + htable[324]);
      htable[111] = "AAA";
      htable[222] = "BBB";
      htable[333] = "CCC";
      htable[777] = "ZZZ";
      Console.WriteLine("RM 55: " + htable.Remove(55));
      Console.WriteLine("\n" + htable);
    }
  }
}
