using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private GameObject player;
    private Animator zombiAnimator;
    private NavMeshAgent NavMesh;
    private PlayerManager playerManager;



    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 2f; // time between hits
    public float damage = 20f;
    public float enemyHealth = 100f;

    private float lastAttackTime = Mathf.NegativeInfinity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        zombiAnimator = GetComponent<Animator>();
        NavMesh = GetComponent<NavMeshAgent>();
        playerManager = player.GetComponent<PlayerManager>();
    }

    public void Hit(float damage)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.enemyHit);

        enemyHealth -= damage;
        Debug.Log("Enemy Health = " + enemyHealth);
        if (enemyHealth <= 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.enemyDie);

            GameManager.instance.enemyIsAlive--;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!player) return;

        // Move towards player
        NavMesh.destination = player.transform.position;

        // Run animation
        bool isMoving = NavMesh.velocity.sqrMagnitude > 0.1f && !NavMesh.isStopped;
        zombiAnimator.SetBool("IsRunning", isMoving);

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            // Stop and attack
            NavMesh.isStopped = true;
            NavMesh.velocity = Vector3.zero;

            // Make sure this bool name matches your Animator parameter!
            zombiAnimator.SetBool("IsAttackking", true);

            // Only damage if cooldown finished
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                PlayerDamage();
            }
        }
        else
        {
            // Chase again
            NavMesh.isStopped = false;
            zombiAnimator.SetBool("IsAttackking", false);
        }
    }

    private void PlayerDamage()
    {
        if (playerManager != null)
        {
            playerManager.HealthDamage(damage);

        }
    }

   
}
