using UnityEngine;

namespace Animation.AnimationInterfaces
{
    public interface IWeaponAnimatable
    {
        /// <summary>
        /// The actual weapon gameObject where this IWeaponAnimatable is attached to. 
        /// </summary>
        public GameObject Weapon { get; }
        
        /// <summary>
        /// HolsterTransform holds the transform of where the weapon is actually going to be holstered (Your back, arm (ex: AC style) or wherever you want to holster the weapon). 
        /// </summary>
        public Transform HolsterTransform { get; }
        
        /// <summary>
        /// EquippedTransform holds the transform of where the weapon is actually going to be equipped (A hand, head or wherever you want to place the weapon).
        /// </summary>
        public Transform EquippedTransform { get; }
        
        /// <summary>
        /// EquippedConfiguration holds the configuration of transforms of how the weapon should be positioned / rotated when equipped. 
        /// </summary>
        public WeaponTransformConfigurator EquippedConfiguration { get; }
        
        /// <summary>
        /// UnequippedConfiguration holds the configuration of transforms of how the weapon should be positioned / rotated when holstered.
        /// </summary>
        public WeaponTransformConfigurator HolsteredConfiguration { get; }

        /// <summary>
        /// You use this method for setting the correct data for your weapon animations.
        /// </summary>
        /// <param name="weapon">A weapon gameObject that has an IWeaponAnimatable</param>
        /// <param name="holsterTransform">Holds the transform from where the weapon will be holstered</param>
        /// <param name="equipTransform">Holds the transform from where the weapon will be equipped</param>
        public void SetData(GameObject weapon, Transform holsterTransform, Transform equipTransform);

    }
}