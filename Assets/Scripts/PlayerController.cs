using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text countText;
    public Text winText;

    private Rigidbody player;
    public float speed;
    private int count;

	void Start () 
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
	}
	
	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        player.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PickUp")
        {
            Destroy(col.gameObject);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
