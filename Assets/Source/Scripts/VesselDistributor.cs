using System.Collections.Generic;
using UnityEngine;

public class VesselDistributor : MonoBehaviour
{
    [SerializeField] private List<Vessel> _vessels;
    [SerializeField] private Dispenser _dispenser;

    private Valve _valve;

    private void OnDisable()
    {
        _valve.Produced -= AcceptLiquid;

        foreach (Vessel vessel in _vessels)
        {
            vessel.Dumping -= TryTransportLiquid;
        }
    }

    public void Initialize(Valve valve)
    {
        _valve = valve;
        _valve.Produced += AcceptLiquid;

        foreach (Vessel vessel in _vessels)
        {
            vessel.Dumping += TryTransportLiquid;
        }
    }

    private void AcceptLiquid(Liquid liquid)
    {
        foreach (Vessel vessel in _vessels)
        {
            if (vessel.IsFill == false)
            {
                vessel.Fill(liquid);
                break;
            }
        }
    }

    private void TryTransportLiquid(Vessel vessel, Liquid liquid)
    {
        if (_dispenser.IsFull == false)
            _dispenser.TryAcceptLiquid(liquid);
        else
            vessel.Fill(liquid);
    }
}
