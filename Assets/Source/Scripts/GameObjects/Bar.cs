using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private List<BarPlace> _places;

    private ConsumerSpawn _consumerSpawn;

    public void Initialize(ConsumerSpawn consumerSpawn)
    {
        _consumerSpawn = consumerSpawn;
        TakeStartPlaces();

        foreach (BarPlace barPlace in _places)
        {
            barPlace.SeatsFree += InviteConsumer;
        }
    }

    public void TakeStartPlaces()
    {
        foreach (BarPlace barPlace in _places)
        {
            InviteConsumer(barPlace);
        }
    }

    public void InviteConsumer(BarPlace barPlace)
    {
        if (_consumerSpawn.CanSpawn == false)
            return;

        Consumer consumer = _consumerSpawn.Spawn();
        consumer.TakePlace(barPlace);

        barPlace.AcceptConsumer(consumer);
    }

    public List<VarietiesColors> GetAllRequirementJuiceColor()
    {
        List<VarietiesColors> requirementColors = new List<VarietiesColors>();

        foreach (BarPlace barPlace in _places)
        {
            if (barPlace.HasBottle == false)
                continue;

            requirementColors.Add(barPlace.GetRequirementColor());
        }

        return requirementColors;
    }

    public void TakeJuices(List<Juice> juices)
    {
        foreach (Juice juice in juices)
        {
            foreach (BarPlace place in _places)
            {
                if (place.HasBottle == false)
                {
                    break;
                }

                if (juice.Color == place.GetRequirementColor())
                {
                    place.TrySetJuice(juice);
                    break;
                }
            }
        }
    }
}
