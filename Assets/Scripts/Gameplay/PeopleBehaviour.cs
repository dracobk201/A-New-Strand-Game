using System.Collections;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{
    #region People Variables
    [Header("People Variables")]
    [SerializeField] private Rigidbody2D personRigidbody;
    [SerializeField] private FloatReference PersonVelocity;
    [SerializeField] private FloatReference PersonTimeOfLife;
    private Vector3 direction;
    private Vector3 scale;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(AutoDestruction());
        direction = Vector3.right;
    }

    private void Update()
    {
        transform.position += direction * PersonVelocity.Value * Time.deltaTime;    
    }

    private void Destroy()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(PersonTimeOfLife.Value);
        Destroy();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag(Global.BLOCKERTAG))
        {
            if (direction == Vector3.right)
                direction *=-1;
            else
                direction = Vector3.right;
                
            scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }
}
