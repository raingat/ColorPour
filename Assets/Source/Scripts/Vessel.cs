using System;
using UnityEngine;

public class Vessel : MonoBehaviour, IActivatable
{
    private Liquid _captureLiquid;

    public bool IsFill => _captureLiquid != null;

    public event Action<Vessel, Liquid> Dumping;

    public void Activate()
    {
        TryDump();
    }

    public void Fill(Liquid liquid)
    {
        _captureLiquid = liquid;
    }

    private void TryDump()
    {
        if (IsFill)
        {
            Dumping?.Invoke(this, _captureLiquid);
            _captureLiquid = null;
        }
    }
}
