using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Indicator : MonoBehaviour
{
    private Renderer _renderer;

    public void Initialize()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}
