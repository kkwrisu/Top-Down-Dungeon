using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int trapDamage = 1;
    private int coinCount = 0;
    public int damage = 1;

    private PlayerHealth playerHealth;

    private void Start()
    {
        coinText.text = "Coins: " + coinCount;

        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            coinCount++;
            coinText.text = "Coins: " + coinCount;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(trapDamage);
            }
        }
    }
}
