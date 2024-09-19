using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    
    public Bullet bulletPrefab;
    
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    bool thrusting;
    float turnDirection;
    public AudioSource shootSound;
    
    // Update is called once per frame
    void Update()
    {
        thrusting = (Input.GetKey(KeyCode.W)); //move forward

        if (Input.GetKey(KeyCode.A)) { //begin turn direction
            turnDirection = 1.0f;

            }else if (Input.GetKey(KeyCode.D)) {
                turnDirection = -1.0f;

            } else {
                turnDirection = 0.0f;
            } //end if else turnDirection
        
        if (Input.GetKeyDown(KeyCode.I) ||  Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }

        } //end Update()

    void FixedUpdate() 
    {
        if (thrusting) {
            GetComponent<Rigidbody2D>().AddForce(this.transform.up * thrustSpeed);
        }

        if (turnDirection != 0.0f) {
            GetComponent<Rigidbody2D>().AddTorque(this.turnSpeed * turnDirection);
        }

    } //end FixedUpdate()
    private void Shoot() {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        shootSound.Play();
    } //end Shoot()

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Asteroid") {
            this.gameObject.SetActive(false);

            //FindObjectOfType<GameManager>().PlayerDied();
            gameManager.PlayerDied();

        }
            
    }

    private void scoreUp()
    {
        if (Input.GetKey(KeyCode.F))
        {
            gameManager.increaseScore();
        }
    }

    }

