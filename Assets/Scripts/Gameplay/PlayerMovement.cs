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
        float newY = VerticalAxis.Value * MoveSpeed.Value * Time.deltaTime;
        playerRigidbody2D.position = new Vector2(oldPosition.x + newX, oldPosition.y + newY);
    }
}
