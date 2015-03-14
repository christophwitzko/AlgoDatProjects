using System;

namespace RingBufferExample {
  public class Program {
    public static void Main(string[] args) {
      RingBuffer<int> rbuffer = new RingBuffer<int>(20);
      for (int i = 0; i < 10; i++) {
        rbuffer.Put(i);
      }
      Console.WriteLine(rbuffer);
      while (rbuffer.Size > 0) {
        Console.WriteLine(rbuffer.Get());
      }
      Console.WriteLine(rbuffer);
    }
  }
}
