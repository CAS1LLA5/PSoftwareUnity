using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{   
    public int score;
    //private EnemyPatrol _points;
    public int initialScore = 0;
    public TextMeshProUGUI scoreUI;
    private Collider2D _collider;
    private PlayerHealth _health;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        //_points = GetComponent<EnemyPatrol>();
        _health = GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        score = initialScore;
    }

    // Update is called once per frame
    void Update()
    {
        //score += Time.deltaTime;
        //scoreUI.text = score.ToString("0");
        scoreUI.text = "Score: " + score;
        /*if (Input.GetButtonDown("Fire2")){
            SubtractPoints();
        }*/
    }
    public void AddPoints(int amount)
    {
        score = score + amount;
    }
    public void RestertPoints()
    {
        score = score * 0;
    }
    /*public void SubtractPoints()
    {
        if(score >= 300){
            score = score - 300;
            Debug.Log("Tienes 300 puntos");
        } else if(score <=299){
            Debug.Log("No tienes 300 puntos");
        }
    }*/
}
