using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private List<Indicator> _indicators;

    public int CountIndicators => _indicators.Count;

    public void Initialize(List<Color> firstColors)
    {
        for (int i = 0; i < _indicators.Count; i++)
        {
            _indicators[i].Initialize();
            _indicators[i].ChangeColor(firstColors[i]);
        }
    }
}
