using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    private LiquidConsumer _liquid;

    private Transform _place;

    public VarietiesColors Color => _color;

    public Action<Consumer, Transform> Filled;

    private void Update()
    {
        if (_liquid != null)
        {
            Transform place = _place;
            _place = null;

            Filled?.Invoke(this, place);

            transform.position += new Vector3(0.0f, 1.0f, 0.0f);

            Destroy(_liquid.gameObject);
            Destroy(gameObject, 2.0f);
        }
    }

    public void SetSpawnPoint(Transform place)
    {
        _place = place;
    }

    public void SetLiquid(LiquidConsumer liquid)
    {
        _liquid = liquid;
    }
}
