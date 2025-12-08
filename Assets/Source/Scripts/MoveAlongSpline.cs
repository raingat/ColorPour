using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class MoveAlongSpline : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private SplineContainer _splineContainer;

    private Spline _spline;

    private Coroutine _coroutine;

    private float _splineLength;

    public void SetSplineContainer(SplineContainer splineContainer)
    {
        _splineContainer = splineContainer;

        _spline = _splineContainer.Spline;
        _splineLength = _spline.GetLength();
    }

    public void Move()
    {
        if (_spline != null && _splineContainer != null && _coroutine == null)
            _coroutine = StartCoroutine(MoveAlong());
    }

    private IEnumerator MoveAlong()
    {
        float normalizedLength = 0.0f;
        float distanceTravelled = 0.0f;

        float endPoint = 1.0f;

        while (Mathf.Approximately(normalizedLength, endPoint) == false)
        {
            distanceTravelled += _speed * Time.deltaTime;

            normalizedLength = Mathf.Clamp01(distanceTravelled / _splineLength);

            SplineUtility.Evaluate(_spline, normalizedLength, out float3 position, out float3 tangent, out float3 upVector);

            Vector3 worldPosition = _splineContainer.transform.TransformPoint(position);
            Vector3 worldForward = _splineContainer.transform.TransformDirection(tangent);
            Vector3 worldUp = _splineContainer.transform.TransformDirection(upVector);

            transform.position = Vector3.MoveTowards(transform.position, worldPosition, distanceTravelled);

            transform.rotation = Quaternion.LookRotation(worldUp, worldForward);

            yield return null;
        }

        Debug.Log("End Move!");
    }
}
