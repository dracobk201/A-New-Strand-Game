using UnityEngine;

public class FinishZoneBehaviour : MonoBehaviour
{
    [SerializeField] private GameEvent GameFinished;
    private bool playerInside;

    private void Start()
    {
        playerInside = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            playerInside = false;
    }

    public void ActionTriggered()
    {
        if (playerInside)
            GameFinished.Raise();
    }
}
