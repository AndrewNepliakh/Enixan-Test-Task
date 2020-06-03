using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Queue<IPoolable> _pool;

    public void InitPool(Transform parent, int size = 0)
    {
        transform.SetParent(parent);
        _pool = new Queue<IPoolable>(size);
    }

    public T Spawn<T>(GameObject prefab) where T : MonoBehaviour, IPoolable
    {
        var go = Instantiate(prefab);
        var script = go.AddComponent<T>();
        return script;
    }

    public void Activate()
    {
      
    }

    public void Deactivate<T>(T obj) where T : MonoBehaviour, IPoolable
    {
        obj.transform.SetParent(transform);
        _pool.Enqueue(obj);
        obj.OnDeactivate();
    }
}
