using System;
using UnityEngine;

public class Vessel : MonoBehaviour, IActivatable
{
    private LiquidConsumer _captureLiquid;

    public bool IsFill => _captureLiquid != null;

    public event Action<Vessel, LiquidConsumer> Dumping;

    public void Activate()
    {
        TryDump();
    }

    public void Fill(LiquidConsumer liquid)
    {
        _captureLiquid = liquid;
    }

    private void TryDump()
    {
        if (IsFill == false)
            return;

        LiquidConsumer liquid = _captureLiquid;
        _captureLiquid = null;

        Dumping?.Invoke(this, liquid);
    }
}
