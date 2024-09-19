using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameManager gameManager;
    
    public Sprite[] asteroidSprites;
    public float size = 1.0f;
    public float minSize = 0.3f;
    public float maxSize = 2.0f;
    public float speed = 25.0f;
    
    void Start()
    {
         GetComponent<SpriteRenderer>().sprite = asteroidSprites[
            Random.Range(0, asteroidSprites.Length)];
        
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        GetComponent<Rigidbody2D>().mass = this.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Bullet") 
        {
        
            if ((this.size * 0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
            
        }
        else if (collision.gameObject.tag == "AKiller")
        {
            Destroy(this.gameObject);
        }
            
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * (this.speed / 3));
    }

    public void SetTrajectory(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
        Destroy(this.gameObject, 30.0f);
    }
}
