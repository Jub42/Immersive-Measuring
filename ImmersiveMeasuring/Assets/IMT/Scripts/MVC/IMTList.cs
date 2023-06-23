using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMTList<T>
{
    public struct Tuple
    {
        public Tuple(int index, T t)
        {
            this.Index = index;
            this.T = t;
        }

        public int Index { get; }
        public T T { get; }
        public override string ToString() => $"<{Index}, {T}>";
    }

    private List<Tuple> list = new List<Tuple>();
    public List<Tuple> List() { return list; }
    public int Count => list.Count;

    #region Constructor
    public IMTList() { }
    public IMTList(List<T> otherList)
    {
        Tuple t;
        for(int i = 0; i < otherList.Count; i++)
        {
            t = new Tuple(i, otherList[i]);
            list.Add(t);
        }
    }
    #endregion

    public List<T> GetTList()
    {
        List<T> TList = new List<T>();
        for(int i = 0; i < list.Count; i++)
        {
            TList.Add(list[i].T);
        }

        return TList;
    }

    public void AddToList(T t)
    {  
        list.Add(new Tuple(list.Count, t));
    }

    public void RemoveFromList(int i, T t)
    {
        list.Remove(new Tuple(i, t));
    }

    public void RemoveItemAt(int pos)
    {
        list.RemoveAt(pos);
    }

    public void Clear()
    {
        list.Clear();
    }
}
