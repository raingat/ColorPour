using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JuiceSpawner : MonoBehaviour
{
    [SerializeField] private List<Juice> _prefabs;
    [SerializeField] private Transform _point;

    private JuicePool _pool;

    private int _countSpawnObject = 0;

    public bool CanSpawn => _countSpawnObject < _pool.CountCreateObject;

    public void Initialize(ConfigurateGame configurate)
    {
        _pool = new JuicePool(_prefabs.ToList(), configurate);
    }

    public Juice Spawn()
    {
        Juice juice = _pool.Get();

        juice.transform.position = _point.position;

        _countSpawnObject++;

        return juice;
    }
}
