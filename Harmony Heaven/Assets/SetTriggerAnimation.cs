using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(string animName)
    {
        Debug.Log("SetAnim");
        animator.SetTrigger(animName);
    }
}
