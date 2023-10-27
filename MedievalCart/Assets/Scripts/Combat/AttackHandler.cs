using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackState { Cast, Attacked, CanAttack }

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private float castTime;
    [SerializeField] private float attackDelay;

    [Space]
    [SerializeField] private float neededValue;

    [Space]
    //[SerializeField] private AttackCastEffect[] castEffects;
    //[SerializeField] private AttackEffect[] attackEffects;

    [Space]
    [SerializeField] private AttackState state;

    //private ObjectPoolingManager poolingManager;
    private Vector3 attackPoint;

    public float NeededValue { get => neededValue; }

    public void Init()
    {
    //    poolingManager = ServiceLocator.GetService<ObjectPoolingManager>();

    //    state = AttackState.CanAttack;

    //    foreach (AttackEffect effect in attackEffects)
    //    {
    //        effect.OnInit();
    //    }
    }

    public bool TryAttack(Vector3 attackPoint)
    {
        if (state == AttackState.CanAttack)
        {
            this.attackPoint = attackPoint;
            StartCast();
            return true;
        }

        return false;
    }

    private void StartCast()
    {
        state = AttackState.Cast;

        //foreach (AttackCastEffect prefab in castEffects)
        //{
        //    PoolableObject effect = poolingManager.GetPoolable(prefab.Prefab);
        //    effect.transform.position = attackPoint + prefab.Offset;
        //}

        Invoke(nameof(Attack), castTime);
    }

    private void Attack()
    {
        //foreach (AttackEffect effect in attackEffects)
        //{
        //    effect.OnAttack(attackPoint);
        //}

        //if (animator) animator.SetTrigger("Attack");

        //state = AttackState.Attacked;
        //Invoke(nameof(EndAttack), attackDelay);
    }

    //private void EndAttack()
    //{
    //    state = AttackState.CanAttack;
    //}
}

//[System.Serializable]
//public struct AttackCastEffect
//{
    //public PoolableObject Prefab;
    //public Vector3 Offset;
//}

