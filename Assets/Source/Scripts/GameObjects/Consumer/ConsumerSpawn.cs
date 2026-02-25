using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsumerSpawn : MonoBehaviour
{
    [SerializeField] private List<Consumer> _prefabs;
    [SerializeField] private List<Transform> _points;

    private ConsumerPool _pool;

    private int _countSpawnObject = 0;

    public bool CanSpawn => _countSpawnObject < _pool.CountCreateObject;

    public Action<Consumer> Created;

    public void Initialize(ConfigurateGame configurate)
    {
        _pool = new ConsumerPool(_prefabs.ToList(), configurate);
    }

    public Consumer Spawn()
    {
        Consumer consumer = _pool.Get();
        consumer.Leaved += OnReturn;

        _countSpawnObject++;

        Created?.Invoke(consumer);

        return consumer;
    }

    public void OnReturn(Consumer consumer)
    {
        consumer.Leaved -= OnReturn;
        Destroy(consumer.gameObject);
    }
}
