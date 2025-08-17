using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health Settings")]
    public int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    [SerializeField] private float iFramesDuration = 0.3f;

    public HealthUI healthUI;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;
        currentHealth -= damage;
        healthUI.UpdatedHearts(currentHealth);

        StartCoroutine(FlashRed());
        if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(ActivateIFrames());
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator ActivateIFrames()
    {
        isInvulnerable = true;

        float elapsed = 0f;
        while (elapsed < iFramesDuration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }

        isInvulnerable = false;
    }


    private void Die()
    {
        // Implementação da morte do jogador
    }
}
