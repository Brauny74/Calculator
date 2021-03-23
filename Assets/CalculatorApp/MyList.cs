using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Это реализация MyList через существующий List.
/// </summary>
public class MyList<T> : IList<T>
{
    private List<T> _list = new List<T>();

    public int Count => _list.Count;

    public bool IsReadOnly => ((IList<T>)_list).IsReadOnly;

    public T this[int index]
    {
        get => _list[index];
        set
        {
            _list[index] = value;
        }
    }

    public MyList()
    {
    }

    public MyList(List<T> baseList)
    {
        List<T> _list = new List<T>(baseList);
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
    }

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    public void Remove(T item)
    {
        _list.Remove(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array)
    {
        _list.CopyTo(array);
    }

    public void CopyTo(T[] array, int index)
    {
        _list.CopyTo(array, index);
    }

    public void CopyTo(int index, T[] array, int arrayIndex, int count)
    {
        _list.CopyTo(index, array, arrayIndex, count);
    }

    bool ICollection<T>.Remove(T item)
    {
        return _list.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
