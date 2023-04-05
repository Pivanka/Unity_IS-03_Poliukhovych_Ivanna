using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runAnimationKey;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            _animator.SetBool(_runAnimationKey, true);
        }
        else if(Input.GetButtonUp("Jump"))
        {
            _animator.SetBool(_runAnimationKey, false);
        }
    }
}
