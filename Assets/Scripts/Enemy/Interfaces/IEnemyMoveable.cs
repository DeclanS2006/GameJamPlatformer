using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D rb { get; set; }
    int facingDirection { get; set; }

    void MoveEnemy(Vector2 velocity);

    void CheckDirection();
}
