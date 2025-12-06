using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //public GameObject explosionEffect;
    public GameObject explosionEffect;

    public AudioSource _audio;
    public AudioClip _clip;
    private bool _returning;
    //public GameObject _bulletScript;
    //_bulletScript;
    void Awake()
    {
        //_bulletScript.GetComponent<Bullet>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (_returning == false && collision.CompareTag("Player")){
            Instantiate(explosionEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(_clip, gameObject.transform.position);
        }
        if (_returning == true && collision.CompareTag("Enemy")){
            Instantiate(explosionEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(_clip, gameObject.transform.position);
        }       
    }
    public void AddDamage()
    {
        _returning = true;
    }
}       