using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VesselRendering : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetFillColor()
    {
        _renderer.material.color = Color.green;
    }

    public void DisableColor()
    {
        _renderer.material.color = Color.red;
    }
}
