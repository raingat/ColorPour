using System;
using UnityEngine;

public class Vessel : MonoBehaviour, IActivatable
{
    private LiquidConsumer _captureLiquid;

    private float _minLevel = -0.75f;
    private float _maxLevel = 0.3f;

    public bool IsFill => _captureLiquid != null;

    public event Action<Vessel, LiquidConsumer> Dumping;

    public void Activate()
    {
        TryDump();
    }

    public void Fill(LiquidConsumer liquid)
    {
        _captureLiquid = liquid;
        _captureLiquid.transform.SetParent(transform);
        _captureLiquid.transform.localPosition = Vector3.zero;

        _captureLiquid.UpLevel(_maxLevel);

        _captureLiquid.AchievedMinLevel += Clear;
    }

    private void TryDump()
    {
        if (IsFill == false)
            return;

        if (_captureLiquid.CurrentLevel < _maxLevel)
            return;

        _captureLiquid.DownLevel(_minLevel);
    }

    private void Clear()
    {
        _captureLiquid.AchievedMinLevel -= Clear;

        LiquidConsumer liquid = _captureLiquid;
        _captureLiquid.DownLevel(_minLevel);
        _captureLiquid.transform.SetParent(null);
        _captureLiquid = null;

        Dumping?.Invoke(this, liquid);
    }
}
