using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Key : CharacterStatModifierSO
{

    public override void AffectCharacter(GameObject character, float val)
    {
        character = GameObject.FindWithTag("rule");
        gamerules gamerules = character.GetComponent<gamerules>();
        gamerules.keyget = true;
    }
}