using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    [SerializeField] private List<Liquid> _liquids;

    public bool IsFull => _liquids.Count >= _maxSize;

    public void AcceptLiquid(Liquid liquid)
    {
        _liquids.Add(liquid);
    }
}
