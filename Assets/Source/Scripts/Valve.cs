using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ValveAnimation))]
public class Valve : MonoBehaviour, IActivatable
{
    [SerializeField] private float _reloadTime;

    private LiquidSpawner _liquidSpawner;
    private VesselDistributor _vesselDistributor;

    private ValveAnimation _valveAnimation;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    private bool IsReloaded = false;

    public void Initialize(LiquidSpawner liquidSpawner, VesselDistributor vesselDistributor)
    {
        _liquidSpawner = liquidSpawner;
        _vesselDistributor = vesselDistributor;

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
        if (IsReloaded == false && _vesselDistributor.CanAcceptLiquid())
        {
            _valveAnimation.PlayAnimationRotate();
            Liquid liquid = _liquidSpawner.Spawn();

            _vesselDistributor.AcceptLiquid(liquid);

            IsReloaded = true;
        }
        else
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(Reload());

            _valveAnimation.PlayAnimationRejection();
        }
    }

    private IEnumerator Reload()
    {
        yield return _waitForSeconds;

        IsReloaded = false;
        _coroutine = null;
    }
}