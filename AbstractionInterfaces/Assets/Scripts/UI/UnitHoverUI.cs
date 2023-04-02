using System;
using TMPro;
using Unit.Interfaces;
using UnityEngine;

namespace UI
{
    public class UnitHoverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _factionLabel;
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _healthLabel;
        [SerializeField] private TextMeshProUGUI _powerLabel;
        [SerializeField] private TextMeshProUGUI _levelLabel;

        private void Start()
        {
            ClearUI();
        }

        public void UpdateUI(IUnit unit)
        {
            if (unit == null)
            {
                ClearUI();
                return;
            }
            
            _factionLabel.text = $"Faction: {unit.faction}";
            _nameLabel.text = $"Name: {unit.name}";
            _healthLabel.text = $"Health: {unit.health}";
            _powerLabel.text = $"Power: {unit.power}";
            _levelLabel.text = $"Level: {unit.level}";
        }

        private void ClearUI()
        {
            _factionLabel.text = "";
            _nameLabel.text = "";
            _healthLabel.text = "";
            _powerLabel.text = "";
            _levelLabel.text = "";
        }
    }
}