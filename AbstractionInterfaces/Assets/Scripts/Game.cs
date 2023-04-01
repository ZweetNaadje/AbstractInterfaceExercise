using System;
using System.Collections.Generic;
using Unit;
using Unit.Interfaces;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<IUnit> Units = new List<IUnit>();

    private void Start()
    {
        var soldier = new Soldier();
        var medic = new Medic();
        var general = new General();
        
        Units.Add(soldier);
        Units.Add(medic);
        Units.Add(general);

        soldier.Attack();

        foreach (var unit in Units)
        {
            if (unit is IAttackableUnit attackableUnit)
            {
                attackableUnit.Attack();
            }

            if (unit is IHealableUnit healableUnit)
            {
                healableUnit.Heal();
            }
        }
    }
}