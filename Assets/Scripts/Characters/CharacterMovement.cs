using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("CheckForInput", 0, 0.1f);
    }

    public void Movement(Vector2 moveDir)
    {
        GetComponentInChildren<CharacterAnims>().WalkingAnim();
        moveDir = moveDir.normalized * moveSpeed;
        rb.MovePosition(rb.position + moveDir * Time.deltaTime);
    }

    void CheckForInput()
    {
        if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            GetComponentInChildren<CharacterAnims>().IdleAnim();
        }
    }
}
