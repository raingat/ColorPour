using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ConsumerSpawn : MonoBehaviour
{
    [SerializeField] private List<Consumer> _prefabs;
    [SerializeField] private List<Transform> _points;

    private ConsumerPool _pool;

    private int _countSpawnObject = 0;

    public bool CanSpawn => _countSpawnObject < _pool.CountCreateObject;

    public Action<Consumer> Created;

    private void Update()
    {
        if (_points.Count == 0)
            return;

        for (int i = 0; i < _points.Count; i++)
        {
            if (CanSpawn)
            {
                Spawn(_points[i]);
                _points.RemoveAt(i);

                break;
            }
        }
    }

    public void Initialize(ConfigurateGame configurate)
    {
        _pool = new ConsumerPool(_prefabs.ToList(), configurate);
    }

    public Consumer Spawn(Transform spawnPoint)
    {
        Consumer consumer = _pool.Get();
        consumer.SetSpawnPoint(spawnPoint);
        consumer.Filled += OnReturn;

        consumer.transform.position = spawnPoint.position;

        _countSpawnObject++;

        Created?.Invoke(consumer);

        return consumer;
    }

    public void OnReturn(Consumer consumer, Transform spawnPoint)
    {
        consumer.Filled -= OnReturn;
        _points.Add(spawnPoint);
    }
}
