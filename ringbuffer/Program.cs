using System;

namespace RingBufferExample {
  public class Program {
    public static void Main(string[] args) {
      RingBuffer<int> rbuffer = new RingBuffer<int>(20);
      for (int i = 100; i < 200; i++) {
        rbuffer.Put(i);
      }
      Console.WriteLine(rbuffer);
      ulong size = rbuffer.Size;
      for (ulong i = 0; i < size; i++) {
        Console.WriteLine(rbuffer.Get());
      }
      Console.WriteLine(rbuffer);
    }
  }
}
