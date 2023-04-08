using System;
using Animation.AnimationInterfaces;
using UnityEngine;

namespace Animation
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        /// <summary>
        /// This given interface controls the weapon animations. 
        /// </summary>
        public virtual IWeaponAnimatable animatable { get; }
        
        /// <summary>
        /// This property will add extra damage values to the weapon, which increases the units power. (Damage dealt)
        /// </summary>
        public virtual int weaponDamage { get; }
        
        /// <summary>
        /// This property will add (an) extra level(s) to the weapon, which increases the units power. (Damage dealt)
        /// </summary>
        public virtual int weaponLevel { get; }

        /// <summary>
        /// You use this method for switching between weapon modes. ATM: equip & holster
        /// </summary>
        /// <param name="mode">The mode of the weapon. (equip & holster)</param>
        public virtual void OnWeaponGrab(string mode)
        {
            if (animatable == null)
            {
                return;
            }

            if (mode == "equip")
            {
                animatable.Weapon.transform.SetParent(animatable.EquippedTransform);

                animatable.Weapon.transform.localPosition = animatable.EquippedConfiguration.WeaponPosition;
                animatable.Weapon.transform.localRotation = Quaternion.Euler(
                    animatable.EquippedConfiguration.WeaponRotation
                );
            }

            if (mode == "holster")
            {
                animatable.Weapon.transform.SetParent(animatable.HolsterTransform);

                animatable.Weapon.transform.localPosition = animatable.HolsteredConfiguration.WeaponPosition;
                animatable.Weapon.transform.localRotation = Quaternion.Euler(
                    animatable.HolsteredConfiguration.WeaponRotation
                );
            }
        }
    }
}