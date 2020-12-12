using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speed = 8;
    private Vector3 starting_pos = new Vector3(14f, 0, 0);
    Quaternion rot = Quaternion.Euler(0, 0, 0);
    private bool visible = true;
    public float y;
    public AudioClip a;
    
    void FixedUpdate()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (visible == false)
        {
            Instantiate(this, new Vector3(starting_pos.x,y, starting_pos.z), rot);
            visible = true;
            Destroy(this.gameObject);
        }
        
    }
    
    
    void OnBecameInvisible()
    { 
        visible = false;
    }

    private void OnCollisionEnter2D(Collision2D c){
        if (c.gameObject.GetComponent<bullet>()){
            AudioSource.PlayClipAtPoint(a, GetComponent<Transform>().position);
            //GetComponent<AudioSource>().Play();
            Destroy(c.gameObject);
        }

    }

}