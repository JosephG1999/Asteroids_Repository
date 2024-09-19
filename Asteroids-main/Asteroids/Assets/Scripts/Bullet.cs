using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed = 600.0f;
    public float bullet_lifetime = 1.0f;


    public void Project(Vector2 direction) {
        GetComponent<Rigidbody2D>().AddForce(direction * this.bullet_speed);
        Destroy(this.gameObject, this.bullet_lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
            Destroy(this.gameObject);
    }
    
}
