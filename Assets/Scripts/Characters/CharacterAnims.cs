using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnims : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        anim.SetBool("isWalking", false);
    }

    public void WalkingAnim()
    {
        anim.SetBool("isWalking", true);
    }
}
