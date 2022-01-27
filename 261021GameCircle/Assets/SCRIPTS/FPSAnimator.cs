using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAnimator : MonoBehaviour
{
    public Animator _FPSAnimator;

    public void FPSPlayerAnimationSetBool(string boolParameter, bool ToF)
    {
        _FPSAnimator.SetBool(boolParameter, ToF);
    }
    public void FPSPlayerAnimationSetTrigger(string triggerParameter)
    {
        _FPSAnimator.SetTrigger(triggerParameter);
    }
}
