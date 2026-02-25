using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    [SerializeField] private VarietiesColors _requirementColor;

    [SerializeField] private Bottle _bottle;

    [SerializeField] private Vector3 _scaleLiquid;

    public VarietiesColors Color => _requirementColor;

    public Action<Consumer> Leaved;

    private void Awake()
    {
        _bottle.Initialize(_requirementColor);
    }

    public void TakePlace(BarPlace barPlace)
    {
        barPlace.SetBottle(_bottle);
        _bottle = null;
    }

    public void ReturnBottle(Bottle bottle)
    {
        _bottle = bottle;
        Destroy(_bottle.gameObject);
        Leave();
    }

    private void Leave()
    {
        Leaved?.Invoke(this);
    }
}
