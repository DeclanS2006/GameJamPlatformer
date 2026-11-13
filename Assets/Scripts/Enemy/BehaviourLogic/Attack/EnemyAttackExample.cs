using UnityEngine;

[CreateAssetMenu(fileName = "Attack - Example", menuName = "Enemy Logic/Attack Logic/Example")]
public class EnemyAttackExample : EnemyAttackSOBase
{
    [SerializeField] private float _timeBetweenAttacks = 2f;
    [SerializeField] private float _timeTillExit = 3f;
    [SerializeField] private float _distanceToCountExit = 3f;
    // [SerializeField] private float _bulletSpeed = 10f;

    private float _timer;
    private float _exitTimer;

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

        enemy.MoveEnemy(Vector2.zero);

        if (_timer > _timeBetweenAttacks)
        {
            _timer = 0f;

            Debug.Log("Attacking");

            //This calculates the distance to the player, not sure if needed, needed for a bullet
            // Vector2 dir = (playerTransform,position - enemy.transform.position).normalized;

            // Rigidbody2D bullet = GameObject.Instantiate(BulletPrefab, enemy.transform.position, Quanternion.identity);
            // bullet.velocity = dir * _bulletSpeed;
        }

        // This is expensive to do everyframe so find another place to do it
        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
                Debug.Log("Exiting");
            }
        }

        else
        {
            _exitTimer = 0f;
        }

        _timer += Time.deltaTime;
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
