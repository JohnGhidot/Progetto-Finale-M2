using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackELEMENT, Hero defender)
    {
        if (attackELEMENT == defender.GetWeakness())
        {
            return true;
        }
        return false;
    }

    public static bool HasElementDisadvantage(ELEMENT attackELEMENT, Hero defender)
    {
        if (attackELEMENT == defender.GetResistance())
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementalModifier(ELEMENT attackELEMENT, Hero defender)
    {
        if (HasElementAdvantage(attackELEMENT, defender))
        {
            return 1.5f;
        }
        if(HasElementDisadvantage(attackELEMENT, defender))
        {
            return 0.5f;
        }
        return 1f;             
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        int numero = Random.Range(0, 100);
        if (numero > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        {
            return false;
        }
    }

    public static bool IsCrit(int critValue)
    {
        int numero = Random.Range(0, 100);
        if (numero < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats attackerStats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());
        int difesa = 0;
        if (attacker.GetWeapon().GetDmgType() == (Weapon.DAMAGE_TYPE.PHYSICAL))
        {
            difesa = defender.GetBaseStats().def;
        }
        else if (attacker.GetWeapon().GetDmgType() == (Weapon.DAMAGE_TYPE.MAGICAL))
        {
            difesa = defender.GetBaseStats().res;
        }

    }



}
