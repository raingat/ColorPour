using System;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    private List<Juice> _juices = new List<Juice>();

    public bool IsFull => _juices.Count >= _maxSize;
    public bool HaveJuice => _juices.Count > 0;

    public Action JuiceCome;

    public void AcceptLiquid(Juice juice)
    {
        _juices.Add(juice);

        JuiceCome?.Invoke();
    }

    public List<VarietiesColors> GetAllAvailableColors()
    {
        List<VarietiesColors> availableColors = new List<VarietiesColors>();

        foreach (Juice juice in _juices)
            availableColors.Add(juice.Color);

        return availableColors;
    }

    public List<Juice> GetJuice(List<VarietiesColors> requirementColors)
    {
        List<Juice> requirementJuices = new List<Juice>();

        for (int i = 0; i < requirementColors.Count; i++)
        {
            VarietiesColors color = requirementColors[i];

            int index = _juices.FindIndex(j => j.Color == color);

            if (index != -1)
            {
                Juice juice = _juices[index];

                requirementJuices.Add(juice);
                _juices.RemoveAt(index);
            }
        }

        return requirementJuices;
    }
}
