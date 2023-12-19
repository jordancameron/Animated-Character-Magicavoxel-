using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    
    public void ChangeAnimFloatValue (string key, float newValue)
    {
        anim.SetFloat(key, newValue);
    }

    public void ChangeAnimBoolValue(string key, bool newValue)
    {
        anim.SetBool(key, newValue);
    }
}
