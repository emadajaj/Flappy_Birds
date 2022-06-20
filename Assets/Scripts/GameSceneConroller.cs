using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneConroller : MonoBehaviour
{
    public GameObject player;
    public Camera MainCamera;
    public GameObject[] blockSecne;
    public GameObject gameImage;
    public GameObject gameButtonPlayAgine;
    public GameObject HighScoreText;

    private float gamePointer;
    private float SaveSpawoninArea = 20;
    private bool death;
    PlayerMovement d;
 



    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
           
            
            MainCamera.transform.position = new Vector3(
                player.transform.position.x + 8,
                MainCamera.transform.position.y,
                MainCamera.transform.position.z);
           // gameTeaxt.text = "Score : " + Mathf.Floor(player.transform.position.x + 10);
         
         
        }
        else
        {

          

              
                gameImage.SetActive(true);
                gameButtonPlayAgine.SetActive(true);
               HighScoreText.SetActive(true);
            
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                if (!death)
                {
                   
                    death = true;
                  //  gameTeaxt.text += "\nGAMEOVER Tap R to Restart ";
                }
            }
        
            while (player != null && gamePointer < player.transform.position.x + SaveSpawoninArea)
            {
                int blockIndex = Random.Range(0, blockSecne.Length);
                GameObject blockObject = Instantiate(blockSecne[blockIndex]);
                blockObject.transform.SetParent(this.transform);
                Block block = blockObject.GetComponent<Block>();
                blockObject.transform.position = new Vector2(gamePointer + block.size/2, -6.3f);
                gamePointer += block.size;
            }
        
    }
}