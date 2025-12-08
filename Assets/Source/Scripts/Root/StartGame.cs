using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("LiquidSpawner Settings")]
    [SerializeField] private LiquidSpawner _liquidSpawner;
    [SerializeField] private int _liquidStartCount;

    [Header("Valve Settings")]
    [SerializeField] private Valve _valve;

    [Header("VesselDistributor Settings")]
    [SerializeField] private VesselDistributor _vesselDistributor;

    private void Awake()
    {
        _liquidSpawner.Initialize(_liquidStartCount);
        _valve.Initialize();
        _vesselDistributor.Initialize(_valve);
    }
}
