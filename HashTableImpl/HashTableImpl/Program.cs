using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HashTableImpl
{   

    class Program
    {
        public struct KeyValPair<TKey, TValue>
        {
            public TKey key { get; set; }
            public TValue val { get; set; }
        };
        
        public class HashTab<TKey, TValue>
        {
            private const int max = 100;
            private List<LinkedList<KeyValPair<TKey, TValue>>> listKeyVal = new List<LinkedList<KeyValPair<TKey, TValue>>>(max);

            public HashTab()
            {
                initialize();
            }

            private void initialize()
            {
                for (int i = 0; i < max; i++)
                    listKeyVal.Add(new LinkedList<KeyValPair<TKey, TValue>>());
            }

            private int hash(String s)
            {
                int val = 0;
                
                foreach (char c in s)
                {
                    val = c + 31 * val;
                }
                return val % max;
            }

            public void Add(TKey key, TValue val)
            {
                int hashKey = hash(key.ToString());                
                
                LinkedList<KeyValPair<TKey, TValue>> llKeyVal = listKeyVal.ElementAtOrDefault(hashKey);
                
                if (llKeyVal == null)
                    llKeyVal = new LinkedList<KeyValPair<TKey, TValue>>();
                KeyValPair<TKey, TValue> kv = new KeyValPair<TKey,TValue>();
                kv.key = key;
                kv.val = val;
                llKeyVal.AddFirst(kv);
                //listKeyVal[hashKey] = llKeyVal;
            }

            public bool ContainsKey(TKey key)
            {
                int hashKey = hash(key.ToString());
                foreach (KeyValPair<TKey, TValue> kv in listKeyVal[hashKey])
                {
                    if (kv.key.ToString() == key.ToString())
                        return true;
                }
                return false;
            }

            public TValue GetValue(TKey key)
            {
                if (!ContainsKey(key))
                    throw new Exception("Key not found");
                LinkedList<KeyValPair<TKey, TValue>> llkv = listKeyVal[hash(key.ToString())];
                foreach (KeyValPair<TKey, TValue> kv in llkv)
                {
                    if (kv.key.ToString() == key.ToString())
                        return kv.val;
                }
                return default(TValue);
            }
        
        }
        
        static void Main(string[] args)
        {
            HashTab<String, int> ht = new HashTab<string, int>();
            ht.Add("C#", 1);
            ht.Add("Java", 2);
            ht.Add("C", 3);

            Console.WriteLine("ht.ContainsKey(X10) = " + ht.ContainsKey("X10"));
            Console.WriteLine("ht.GetValue(C#) == " + ht.GetValue("C#"));
            Console.WriteLine("ht.GetValue(Java) == " + ht.GetValue("Java"));
            Console.ReadLine();
        }
    }
}
