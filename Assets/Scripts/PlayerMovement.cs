using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce = 20;
    public float MoveSpeed = 1;
    public Rigidbody2D r;
    public Text ScorePoint;
    public Text HighPoint;
    Sound s;
    bool isDeath;
    public int highScore;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        HighPoint.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
        FindObjectOfType<SoundManeger>().playSound("gameSound");
        r = GetComponent<Rigidbody2D>();
        r.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                FindObjectOfType<SoundManeger>().playSound("Jump");
                r.gravityScale = 1;
                r.AddForce(new Vector2(0, JumpForce));



            }
            r.velocity = new Vector2(MoveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
          /*
            PlayerPrefs.SetInt("High",highScore);
            HighPoint.text = "High : " + PlayerPrefs.GetInt("High").ToString();
            PlayerPrefs.Save();*/
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Wall")
        {
           
            FindObjectOfType<SoundManeger>().StopSound("gameSound");
            FindObjectOfType<SoundManeger>().playSound("Die");
            GameObject.Destroy(this.gameObject);

           
          
           
        
    }
        if (c.tag == "Point")
        {
            points = points + 1;
            ScorePoint.text = points.ToString();
            if (points > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", points);
                HighPoint.text ="High Score : " + points.ToString();
            }
        }
    }
}
