using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public float speed = 1f;
	public GameObject bullet; 
    public AudioClip a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	float h = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    	GetComponent<Rigidbody>().velocity = Vector3.right * h * speed + Vector3.up * y * speed;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Vector3 posn = transform.position;
            posn.z += 2f;
            AudioSource.PlayClipAtPoint(a, GetComponent<Transform>().position);
            Instantiate(bullet, posn, Quaternion.identity);
        }
    }
}
