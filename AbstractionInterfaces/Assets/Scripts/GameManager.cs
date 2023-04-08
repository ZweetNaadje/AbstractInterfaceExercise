using System;
using System.Runtime.CompilerServices;
using UI;
using Unit;
using Unit.Interfaces;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnitHoverUI _ui;

    private Camera _camera;
    private IUnit _selectedUnit;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _ui.UpdateUI(_selectedUnit);

        MovementHandler();
    }

    // Happy path coding style with the if-statements.
    private void MovementHandler()
    {
        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            return;
        }

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _selectedUnit = hitInfo.transform.GetComponent<IUnit>();
        }

        if (Input.GetMouseButtonDown(1) && _selectedUnit != null)
        {
            var target = hitInfo.transform.GetComponent<IUnit>(); // Specified with "target" in the comments.
            var movableUnit = _selectedUnit as IMovable; // Is the selected unit able to move?
            var attackableUnit = _selectedUnit as IAttackableUnit; // Is the selected unit able to attack?

            if (movableUnit == null) // If you select a non movable unit, return. Currently all code after this part is meant for movable units.
            {
                return;
            }

            if (target == null) // If you didn't click on something which has an "IUnit" (ex: the ground), 
            {
                if (attackableUnit != null) // if you did click on an attackableUnit 
                {
                    attackableUnit.SetTarget(null); // Clear the stored reference to "target". Otherwise you can't move away from a target.
                }
                
                movableUnit.Move(hitInfo.point); // Move the movableUnit to where you clicked in worldspace.
            }

            if (attackableUnit != null && target != null)
            {
                if (!attackableUnit.ValidTarget(target)) // If the attackableUnit doesn't have a valid "target", return. 
                {
                    return;
                }

                attackableUnit.SetTarget(target); // The attackableUnit will target the "target".
            }
        }
    }
}