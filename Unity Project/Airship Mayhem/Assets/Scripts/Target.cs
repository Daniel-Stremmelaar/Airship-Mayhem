using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int hp;
    public int damage;
    public int explosionRadius;
    public int explosionSpeed;
    private SphereCollider s;
    private bool exploded;

    private void Start()
    {
        exploded = false;
        s = gameObject.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if(exploded == true)
        {
            s.radius += Time.deltaTime * explosionSpeed;
            if(s.radius >= explosionRadius)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Damage(int i)
    {
        hp -= i;
        if(hp <= 0)
        {
            exploded = true;
            s.isTrigger = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
