using System;
using Unit.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    public class Soldier : BaseUnit, IAttackableUnit, IMoveable
    {
        [SerializeField] private NavMeshAgent _agent;

        public override string name => "Soldier";
        public float attackRange { get; }
        public float attackRate { get; }
        public float moveSpeed => 3f;


        public bool CanAttack()
        {
            throw new System.NotImplementedException();
        }

        public int Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector3 moveTowards)
        {
            _agent.destination = moveTowards;
        }

        private void Update()
        {
            //_agent.velocity.normalized
        }
    }
}