using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> : GenericSingleton<GenericObjectPool<T>> where T : class
{
    private class PoolObject<T>
    {
        public T poolItem;
        public bool isActive;
    }

    List<PoolObject<T>> poolObjects = new List<PoolObject<T>>();
    protected virtual T GetPooledObject()
    {
        if(poolObjects.Count > 0)
        {
            PoolObject<T> pooledObject = poolObjects.Find(poolObject => !poolObject.isActive);

            if(pooledObject != null)
            {
                pooledObject.isActive = true;
                return pooledObject.poolItem;
            }
        }

        return CreateNewPooledObject();
    }

    protected T CreateNewPooledObject()
    {
        PoolObject<T> pooledObject = new PoolObject<T>();
        pooledObject.poolItem = CreatePoolItemInPooledObject();
        pooledObject.isActive = true;
        poolObjects.Add(pooledObject);
        return pooledObject.poolItem;
    }

    protected virtual T CreatePoolItemInPooledObject()
    {
        return null;
    }

    public virtual void ReturnPooledObject(T returningPooledItem)
    {
        PoolObject<T> pooledObject = poolObjects.Find(pooledItem => pooledItem.poolItem.Equals(returningPooledItem));
        pooledObject.isActive = false;
    }
}
