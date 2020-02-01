using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private FloatReference HorizontalAxis;
    [SerializeField]
    private FloatReference VerticalAxis;
    [SerializeField]
    private FloatReference MoveSpeed;
    [SerializeField]
    private BoolReference PlayerInStairs;
    private Rigidbody2D playerRigidbody2D;

    private void Awake()
    {
        if(TryGetComponent(out Rigidbody2D result))
            playerRigidbody2D = result;
    }
    
    public void Move()
    {
        Vector2 oldPosition = playerRigidbody2D.position;
        float newX = HorizontalAxis.Value * MoveSpeed.Value * Time.deltaTime;
        float newY;
        if (PlayerInStairs.Value)
        {
            newY = VerticalAxis.Value * MoveSpeed.Value * Time.deltaTime;
            playerRigidbody2D.gravityScale = 0;
        }
        else
        {
            newY = 0;
            playerRigidbody2D.gravityScale = 1;
        }
        playerRigidbody2D.position = new Vector2(oldPosition.x + newX, oldPosition.y + newY);
    }
}
