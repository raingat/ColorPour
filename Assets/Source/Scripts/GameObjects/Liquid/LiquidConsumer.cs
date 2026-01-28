using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Liquid))]
public class LiquidConsumer : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    private Liquid _liquid;

    private float _flowRate = 0.001f;

    public float CurrentLevel => _liquid.planePosition.y;

    public VarietiesColors Color => _color;

    public event Action AchievedMinLevel;

    private void Awake()
    {
        _liquid = GetComponent<Liquid>();
    }

    public void UpLevel(float level)
    {
        StartCoroutine(IncreaseLevel(level));
    }

    public void DownLevel(float level)
    {
        StartCoroutine(DecreaseLevel(level));
    }

    private IEnumerator IncreaseLevel(float level)
    {
        while (_liquid.planePosition.y < level)
        {
            _liquid.planePosition += Vector3.up * _flowRate;

            yield return null;
        }
    }

    private IEnumerator DecreaseLevel(float level)
    {
        while (_liquid.planePosition.y > level)
        {
            _liquid.planePosition -= Vector3.up * _flowRate;

            yield return null;
        }

        AchievedMinLevel?.Invoke();
    }
}