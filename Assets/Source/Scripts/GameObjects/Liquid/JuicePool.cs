using System.Collections.Generic;
using UnityEngine;

public class JuicePool
{
    private Queue<Juice> _pool = new Queue<Juice>();

    private int _countCreateObject = 0;

    public int CountCreateObject => _countCreateObject;

    public JuicePool(List<Juice> prefabs, ConfigurateGame configurate)
    {
        Create(prefabs, configurate);
    }

    public Juice Get()
    {
        Juice juice = _pool.Dequeue();
        juice.gameObject.SetActive(true);

        return juice;
    }

    private void Create(List<Juice> prefabs, ConfigurateGame configurate)
    {
        for (int i = 0; i < configurate.CountObject; i++)
        {
            VarietiesColors color = configurate.GetColorName(i);

            for (int j = 0; j < prefabs.Count; j++)
            {
                if (prefabs[j].Color == color)
                {
                    Juice juice = Object.Instantiate(prefabs[j]);
                    juice.gameObject.SetActive(false);

                    _pool.Enqueue(juice);

                    _countCreateObject++;

                    break;
                }
            }
        }
    }
}
