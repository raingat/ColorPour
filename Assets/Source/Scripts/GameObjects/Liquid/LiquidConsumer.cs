using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Liquid))]
public class LiquidConsumer : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    private Liquid _liquid;

    private float _minLevel = -0.75f;
    private float _maxLevel = 0.3f;
    private float _flowRate = 0.001f;

    public bool MaxLevel => _liquid.planePosition.y >= _maxLevel;

    public VarietiesColors Color => _color;

    public event Action AchievedMinLevel;

    private void Awake()
    {
        _liquid = GetComponent<Liquid>();
    }

    public void ResetLevel()
    {
        _liquid.planePosition = new Vector3(0.0f, _minLevel, 0.0f);
    }

    public void UpLevel()
    {
        StartCoroutine(IncreaseLevel());
    }

    public void DownLevel()
    {
        StartCoroutine(DecreaseLevel());
    }

    private IEnumerator IncreaseLevel()
    {
        while (_liquid.planePosition.y < _maxLevel)
        {
            _liquid.planePosition += Vector3.up * _flowRate;

            yield return null;
        }
    }

    private IEnumerator DecreaseLevel()
    {
        while (_liquid.planePosition.y > _minLevel)
        {
            _liquid.planePosition -= Vector3.up * _flowRate;

            yield return null;
        }

        AchievedMinLevel?.Invoke();
    }
}