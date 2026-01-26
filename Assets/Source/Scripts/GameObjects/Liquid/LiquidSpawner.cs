using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField] private List<LiquidConsumer> _prefabs;
    [SerializeField] private Transform _point;

    private LiquidPool _pool;

    private int _countSpawnObject = 0;

    public bool CanSpawn => _countSpawnObject < _pool.CountCreateObject;

    public void Initialize(ConfigurateGame configurate)
    {
        _pool = new LiquidPool(_prefabs.ToList(), configurate);
    }

    public LiquidConsumer Spawn()
    {
        LiquidConsumer liquid = _pool.Get();

        liquid.transform.position = _point.position;

        _countSpawnObject++;

        return liquid;
    }
}
