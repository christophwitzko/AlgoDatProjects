using System;

namespace RingBufferExample {
  public class RingBuffer<T> {
    private ulong capacity;
    private ulong size;
    public ulong head;
    public ulong tail;
    private T[] buffer;

    public ulong Capacity {
      get {
        return this.capacity;
      }
    }

    public ulong Size {
      get {
        return this.size;
      }
    }

    public RingBuffer (ulong cap) {
      this.capacity = cap;
      this.size = 0;
      this.head = 0;
      this.tail = 0;
      this.buffer = new T[cap];
    }

    private ulong increase (ulong value) {
      return (value + 1) % this.capacity;
    }

    public void Put (T item) {
      this.buffer[this.tail] = item;
      this.tail = increase(this.tail);
      this.size++;
      if (this.size > this.capacity) {
        this.size = this.capacity;
      }
    }

    public void Skip () {
      this.head = increase(this.head);
    }

    public T Get() {
      if (this.size == 0) {
        throw new IndexOutOfRangeException();
      }
      T item = this.buffer[this.head];
      this.head = increase(this.head);
      this.size--;
      return item;
    }

    public override string ToString () {
      return "<RingBuffer(" + this.size + "/" + this.capacity + ")>";
    }
  }
}
