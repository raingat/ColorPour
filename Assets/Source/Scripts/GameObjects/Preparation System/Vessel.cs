using System;
using UnityEngine;

public class Vessel : MonoBehaviour, IActivatable
{
    private Juice _captureJuice;

    public bool IsFill => _captureJuice != null;

    public event Action<Vessel, Juice> Dumping;

    public void Activate()
    {
        TryDump();
    }

    public void Fill(Juice liquid)
    {
        _captureJuice = liquid;
        _captureJuice.transform.SetParent(transform);
        _captureJuice.transform.localPosition = Vector3.zero;

        _captureJuice.UpLevel();

        _captureJuice.AchievedMinLevel += Clear;
    }

    private void TryDump()
    {
        if (IsFill == false)
            return;

        if (_captureJuice.MaxLevel == false)
            return;

        _captureJuice.DownLevel();
    }

    private void Clear()
    {
        _captureJuice.AchievedMinLevel -= Clear;

        Juice juice = _captureJuice;
        _captureJuice.DownLevel();
        _captureJuice.transform.SetParent(null);
        _captureJuice = null;

        Dumping?.Invoke(this, juice);
    }
}
