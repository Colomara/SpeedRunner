using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 7f;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.5f;
    public int damage = 10;

    private int currentWaypointIndex = 0;
    private Transform player;
    private PlayerHealth playerHealth;
    private bool isPlayerDetected = false;
    private bool isAttacking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        playerHealth = player?.GetComponent<PlayerHealth>();

        if (player == null || playerHealth == null)
        {
            Debug.LogError("Player or PlayerHealth not found by EnemyAI!");
        }
    }

    private void Update()
    {
        if (player == null || playerHealth == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isPlayerDetected = distanceToPlayer < detectionRange;

        if (isPlayerDetected)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        float step = moveSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;

        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }

      
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("💥 Player Took Damage!");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
