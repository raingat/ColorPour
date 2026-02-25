using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Liquid))]
public class Juice : MonoBehaviour
{
    [SerializeField] private VarietiesColors _color;

    private Liquid _juice;

    private float _minLevel = -0.75f;
    private float _maxLevel = 0.3f;
    private float _flowRate = 0.001f;

    public bool MaxLevel => _juice.planePosition.y >= _maxLevel;

    public VarietiesColors Color => _color;

    public event Action AchievedMinLevel;

    private void Awake()
    {
        _juice = GetComponent<Liquid>();
    }

    public void ResetLevel()
    {
        _juice.planePosition = new Vector3(0.0f, _minLevel, 0.0f);
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
        while (_juice.planePosition.y < _maxLevel)
        {
            _juice.planePosition += Vector3.up * _flowRate;

            yield return null;
        }
    }

    private IEnumerator DecreaseLevel()
    {
        while (_juice.planePosition.y > _minLevel)
        {
            _juice.planePosition -= Vector3.up * _flowRate;

            yield return null;
        }

        AchievedMinLevel?.Invoke();
    }
}