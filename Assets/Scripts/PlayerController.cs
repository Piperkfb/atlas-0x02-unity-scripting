using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
        public float speed = 2000f;
        private Rigidbody rb;
        private int score;
        public int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void playermove()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal")
        {
            Debug.Log($"You win!");
        }
    }
}