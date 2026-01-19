using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    [SerializeField] private List<Liquid> _liquids;
    [SerializeField] private List<Consumer> _consumers;

    private ConsumerSpawn _consumerSpawn;

    public bool IsFull => _liquids.Count >= _maxSize;

    private void Update()
    {
        if (_consumers.Count == 0 || _liquids.Count == 0)
            return;

        for (int i = 0; i < _liquids.Count; i++)
        {
            for (int j = 0; j < _consumers.Count; j++)
            {
                if (_liquids[i].Color == _consumers[j].Color)
                {
                    _consumers[j].SetLiquid(_liquids[i]);
                    _liquids.RemoveAt(i);
                    _consumers.RemoveAt(j);

                    break;
                }
            }
        }
    }

    private void OnDisable()
    {
        _consumerSpawn.Created -= SetConsumer;
    }

    public void Initialize(ConsumerSpawn consumerSpawn)
    {
        _consumerSpawn = consumerSpawn;
        _consumerSpawn.Created += SetConsumer;
    }

    public void AcceptLiquid(Liquid liquid)
    {
        _liquids.Add(liquid);
    }

    public void SetConsumer(Consumer consumer)
    {
        _consumers.Add(consumer);
    }
}
