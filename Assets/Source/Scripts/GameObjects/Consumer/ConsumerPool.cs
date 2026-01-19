using System.Collections.Generic;
using UnityEngine;

public class ConsumerPool
{
    private Queue<Consumer> _pool = new Queue<Consumer>();

    private int _countCreateObject = 0;

    public int CountCreateObject => _countCreateObject;

    public ConsumerPool(List<Consumer> prefabs, ConfigurateGame configurate)
    {
        Create(prefabs, configurate);
    }

    public Consumer Get()
    {
        Consumer consumer = _pool.Dequeue();
        consumer.gameObject.SetActive(true);

        return consumer;
    }

    private void Create(List<Consumer> prefabs, ConfigurateGame configurate)
    {
        for (int i = 0; i < configurate.CountObject; i++)
        {
            VarietiesColors color = configurate.GetColorName(i);

            for (int j = 0; j < prefabs.Count; j++)
            {
                if (prefabs[j].Color == color)
                {
                    Consumer consumer = Object.Instantiate(prefabs[j]);
                    consumer.gameObject.SetActive(false);

                    _pool.Enqueue(consumer);

                    _countCreateObject++;

                    break;
                }
            }
        }
    }
}
