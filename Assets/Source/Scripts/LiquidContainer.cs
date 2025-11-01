using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidContainer : MonoBehaviour
{
    [SerializeField] private LiquidSpawner _spawner;

    private Queue<Liquid> _liquids = new Queue<Liquid>();

    public void Initialize(int initialCount)
    {
        Fill(initialCount);
        Move();
    }

    private void Fill(int initialCount)
    {
        for(int i = 0; i < initialCount; i++)
            _liquids.Enqueue(_spawner.Spawn());
    }

    private void Move()
    {
        foreach(Liquid liquid in _liquids)
        {

        }
    }
}
