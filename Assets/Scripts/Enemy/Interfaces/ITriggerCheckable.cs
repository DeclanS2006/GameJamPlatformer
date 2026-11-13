using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAggroed { get; set; }
    bool IsWithinAttackRange { get; set; }

    void SetAggroStatus(bool IsAggroed);
    void SetAttackRangeBool(bool IsWithinAttackRange);
}
