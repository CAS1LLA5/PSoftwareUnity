using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    //References
    public GameObject SlashPrefab;
    private Transform _firePoint;
    public GameObject shooter;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    //Score
    public Score _score;
    private int _points;

    //Movement
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool _isGrounded;
    private bool _isAttacking;
    private Vector2 _movement;

    void Awake() 
    {
        _firePoint = transform.Find("FirePoint");
        _animator = GetComponent<Animator>();
        shooter.GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && _isGrounded == true && _isAttacking == false && _score.score >= 300){
            SubtractPoints();
            ShootSlash();
            _movement = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;
            _animator.SetTrigger("Attack");
        }
        FlipSlash();
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
           _isAttacking = true;
           //_audio.Play();
        } else {
           _isAttacking = false;
        }
    }

    //Disparar Slash
    public void ShootSlash()
    {
        if(SlashPrefab != null && _firePoint != null && shooter != null){
            GameObject mySlash = Instantiate(SlashPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Slash SlashComponent = mySlash.GetComponent<Slash>();
            if(shooter.transform.localScale.x<0f){
                SlashComponent.direction = Vector2.left;
                //SlashPrefab.transform.localScale.x = Vector2Int;
                //SlashPrefab.GetComponent<SpriteRenderer>().flipX = true;
            }else{
                SlashComponent.direction = Vector2.right;
                //SlashPrefab.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    //Voltear Slash
    private void FlipSlash()
    {
        if(shooter.transform.localScale.x<0f){
            SlashPrefab.GetComponent<SpriteRenderer>().flipX = true;
        }else{
            SlashPrefab.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    //Restar puntos
    public void SubtractPoints()
    {
        if(_score.score >= 300){
            _score.score = _score.score - 300;
            Debug.Log("Tienes 300 puntos");
        } else if(_score.score <=299){
            Debug.Log("No tienes 300 puntos");
        }
    }
}