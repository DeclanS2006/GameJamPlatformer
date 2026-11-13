using UnityEngine;

[CreateAssetMenu(fileName = "Idle - Patrol Left Right", menuName = "Enemy Logic/Idle Logic/Patrol Left Right")]
public class EnemyIdlePatrolLeftRight : EnemyIdleSOBase
{
    [SerializeField] private float PatrolRange = 10f;
    [SerializeField] private float PatrolSpeed = 2f;
    [SerializeField] private Vector3 _targetPos;
    [SerializeField] private Vector3 _direction;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject,enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        _targetPos = GetTargetPos(enemy.transform.position);
    }

    public override void DoExitLogic() 
    { 
        base.DoExitLogic(); 
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _direction = (_targetPos - enemy.transform.position).normalized;

        enemy.MoveEnemy(_direction * PatrolSpeed);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f )
        {
            _targetPos = GetTargetPos(enemy.transform.position);
        }
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    // Only needed in case you need to reset bools or null anything when changing states
    public override void ResetValues()
    {
        base.ResetValues();
    }

    private Vector3 GetTargetPos(Vector3 currentPos)
    {
        currentPos.x += PatrolRange * -enemy.facingDirection;
        return currentPos;
    }
}
