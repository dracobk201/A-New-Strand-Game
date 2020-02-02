using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHandler : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    public void SetRightWalking()
    {
        Vector3 scale = transform.localScale;
        scale.x = 0.2f;
        transform.localScale = scale;
        playerAnimator.SetTrigger(Global.MINERGUYWALKING);
    }

    public void SetLeftWalking()
    {
        Vector3 scale = transform.localScale;
        scale.x = -0.2f;
        transform.localScale = scale;
        playerAnimator.SetTrigger(Global.MINERGUYWALKING);
    }

    public void SetClimbing()
    {
        playerAnimator.SetTrigger(Global.MINERGUYCLIMBING);
    }

    public void SetRepair()
    {
        playerAnimator.SetTrigger(Global.MINERGUYREPAIR);
    }

    public void SetIdle()
    {
        playerAnimator.SetTrigger(Global.MINERGUYIDLE);
    }
}
