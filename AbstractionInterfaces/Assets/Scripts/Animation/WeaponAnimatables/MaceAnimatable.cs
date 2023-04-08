using Animation.AnimationInterfaces;
using UnityEngine;

namespace Animation.WeaponAnimatables
{
    public class MaceAnimatable : IWeaponAnimatable
    {
        public GameObject Weapon => _weapon;
        public Transform HolsterTransform => _holsterTransform;
        public Transform EquippedTransform => _equippedTransform;

        private GameObject _weapon;
        private Transform _holsterTransform;
        private Transform _equippedTransform;

        public WeaponTransformConfigurator EquippedConfiguration => new WeaponTransformConfigurator()
        {
            WeaponPosition = new Vector3(9.19999981f, 4.19999981f, -2.0999999f),
            WeaponRotation = new Vector3(306.676514f, 228.771957f, 105.512306f)
        };

        public WeaponTransformConfigurator HolsteredConfiguration => new WeaponTransformConfigurator()
        {
            WeaponPosition = new Vector3(-20.8999996f, 12.8000002f, 12.3000002f),
            WeaponRotation = new Vector3(77.788765f, 140.669983f, 40.6851044f)
        };

        public void SetData(GameObject weapon, Transform holsterTransform, Transform equipTransform)
        {
            _weapon = weapon;
            _holsterTransform = holsterTransform;
            _equippedTransform = equipTransform;
        }
    }
}