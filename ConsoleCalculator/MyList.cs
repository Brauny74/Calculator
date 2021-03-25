using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Это реализация MyList через массив.
/// </summary>
public class MyList<T> : IList<T>
{
    private List<T> _list = new List<T>();
    private T[] _array;

    public int Count => _array.Length;

    public bool IsReadOnly
    {
        get => false;
    }

    public T this[int index]
    {
        get => _array[index];
        set
        {
            _array.SetValue(value, index);
        }
    }

    public MyList()
    {
        _array = new T[] { };
    }

    public MyList(List<T> baseList)
    {
        _array = baseList.ToArray();        
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    public void Insert(int index, T item)
    {        
        T[] newArray = new T[_array.Length + 1];
        for (int i = 0; i < index; i++)
        {
            newArray[i] = _array[i];
        }
        newArray[index] = item;
        for (int i = index; i < newArray.Length; i++)
        {
            newArray[i+1] = _array[i];
        }
        _array = newArray;
    }

    public void Add(T item)
    {
        T[] newArray = new T[_array.Length + 1];
        _array.CopyTo(newArray, 0);
        newArray[_array.Length] = item;
        _array = newArray;
    }

    public void RemoveAt(int index)
    {
        T[] newArray = new T[_array.Length - 1];
        for (int i = 0; i < _array.Length; i++)
        {
            if (i == index)
                continue;
            if (i < index)
                newArray[i] = _array[i];
            else
                newArray[i - 1] = _array[i];
        }
        _array = newArray;
    }

    public void Remove(T item)
    {
        RemoveAt(IndexOf(item));
    }

    public void Clear()
    {
        _array = new T[] { };
    }

    public bool Contains(T item)
    {
        foreach (T e in _array)
        {
            if (item.Equals(e))
                return true;
        }
        return false;
    }

    public void CopyTo(T[] array)
    {
        CopyTo(array, 0);
    }

    public void CopyTo(T[] array, int index)
    {
        CopyTo(index, array, 0, _array.Length - index);
    }

    public void CopyTo(int index, T[] array, int arrayIndex, int count)
    {
        for (int i = 0; i < count; i++)
        {
            array[arrayIndex + i] = _array[index + i];
        }
    }

    bool ICollection<T>.Remove(T item)
    {
        int i = IndexOf(item);
        if (i >= 0)
        {
            RemoveAt(i);
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _array.GetEnumerator();
    }
}
