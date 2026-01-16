using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private List<Indicator> _indicators;

    [SerializeField] private List<Color> _colors;

    private Valve _valve;

    private int _colorIndex = 0;

    private void OnDisable()
    {
        _valve.Activated -= OnChangeIndicator;
    }

    public void Initialize(List<Color> colors, Valve valve)
    {
        _valve = valve;
        _valve.Activated += OnChangeIndicator;

        _colors = colors;

        InitializeIndicator();
        ChangeIndicatorColor();
    }

    private void OnChangeIndicator()
    {
        ChangeIndicatorColor();
    }

    private void ChangeIndicatorColor()
    {
        Color currentColor;

        int lastIndexColors = _colors.Count - 1;
        int currentColorIndex = 0;

        for (int i = 0; i < _indicators.Count; i++)
        {
            currentColorIndex = i + _colorIndex;

            if (currentColorIndex > lastIndexColors)
                currentColor = Color.black;
            else
                currentColor = _colors[currentColorIndex];

            _indicators[i].ChangeColor(currentColor);
        }

        _colorIndex++;
    }

    private void InitializeIndicator()
    {
        foreach (Indicator indicator in _indicators)
            indicator.Initialize();
    }
}
