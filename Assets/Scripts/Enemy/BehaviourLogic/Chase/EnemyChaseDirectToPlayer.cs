using UnityEngine;

[CreateAssetMenu(fileName = "Chase - DirectToPlayer", menuName = "Enemy Logic/Chase Logic/Direct To Player")]
public class EnemyChaseDirectToPlayer : EnemyChaseSOBase
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _MovementSpeed = 5f;
    [SerializeField] private Vector3 _targetPos;
    [SerializeField] private Vector3 _direction;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject,enemy);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic() 
    { 
        base.DoExitLogic(); 
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        Vector2 moveDirection = (playerTransform.position - enemy.transform.position).normalized;

        enemy.MoveEnemy(moveDirection * _MovementSpeed);
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
}
