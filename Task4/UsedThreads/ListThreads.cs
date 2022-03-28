using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UsedThreads;

internal class LisThreads1<T> : List<T>
{
    private readonly ReaderWriterLockSlim LockList = new ReaderWriterLockSlim();
    private readonly List<T> keeper = new List<T>();

    public void Add(T elem)
    {
        LockList.EnterWriteLock();
        try
        {
            keeper.Add(elem);
        }
        finally
        {
            LockList.ExitWriteLock();
        }
    }

    public void Remove(T elem)
    {
        LockList.EnterWriteLock();
        try
        {
            if (keeper.Contains(elem))
                keeper.Remove(elem);
        }
        finally
        {
            LockList.ExitWriteLock();
        }
    }

    public int Count()
    {
        LockList.EnterReadLock();
        try
        {
            return keeper.Count;
        }
        finally
        {
            LockList.ExitReadLock();
        }
    }

    public void Clear()
    {
        LockList.EnterWriteLock();
        try
        {
            keeper.Clear();
        }
        finally
        {
            LockList.ExitWriteLock();
        }
    }

    public T First()
    {
        LockList.EnterReadLock();
        try
        {
            return keeper.First();
        }
        finally
        {
            LockList.ExitReadLock();
        }
    }

    public T Last()
    {
        LockList.EnterReadLock();
        try
        {
            return keeper.Last();
        }
        finally
        {
            LockList.ExitReadLock();
        }
    }

    public T Find(Predicate<T> predic)
    {
        LockList.EnterReadLock();
        try
        {
            return keeper.Find(predic);
        }
        finally
        {
            LockList.ExitReadLock();
        }
    }

    public void ForEach(Action<T> action)
    {
        LockList.EnterReadLock();
        try
        {
            keeper.ForEach(action);
        }
        finally
        {
            LockList.ExitReadLock();
        }
    }
}
