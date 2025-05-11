using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{

    public Hero champ1;
    public Hero champ2;
    private Hero first;
    private Stats firstChampStats;
    private Hero second;
    private Stats secondChampstats;

    Stats champ1Stats = new Stats();
    Stats champ2Stats = new Stats();



    // Start is called before the first frame update
    void Start()
    {

        champ1Stats = Stats.Sum(champ1.GetBaseStats(), champ1.GetWeapon().GetBonusStats());
        champ2Stats = Stats.Sum(champ2.GetBaseStats(), champ2.GetWeapon().GetBonusStats());

        if (champ1Stats.spd > champ2Stats.spd)
        {
            first = champ1;
            second = champ2;
            firstChampStats = champ1Stats;
            secondChampstats = champ2Stats;
        }
        else
        {
            first = champ2;
            second = champ1;
            firstChampStats = champ2Stats;
            secondChampstats = champ1Stats;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!champ1.IsAlive() || !champ2.IsAlive())
        {
            Debug.Log("Uno dei due contendenti è morto! Lo scontro non può iniziare!");
            this.enabled = false;
            return;
        }

        Attack(first, second, firstChampStats, secondChampstats);

        if (!second.IsAlive())
        {
            Debug.Log($"Scontro concluso, vince {first.GetName()}");
            return;
        }

        Attack(second, first, secondChampstats, firstChampStats);

        if (!first.IsAlive())
        {
            Debug.Log($"Scontro concluso, vince {second.GetName()}!");
            return;
        }
    }

    private void Attack(Hero attacker, Hero defender, Stats attackerStats, Stats defenderStats)
        {
        Debug.Log($"Attaccante: {attacker.GetName()} - Difensore: {defender.GetName()}");

        if (GameFormulas.HasHit(attackerStats, defenderStats))
        {
            if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("WEAKNESS: colpita debolezza elementale!");
            }
            else
            {
                Debug.Log("RESIST: attivata resistenza elementale!");
            }
            int damage = GameFormulas.CalculateDamage(attacker, defender);
            Debug.Log($"Danno calcolato: {damage}");
            defender.TakeDamage(damage);
        }
    }
}


