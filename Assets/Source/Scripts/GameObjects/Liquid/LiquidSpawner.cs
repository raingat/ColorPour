using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField] private List<Liquid> _prefabs;
    [SerializeField] private Transform _point;

    private LiquidPool _pool;

    public void Initialize(ConfigurateGame configurate)
    {
        _pool = new LiquidPool(_prefabs.ToList(), configurate);
    }

    public Liquid Spawn()
    {
        Liquid liquid = _pool.Get();

        liquid.transform.position = _point.position;

        return liquid;
    }
}
