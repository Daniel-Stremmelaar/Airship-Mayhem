using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float moveSpeed;
    public int damage;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * moveSpeed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            collision.gameObject.GetComponent<Target>().Damage(damage);
        }
    }
}
