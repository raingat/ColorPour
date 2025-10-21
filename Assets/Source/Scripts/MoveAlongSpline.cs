using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class MoveAlongSpline : MonoBehaviour
{
    [SerializeField] private SplineContainer _splineContainer;
    [SerializeField] private float _speed = 2f;

    private Spline _spline;

    private float _distanceTravelled;
    private float _splineLength;

    private void Start()
    {
        _distanceTravelled = 0.0f;
        _spline = _splineContainer.Spline;
        _splineLength = _spline.GetLength();
    }

    private void Move()
    {
        StartCoroutine(MoveAlong());
    }

    private IEnumerator MoveAlong()
    {
        float normalizedLength = 0.0f;

        while (Mathf.Approximately(normalizedLength, 1.0f) == false)
        {
            _distanceTravelled += _speed * Time.deltaTime;

            normalizedLength = Mathf.Clamp01(_distanceTravelled / _splineLength);

            SplineUtility.Evaluate(_spline, normalizedLength, out float3 position, out float3 tangent, out float3 upVector);

            Vector3 worldPosition = _splineContainer.transform.TransformPoint(position);
            Vector3 worldForward = _splineContainer.transform.TransformDirection(tangent);
            Vector3 worldUp = _splineContainer.transform.TransformDirection(upVector);

            transform.position = Vector3.MoveTowards(transform.position, worldPosition, _distanceTravelled);

            transform.rotation = Quaternion.LookRotation(worldUp, worldForward);

            yield return null;
        }

        Debug.Log("Движение окончено!");
    }
}
