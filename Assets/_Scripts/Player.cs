using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 2f;
    public float speed = 3f;
    public bool isMovingRight = true;
    public bool isPause = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Freeze(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Jump();
    }

    private void FixedUpdate()
    {
        Moving(isMovingRight);
    }

    private void Jump() => _rigidbody2D.velocity = Vector2.up * jumpForce;

    private void Moving(bool isMovingRight)
    {
        switch (isMovingRight)
        {
            case true:
                _rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
                break;
            case false:
                _rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime * -1, ForceMode2D.Impulse);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //KnockBack(isMovingRight);
            isMovingRight = !isMovingRight;
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collectable")
        {
            GameController.I.UpdateCollectedFruits();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Trap")
        {
            GameController.I.LoseGame();
        }
    }
    private void KnockBack (bool isMovingRight)
    {
        switch (isMovingRight)
        {
            case true:
                _rigidbody2D.AddForce(new Vector2(5,3), ForceMode2D.Impulse);
                break;
            case false:
                _rigidbody2D.AddForce(new Vector2(-5,3), ForceMode2D.Impulse);
                break;
        }
    }

    public void Freeze(bool isFreeze)
    {
        _rigidbody2D.bodyType = isFreeze ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

}
