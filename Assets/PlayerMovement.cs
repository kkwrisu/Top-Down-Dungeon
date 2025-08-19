using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 direcao = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input.Normalize();

        // Virar o sprite para a esquerda ou direita
        if (input.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f);
        if (collision != null)
        {
            transform.position -= direcao;
            Debug.Log("Colidiu com: " + collision.gameObject.name);

        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }

}
    

