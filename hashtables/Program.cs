using System;

namespace HashTableExample {
  public class Program {

    public static void Main(string[] args) {
      HashTable<string> htable = new HashTable<string>();
      htable.Insert(324, "A");
      htable.Insert(11, "B");
      htable.Insert(55, "C");
      htable.Insert(110, "D");
      Console.WriteLine(htable);
      Console.WriteLine(htable.Remove(55));
      Console.WriteLine(htable);
    }
  }
}
