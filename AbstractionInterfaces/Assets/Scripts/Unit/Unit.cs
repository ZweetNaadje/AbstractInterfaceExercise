using System;
using Animation;
using Animation.AnimationInterfaces;
using Unit.Enums;
using Unit.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
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
        [SerializeField] private AbstractWeapon _weapon;

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

        private void Start()
        {
            if (_weapon == null)
            {
                return;
            }
            
            _weapon.transform.localPosition = _weapon.animatable.HolsteredConfiguration.WeaponPosition;
            _weapon.transform.localRotation = Quaternion.Euler(
                _weapon.animatable.HolsteredConfiguration.WeaponRotation
            );
        }


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

        public void OnWeaponGrab(string mode)
        {
            if (_weapon == null)
            {
                return; 
            }
            
            _weapon.OnWeaponGrab(mode);
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

            bool alive = _target.TakeDamage((power * level) + (_weapon.weaponDamage * _weapon.weaponLevel));
            
            
            
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