using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private ParticleSystem _waterFlow;

    public void Open()
    {
        _waterFlow.Play();
    }
}
