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
            var target = hitInfo.transform.GetComponent<IUnit>();
            var moveableUnit = _selectedUnit as IMoveable;
            var attackableUnit = _selectedUnit as IAttackableUnit;

            if (moveableUnit == null)
            {
                return;
            }

            if (target == null)
            {
                if (attackableUnit != null)
                {
                    attackableUnit.SetTarget(null);    
                }
                
                moveableUnit.Move(hitInfo.point);
            }

            if (attackableUnit != null && target != null)
            {
                if (!attackableUnit.ValidTarget(target))
                {
                    return;
                }

                attackableUnit.SetTarget(target);
            }
        }
    }
}