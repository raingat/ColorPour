using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    private List<Liquid> _liquids = new();

    public bool IsFull => _liquids.Count >= _maxSize;

    public void TryAcceptLiquid(Liquid liquid)
    {
        _liquids.Add(liquid);
    }
}
