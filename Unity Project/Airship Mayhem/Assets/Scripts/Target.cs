using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int hp;

    public void Damage(int i)
    {
        hp -= i;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
