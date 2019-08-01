using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRarity : MonoBehaviour
{
    [SerializeField] private Rarities rarity = null;
    [SerializeField] private SpriteRenderer spr = null;
    void Update() => RaritySet(rarity);

    void RaritySet(Rarities _rarity) => spr.color = _rarity.Colour;
}
