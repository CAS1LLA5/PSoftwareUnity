using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPlayer : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer _renderer;
    void Awake()
    {
        //_transform = GetComponent<Transform>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawn = this.transform.position;
        
    }
    public void Restartplayer()
    {
        player.transform.position = this.transform.position;
        player.SetActive(true);
        _renderer.color = Color.white;
    }
}