using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    private bool isFacingRight = true;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float movement = Input.GetAxis ("Horizontal");

      if (movement > 0f) {
        isFacingRight = true;
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
      }

      else if (movement < 0f) {
        isFacingRight = false;
        rb.velocity = new Vector2 (movement * speed, rb.velocity.y);
      } 

      else {
        rb.velocity = new Vector2 (0, rb.velocity.y);
      }

      if (Input.GetButtonDown ("Jump")){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }
    }

    void FixedUpdate() {
      Vector3 newScale = transform.localScale;

      if (isFacingRight) {
        newScale.x = 1;
      } else {
        newScale.x = -1;
      }

      transform.localScale = newScale;
    }
}
