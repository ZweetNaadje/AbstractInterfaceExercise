using Animation.AnimationInterfaces;
using UnityEngine;

namespace Animation.WeaponAnimatables
{
    public class SwordAnimatable : IWeaponAnimatable
    {
        public GameObject Weapon => _weapon;
        public Transform HolsterTransform => _holsterTransform;
        public Transform EquippedTransform => _equippedTransform;

        private GameObject _weapon;
        private Transform _holsterTransform;
        private Transform _equippedTransform;

        public WeaponTransformConfigurator EquippedConfiguration => new WeaponTransformConfigurator()
        {
            WeaponPosition = new Vector3(9.19999981f,4.19999981f,-2.0999999f),
            WeaponRotation = new Vector3(332.394958f,66.1756744f,259.614807f)
        };

        public WeaponTransformConfigurator HolsteredConfiguration => new WeaponTransformConfigurator()
        {
            WeaponPosition = new Vector3(29.2999992f,-42.2999992f,-13.5f),
            WeaponRotation = new Vector3(36.3844604f,119.018822f,344.784058f)
        };

        public void SetData(GameObject weapon, Transform holsterTransform, Transform equipTransform)
        {
            _weapon = weapon;
            _holsterTransform = holsterTransform;
            _equippedTransform = equipTransform;
        }
    }
}