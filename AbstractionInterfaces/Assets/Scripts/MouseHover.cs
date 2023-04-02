using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unit;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public List<Soldier> Soldiers = new List<Soldier>();

    private void Start()
    {
        var soldier = GetComponent<Soldier>();

        Soldiers.Add(soldier);
        
        _text.text = "";
    }

    private void OnMouseDown()
    {
        Debug.Log("hehehehe");

        foreach (var soldier in Soldiers)
        {
            if (soldier is General general)
            {
                //_text.transform.position = soldier.transform.position;
                _text.text = $"Name: {general.name} \n Health: {general.health} \n Level: {general.level} \n Power: {general.power}";
            }

            if (soldier is Undead undead)
            {
                //_text.transform.position = undead.transform.position;
                _text.text = $"Name: {undead.name} \n Health: {undead.health} \n Level: {undead.level} \n Power: {undead.power}";
            }
        }
    }
}