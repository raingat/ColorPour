using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Configurate Settings")]
    [SerializeField] private ConfigurateGame _configurate;

    [Header("LiquidSpawner Settings")]
    [SerializeField] private LiquidSpawner _liquidSpawner;

    [Header("Valve Settings")]
    [SerializeField] private Valve _valve;

    [Header("VesselDistributor Settings")]
    [SerializeField] private VesselDistributor _vesselDistributor;

    [Header("Container Settings")]
    [SerializeField] private Container _container;

    private void Awake()
    {
        _liquidSpawner.Initialize(_configurate);
        _valve.Initialize(_liquidSpawner, _vesselDistributor);

        InitializeContainer();
    }

    private void InitializeContainer()
    {
        List<Color> firstColors = new List<Color>();

        for (int i = 0; i < _container.CountIndicators; i++)
            firstColors.Add(_configurate.GetColor(i));

        _container.Initialize(firstColors);
    }
}
