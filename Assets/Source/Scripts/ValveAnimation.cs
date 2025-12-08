using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class ValveAnimation: MonoBehaviour
{
    private static readonly int Rotating = Animator.StringToHash(nameof(Rotating));
    private static readonly int Rejecting = Animator.StringToHash(nameof(Rejecting));

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationRotate()
    {
        _animator.SetTrigger(Rotating);
    }

    public void PlayAnimationRejection()
    {
        _animator.SetTrigger(Rejecting);
    }
}