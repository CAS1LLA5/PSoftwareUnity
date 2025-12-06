using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float longIdleTime = 5f; // Tiempo para activar animación de reposo largo
    public float speed = 20000f; // Velocidad de movimiento del jugador
    public float jumpForce = 2.5f; // Fuerza del salto

    public Transform groundCheck; // Punto para verificar si está en el suelo
    public LayerMask groundLayer; // Capa que define el suelo
    public float groundCheckRadius; // Radio para la verificación del suelo

    // Referencias a componentes
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    // Temporizador para animación de reposo largo
    private float _longIdleTimer;

    // Movimiento
    private Vector2 _movement;
    private bool _facingRight = true; // Dirección a la que mira el jugador
    private bool _isGrounded; // Indica si el jugador está en el suelo

    // Ataque
    private bool _isAttacking; // Indica si el jugador está atacando

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
        _animator = GetComponent<Animator>(); // Obtiene el componente Animator
    }
    // Start se llama antes de la primera actualización
    void Start()
    {

    }

    // Update se llama una vez por frame
    void Update()
    {
        if (_isAttacking == false)
        {
            // Movimiento horizontal
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            // Voltear el personaje si cambia dirección
            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }
        }

        // Verifica si está en el suelo usando un círculo en groundCheck
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Saltar si se presiona el botón Jump, está en el suelo y no está atacando
        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Ataque si se presiona Fire1 en el suelo y no está atacando
        if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
        {
            _movement = Vector2.zero; // Detiene el movimiento
            _rigidbody.velocity = Vector2.zero; // Detiene la velocidad actual
            _animator.SetTrigger("Attack"); // Activa la animación de ataque
        }
    }
    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            // Aplica la velocidad horizontal al Rigidbody
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
    }
    void LateUpdate()
    {
        // Actualiza parámetros de animación
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        // Controla si está en animación de ataque
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }

        // Controla temporizador para animación de reposo largo
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _longIdleTimer += Time.deltaTime;

            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            }
        }
        else
        {
            _longIdleTimer = 0f;
        }
    }
    private void Flip()
    {
        _facingRight = !_facingRight; // Cambia la dirección a la opuesta
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f; // Invierte la escala en X para voltear
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
