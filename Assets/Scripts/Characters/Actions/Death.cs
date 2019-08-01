using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject hitbox;

    public void DeathEvent()
    {
        GetComponentInChildren<BaseAnims>().DeathAnim();
        hitbox.SetActive(false);
        GetComponent<FadeSpriteGroup>().FadeOut();
    }
}
