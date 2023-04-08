using System;
using Unit.Enums;
using Unit.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    public class WeaponTransformConfigurator
    {
        public Vector3 WeaponPosition;
        public Vector3 WeaponRotation;
    }
    
    
    /// <summary>
    /// This is what you could consider the "true" first unit of each faction.
    /// Each other unit, which can attack and move, is derived from this class.
    /// Ex: General is inheriting from this class (soldier).
    /// So each general (not faction specific!) has the following, changeable variables from this class.
    ///
    /// CURRENTLY CONFIGURED AS AXE / MACE UNIT
    /// </summary>
    public class Unit : AbstractUnit, IAttackableUnit, IMovable
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Faction _faction;
        [SerializeField] private int _health;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private Transform _spine3Transform;
        [SerializeField] private Transform _handTransform;
        
        
        private WeaponTransformConfigurator _holsterConfiguration = new WeaponTransformConfigurator
        {
            WeaponPosition = new Vector3(-20.8999996f,12.8000002f,12.3000002f), 
            WeaponRotation = new Vector3(77.788765f,140.669983f,40.6851044f)
        };
        
        private WeaponTransformConfigurator _equippedConfiguration = new WeaponTransformConfigurator
        {
            WeaponPosition = new Vector3(9.19999981f,4.19999981f,-2.0999999f),
            WeaponRotation = new Vector3(306.676514f,228.771957f,105.512306f)
        };
        
        private IUnit _target;
        private float _attackRateTimer;

        public override Faction faction
        {
            get { return _faction; }
            set
            {
                _faction = value; //Value is the new faction. Stored in _faction.
            }
        }

        public override int health => _health;
        public override string name => "Unit";
        public virtual float attackRange => _attackRange;
        public virtual float attackRate => _attackRate;
        public virtual float moveSpeed => _moveSpeed;


        // Checks if the target is a valid attackable target
        public bool ValidTarget(IUnit target)
        {
            if (target == this || target.faction == faction)
            {
                return false;
            }

            return true;
        }

        public void SetTarget(IUnit target)
        {
            _target = target;
        }

        public void Move(Vector3 moveTowards)
        {
            _agent.speed = _moveSpeed;
            _agent.destination = moveTowards;
        }

        public override bool TakeDamage(int damage)
        {
            Debug.Log(_health);
            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject, 1.0f);
                return false;
            }

            return true;
        }

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
        
        private void AttackHandler()
        {
            if (_target == null)
            {
                return;
            }

            if (Vector3.Distance(transform.position, _target.transform.position) > attackRange)
            {
                Move(_target.transform.position);
                return;
            }

            Move(transform.position);

            if (!CanAttack())
            {
                return;
            }

            Debug.Log("AttackHandler: CanAttack is true");

            bool alive = _target.TakeDamage(power * level);

            if (!alive)
            {
                _target = null;
            }
        }

        private bool CanAttack()
        {
            if (Time.time >= _attackRateTimer)
            {
                _attackRateTimer = Time.time + (1f / attackRate);

                return true;
            }

            return false;
        }

        private void Update()
        {
            //_agent.velocity.normalized
            AttackHandler();
        }
    }
}