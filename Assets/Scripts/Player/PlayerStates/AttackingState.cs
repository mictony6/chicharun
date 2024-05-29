using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackState : PlayerState
{
    private SoundManager soundEffects;
    public AttackState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.combatBehavior.canAttack = false;
        player.weaponBehavior.Shoot();
        player.TransitionToPrev();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }

    
}