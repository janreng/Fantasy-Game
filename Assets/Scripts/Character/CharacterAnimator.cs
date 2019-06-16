using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void PlayAnimAttack()
    {
        animator.SetBool("isAttack", true);
    }

    public void StopAnimAttack()
    {
        Debug.Log("Stop Animation");
        animator.SetBool("isAttack", false);
    }

    public void PlayAnimWalk(float speed)
    {
        animator.SetFloat("speed", speed);
    }
}
