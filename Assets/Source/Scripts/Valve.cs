using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(ValveAnimation))]
public class Valve : MonoBehaviour, IActivatable
{
    [SerializeField] private SplineContainer _splineContainer;

    [SerializeField] private LiquidSpawner _liquidSpawner;

    [SerializeField] private float _reloadTime;

    private ValveAnimation _valveAnimation;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private bool IsReloaded = false;

    public event Action<Liquid> Produced;

    public void Initialize()
    {
        _valveAnimation = GetComponent<ValveAnimation>();
        _valveAnimation.Initialize();
        _waitForSeconds = new WaitForSeconds(_reloadTime);
    }

    public void Activate()
    {
        TryTurnOn();
    }

    private void TryTurnOn()
    {
        if (IsReloaded == true)
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(Reload());

            _valveAnimation.PlayAnimationRejection();
        }
        else
        {
            _valveAnimation.PlayAnimationRotate();
            Liquid liquid = _liquidSpawner.Spawn();

            liquid.Move(_splineContainer);

            Produced?.Invoke(liquid);

            IsReloaded = true;
        }
    }

    private IEnumerator Reload()
    {
        yield return _waitForSeconds;

        IsReloaded = false;
        _coroutine = null;
    }
}