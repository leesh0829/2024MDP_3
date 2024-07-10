using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 5;
    float moveX;

    int jumpMax = 2;
    int jumpCount = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetAxisRaw("Horizontal") != -1)
            transform.localScale = new Vector3(1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;

        if (collision.gameObject.CompareTag("Spikes"))
        {
            transform.position += new Vector3(-3, 3, 0);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            //코스 선택 씬으로 이동
        }
    }

        void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }

    void Jump()
    {
        if (jumpCount >= jumpMax)
            return;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        jumpCount++;
    }
}
