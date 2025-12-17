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

    private void Awake()
    {
        _liquidSpawner.Initialize(_configurate);
        _valve.Initialize();
        _vesselDistributor.Initialize(_valve);
    }
}
