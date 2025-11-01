using System.Collections.Generic;
using UnityEngine;

public class LiquidPool
{
    private Liquid _prefab;

    private Queue<Liquid> _pool = new Queue<Liquid>();

    public LiquidPool(Liquid prefab, int initialCount)
    {
        _prefab = prefab;

        for (int i = 0; i < initialCount; i++)
        {
            Create();
        }
    }

    public Liquid Get()
    {
        if (_pool.Count == 0)
            Create();

        Liquid liquid = _pool.Dequeue();
        liquid.gameObject.SetActive(true);

        return liquid;
    }

    private void Create()
    {
        Liquid liquid = Object.Instantiate(_prefab);
        liquid.gameObject.SetActive(false);

        _pool.Enqueue(liquid);
    }
}
