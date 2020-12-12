using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

	public float speed = 2;
    public AudioClip destroy;
    private AudioSource audioSource;
	
	public GameObject Target;
    Vector3 startPos = new Vector3(0f, -4.34f, 0f);
    Quaternion rot = Quaternion.Euler(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        Vector3 posn = transform.position;
        if (posn.z >= -0.5){
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<Target>()) {
			Score.scoreValue += 1;
            AudioSource.PlayClipAtPoint(destroy, GetComponent<Transform>().position);
			Destroy(c.gameObject);
			Instantiate(Target, startPos, rot);
		}
    }
}
