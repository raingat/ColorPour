using System.Collections.Generic;
using UnityEngine;

public class LiquidPool
{
    private Queue<Liquid> _pool = new Queue<Liquid>();

    public LiquidPool(List<Liquid> prefabs, ConfigurateGame configurate)
    {
        Create(prefabs, configurate);
    }

    public Liquid Get()
    {
        Liquid liquid = _pool.Dequeue();
        liquid.gameObject.SetActive(true);

        return liquid;
    }

    private void Create(List<Liquid> prefabs, ConfigurateGame configurate)
    {
        for (int i = 0; i < configurate.CountObject; i++)
        {
            VarietiesColors color = configurate.GetColorName(i);

            for (int j = 0; j < prefabs.Count; j++)
            {
                if (prefabs[j].Color == color)
                {
                    Liquid liquid = Object.Instantiate(prefabs[j]);
                    liquid.gameObject.SetActive(false);

                    _pool.Enqueue(liquid);

                    break;
                }
            }
        }
    }
}
