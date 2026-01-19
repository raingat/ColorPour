using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Configurate Settings")]
    [SerializeField] private ConfigurateGame _configurate;

    [Header("LiquidSpawner Settings")]
    [SerializeField] private LiquidSpawner _liquidSpawner;

    [Header("ConsumerSpawner Settings")]
    [SerializeField] private ConsumerSpawn _consumerSpawner;

    [Header("Valve Settings")]
    [SerializeField] private Valve _valve;

    [Header("VesselDistributor Settings")]
    [SerializeField] private VesselDistributor _vesselDistributor;

    [Header("Container Settings")]
    [SerializeField] private Container _container;

    [Header("Dispenser Settings")]
    [SerializeField] private Dispenser _dispenser;

    private void Awake()
    {
        _liquidSpawner.Initialize(_configurate);
        _consumerSpawner.Initialize(_configurate);
        _dispenser.Initialize(_consumerSpawner);
        _valve.Initialize(_liquidSpawner, _vesselDistributor);

        InitializeContainer();
    }

    private void InitializeContainer()
    {
        List<Color> colors = new List<Color>();

        for (int i = 0; i < _configurate.CountObject; i++)
            colors.Add(_configurate.GetColor(i));

        _container.Initialize(colors, _valve);
    }
}
