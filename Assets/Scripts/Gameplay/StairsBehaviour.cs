using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsBehaviour : MonoBehaviour
{
    [SerializeField]
    private BoolReference PlayerInStairs;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            PlayerInStairs.Value = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            PlayerInStairs.Value = false;
    }
}
