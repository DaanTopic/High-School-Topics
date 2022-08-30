using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        //�[��
        ThirdPersonShooterController thirdPersonShooterController = character.GetComponent<ThirdPersonShooterController>();
        thirdPersonShooterController.AmmoCountTextLabel.text = val.ToString();
            
    }
}
