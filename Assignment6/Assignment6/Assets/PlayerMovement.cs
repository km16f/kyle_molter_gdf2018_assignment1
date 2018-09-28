using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Text countText1, countText2, Total;

    private Rigidbody2D moving;
    private int count1;
    private int count2;
    private int tot;

    void Start()
    {
        moving = GetComponent<Rigidbody2D>();
        count1 = 0;
        count2 = 0;
        SetCount();
    }

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        moving.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("GetAsteroid"))
        {
            other.gameObject.SetActive(false);
            count1++;
            SetCount();
        }
        else if(other.gameObject.CompareTag("GetAsteroid2"))
        {
            other.gameObject.SetActive(false);
            count2++;
            SetCount();
        }

    }

    void SetCount()
    {
        countText1.text = "Count1: " + count1.ToString();
        countText2.text = "Count2: " + count2.ToString();
        tot = count1 + count2 * 5;
        Total.text = "Total: " + tot.ToString();
    }
}


