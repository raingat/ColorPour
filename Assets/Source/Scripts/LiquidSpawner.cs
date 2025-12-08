using UnityEngine;

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
        liquid.Initialize();

        liquid.transform.position = _point.position;

        return liquid;
    }
}
