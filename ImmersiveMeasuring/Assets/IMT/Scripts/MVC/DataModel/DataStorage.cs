using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class DataStorage<T> : ScriptableObject
{
    List<T> data;

    public int Count
    { 
        get { return data.Count; }
    }

    public List<T> Data 
    { 
        get { return data; }
        set { data = value; } 
    }

    public T GetValue(int index)
    {
        return data[index];
    }
    public void SetValue(int index, T value)
    {
        data[index] = value;
    }

    public void AddData(T data)
    {
        this.data.Add(data);
    }
    public void RemoveData(T data)
    {
        this.data.Remove(data);
    }

    // ? 
    public void TransferTo(out DataStorage<T> storage)
    {
        storage = this;
    }

    public void Clear()
    {
        this.data.Clear();
    }
}
