using System.Collections.Generic;
using UnityEngine;

public class VesselDistributor : MonoBehaviour
{
    [SerializeField] private List<Vessel> _vessels;
    [SerializeField] private Dispenser _dispenser;
    
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

    public void AcceptLiquid(Liquid liquid)
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

    public void TryTransportLiquid(Vessel vessel, Liquid liquid)
    {
        if (_dispenser.IsFull == false)
            _dispenser.TryAcceptLiquid(liquid);
        else
            vessel.Fill(liquid);
    }
}
