using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float moveSpeed;
    public int damage;
    public float lifeTime;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * moveSpeed);
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            collision.gameObject.GetComponent<Target>().Damage(damage);
        }
        Destroy(gameObject);
    }
}
