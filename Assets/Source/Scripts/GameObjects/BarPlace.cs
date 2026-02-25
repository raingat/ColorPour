using System;
using UnityEngine;

public class BarPlace : MonoBehaviour
{
    [SerializeField] private Crane _crane;
    [SerializeField] private Transform _bottlePlace;

    private Consumer _consumer;
    private Bottle _bottle;

    private Juice _juice;

    public bool HasBottle => _bottle != null;

    public Action<BarPlace> SeatsFree;

    public void AcceptConsumer(Consumer consumer)
    {
        _consumer = consumer;
    }

    public void SetBottle(Bottle bottle)
    {
        _bottle = bottle;
        _bottle.transform.position = _bottlePlace.position;

        _bottle.Filled += ReturnToConsumer;
    }

    public VarietiesColors GetRequirementColor()
    {
        return _bottle.RequirementColor;
    }

    public void TrySetJuice(Juice juice)
    {
        if (_bottle.RequirementColor != juice.Color)
            return;

        _juice = juice;
        Service();
    }

    private void Service()
    {
        _crane.Open();
        _bottle.Fill(_juice);

        _juice = null;
    }

    private void ReturnToConsumer()
    {
        _bottle.Filled -= ReturnToConsumer;

        _consumer.ReturnBottle(_bottle);

        _consumer = null;
        _bottle = null;

        SeatsFree?.Invoke(this);
    }
}
