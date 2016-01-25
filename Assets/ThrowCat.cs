using UnityEngine;
using System.Collections;

public class ThrowCat : MonoBehaviour {

    private Vector3 gravity = new Vector3(0.0f, -9.8f, 0.0f);
    public float angle;
    public float speed;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
         
        if(Mathf.Abs(rb.position.y - 11.25f) < 0.01f && Mathf.Abs(rb.position.x - 11.0f) < 0.01f && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            return;
        }

        if(Input.GetButtonDown("Vertical"))
        {
            if (rb.position.y < 0.6f)
            {
                var x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                var y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                Vector3 force = new Vector3(x, y, 0.0f);
                rb.AddForce(force * speed, ForceMode.Impulse);
            }
        }
        else if(Input.GetButtonDown("Horizontal"))
        {
            rb.position = new Vector3(1, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }

        rb.AddForce(gravity * Time.deltaTime, ForceMode.Impulse);
        Vector3 wind = new Vector3(-rb.position.y, 0, 0);
        rb.AddForce(wind * Time.deltaTime, ForceMode.Impulse);
    }
}
