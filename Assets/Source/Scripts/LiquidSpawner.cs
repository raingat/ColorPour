using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField] private Liquid _prefab;
    [SerializeField] private Transform _point;

    private int _initialCount;

    private LiquidPool _pool;

    public void Initialize(int initialCount)
    {
        _initialCount = initialCount;
        _pool = new LiquidPool(_prefab, _initialCount);
    }

    public Liquid Spawn()
    {
        Liquid liquid = _pool.Get();

        Handle(liquid);

        return liquid;
    }

    private void Handle(Liquid liquid)
    {
        liquid.transform.position = _point.position;
    }
}
