using System;

namespace HashTableExample {
  public class KeyValuePair<TValue> {
    public int Key;
    public TValue Value;

    public KeyValuePair (int key, TValue value) {
      this.Key = key;
      this.Value = value;
    }
  }

  public class HashTable<TValue> {
    private KeyValuePair<TValue>[] table;
    private bool[] occupied;
    private int m;
    public int Count;

    public int Size {
      get {
        return this.m;
      }
    }

    public HashTable () {
      this.m = 4;
      this.table = new KeyValuePair<TValue>[this.m];
      this.occupied = new bool[this.m];
    }

    private int hash (int key) {
      return key % this.m;
    }

    private int getIndex (int key) {
      int sindex = hash(key);
      if (sindex < 0 || sindex >= this.m) {
        return -1;
      }
      int hindex = sindex;
      while(this.occupied[hindex] && this.table[hindex].Key != key) {
        hindex = (hindex + 1) % this.m;
        if (hindex == sindex) {
          return -1;
        }
      }
      return hindex;
    }

    public void Insert (KeyValuePair<TValue> kvp) {
      Resize();
      int hindex = getIndex(kvp.Key);
      if (hindex < 0) {
        throw new Exception("could not hash key");
      }
      this.occupied[hindex] = true;
      this.table[hindex] = kvp;
      this.Count++;
    }

    public void Insert (int key, TValue value) {
      Insert(new KeyValuePair<TValue>(key, value));
    }

    public TValue Remove (int key) {
      int hindex = getIndex(key);
      if (hindex < 0 || !this.occupied[hindex]) {
        throw new Exception("could not find key");
      }
      TValue ret = this.table[hindex].Value;
      this.occupied[hindex] = false;
      hindex = (hindex + 1) % this.m;
      while (this.occupied[hindex]) {
        this.occupied[hindex] = false;
        Insert(this.table[hindex]);
        hindex = (hindex + 1) % this.m;
      }
      this.Count--;
      return ret;
    }

    public bool Resize () {
      if (Math.Round((double) this.Size * 0.9) > (this.Count + 1)) {
        return false;
      }
      KeyValuePair<TValue>[] oldTable = (KeyValuePair<TValue>[]) this.table.Clone();
      bool[] oldOccupied = (bool[]) this.occupied.Clone();
      this.m *= 2;
      this.table = new KeyValuePair<TValue>[this.m];
      this.occupied = new bool[this.m];
      this.Count = 0;
      for (int i = 0; i < oldTable.Length; i++) {
        if (oldOccupied[i]) {
          Insert(oldTable[i]);
        }
      }
      return true;
    }

    public TValue GetByKey (int key) {
      int hindex = getIndex(key);
      if (hindex < 0 || !this.occupied[hindex]) {
        throw new Exception("could not find key");
      }
      return this.table[hindex].Value;
    }

    public TValue this[int key] {
      get {
        return GetByKey(key);
      }
      set {
        Insert(key, value);
      }
    }

    public override string ToString () {
      string ret = "(" + this.Count + "/" + this.Size + ")[\n";
      for (int i = 0; i < this.m; i++) {
        if (this.occupied[i]) {
          ret += "\t" + i + ": " + this.table[i].Key + "=" + this.table[i].Value +  "\n";
        }
      }
      return ret + "]";
    }
  }
}
