using System.Collections.Generic;
using UnityEngine;

public class VesselDistributor : MonoBehaviour
{
    [SerializeField] private List<Vessel> _vessels;
    [SerializeField] private Dispenser _dispenser;

    public void OnEnable()
    {
        foreach (Vessel vessel in _vessels)
            vessel.Dumping += TryTransportLiquid;
    }

    private void OnDisable()
    {
        foreach (Vessel vessel in _vessels)
            vessel.Dumping -= TryTransportLiquid;
    }

    public bool CanAcceptLiquid()
    {
        bool result = false;

        foreach (Vessel vessel in _vessels)
        {
            if (vessel.IsFill == false)
            {
                result = true;
                break;
            }
        }

        return result;
    }

    public void AcceptLiquid(Juice liquid)
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

    public bool CanTransportLiquid()
    {
        return _dispenser.IsFull;
    }

    private void TryTransportLiquid(Vessel vessel, Juice liquid)
    {
        if (_dispenser.IsFull)
        {
            vessel.Fill(liquid);
            return;
        }

        _dispenser.AcceptLiquid(liquid);
    }
}
