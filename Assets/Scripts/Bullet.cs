using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int points;
    public int damage = 1;
    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;
    public Color initialColor = Color.white;
    public Color  finalColor;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private float _startingTime;
    private bool _returning;
    
    void Awake() 
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //Save initial time
        _startingTime = Time.time;

        //Destroy the bullet after some time
        Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
         //Change bullet´s color over time
         float _timeSinceStarted = Time.time - _startingTime;
         float _persentageCompleted = _timeSinceStarted / livingTime;
         _renderer.color = Color.Lerp(initialColor, finalColor, _persentageCompleted);
    }
    private void FixedUpdate() 
    {
        //Move object
        Vector2 movement = direction.normalized * speed;
        _rigidbody.velocity = movement;
        //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y); //la posicion que tienes + la que te toca por el tiempo que ha pasado y la volocidad en la que te quieres mover
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player")){
            //Tell player to get hurt
            collision.SendMessageUpwards("AddDamage", damage);
            Destroy(gameObject);
        }

        if (_returning == true && collision.CompareTag("Enemy")){
            collision.SendMessageUpwards("AddDamage");
            
            Destroy(gameObject);
        }    
    }
    public void AddDamage()
    {
        _returning = true;
        direction = direction * -1f;
    }
}
