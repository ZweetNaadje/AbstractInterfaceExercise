using System;
using UI;
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
            var moveable = _selectedUnit as IMoveable;

            if (moveable == null)
            {
                return;
            }

            moveable.Move(hitInfo.point);
        }
    }
}