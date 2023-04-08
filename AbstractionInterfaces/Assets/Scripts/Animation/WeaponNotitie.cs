using UnityEngine;

namespace Animation
{
    public class WeaponNotitie
    {
        private int _health = 100;

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                if (value < 0)
                {
                    return;
                }
                
                _health = value;
            }
        }

        [SerializeField] private GameObject _weapon;
        [SerializeField] private Transform _spine3Transform;
        [SerializeField] private Transform _handTransform;
        
        
        public Vector3 WeaponPosition;
        public Vector3 WeaponRotation;
        
        private WeaponNotitie _holsterConfiguration = new WeaponNotitie
        {
            // Unnamed constructor
            WeaponPosition = new Vector3(-20.8999996f,12.8000002f,12.3000002f), 
            WeaponRotation = new Vector3(77.788765f,140.669983f,40.6851044f)
        };
        
        private WeaponNotitie _equippedConfiguration = new WeaponNotitie
        {
            WeaponPosition = new Vector3(9.19999981f,4.19999981f,-2.0999999f),
            WeaponRotation = new Vector3(306.676514f,228.771957f,105.512306f)
        };
        
        private void OnWeaponGrab(string mode)
        {
            if (_weapon == null)
            {
                return;
            }

            if (mode == "equip")
            {
                _weapon.transform.SetParent(_handTransform);

                _weapon.transform.localPosition = _equippedConfiguration.WeaponPosition;
                _weapon.transform.localRotation = Quaternion.Euler(_equippedConfiguration.WeaponRotation);
            }

            if (mode == "unequip")
            {
                _weapon.transform.SetParent(_spine3Transform);

                _weapon.transform.localPosition = _holsterConfiguration.WeaponPosition;
                _weapon.transform.localRotation = Quaternion.Euler(_holsterConfiguration.WeaponRotation);
            }
            
            
        }
    }
}