using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    [Header("Combat")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 20f;
    public float dashForce = 20f;
    public float dashCooldown = 3f;
    public float dashTime = 0.2f;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    } 
}