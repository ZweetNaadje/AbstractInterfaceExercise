﻿using Animation;
using Animation.AnimationInterfaces;
using Animation.WeaponAnimatables;
using UnityEngine;

namespace Weapons
{
    public class Sword : AbstractWeapon
    {
        [SerializeField] private Transform _holsterTransform;
        [SerializeField] private Transform _equippedTransform;

        private IWeaponAnimatable _animatable = new SwordAnimatable();
        
        public override int weaponDamage => 10;
        public override IWeaponAnimatable animatable => _animatable;

        private void Start()
        {
            animatable.SetData(gameObject, _holsterTransform, _equippedTransform);
        }
    }
}