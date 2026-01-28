using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    [SerializeField] private Vector3 _scaleLiquid;
    
    private LiquidConsumer _liquid;
    private Transform _place;

    public VarietiesColors Color => _color;

    public Action<Consumer, Transform> Filled;

    private void Update()
    {
        if (_liquid != null && _liquid.MaxLevel)
        {
            Transform place = _place;
            _place = null;

            Filled?.Invoke(this, place);

            Destroy(gameObject);
        }
    }

    public void SetSpawnPoint(Transform place)
    {
        _place = place;
    }

    public void SetLiquid(LiquidConsumer liquid)
    {
        _liquid = liquid;
        _liquid.transform.SetParent(transform);
        _liquid.transform.localPosition = Vector3.zero;
        _liquid.transform.localScale = _scaleLiquid;

        _liquid.UpLevel();
    }
}
