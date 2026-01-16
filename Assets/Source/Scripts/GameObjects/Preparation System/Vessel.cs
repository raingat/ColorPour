using System;
using UnityEngine;

[RequireComponent(typeof(VesselRendering))]
public class Vessel : MonoBehaviour, IActivatable
{
    private VesselRendering _rendering;

    private Liquid _captureLiquid;

    public bool IsFill => _captureLiquid != null;

    public event Action<Vessel, Liquid> Dumping;

    private void Awake()
    {
        _rendering = GetComponent<VesselRendering>();
    }

    public void Activate()
    {
        TryDump();
    }

    public void Fill(Liquid liquid)
    {
        _captureLiquid = liquid;
        _rendering.SetFillColor();
    }

    private void TryDump()
    {
        if (IsFill)
        {
            Dumping?.Invoke(this, _captureLiquid);
            _captureLiquid = null;

            _rendering.DisableColor();
        }
    }
}
