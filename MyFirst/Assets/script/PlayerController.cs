using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed=10f;
    private Rigidbody rb;
    private int count;
    public Text score;
    public Text win;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        DisplayScore();
        win.text = "Collect All The Cubes!";
    }

    void Update () {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hori,0.0f,vert);
        rb.AddForce(movement * speed);
	}
    private void OnTriggerEnter(Collider other)
    {
        win.text = "";
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            DisplayScore();
        }
    }
    void DisplayScore()
    {
        score.text = "Score:" + count.ToString();
        if (count == 15)
            win.text = "Congrats! You Win";
    }
}
