using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public float Yincriment;

    public float speed;
    public float maxHieght;
    public float minHieght;

    public int health = 3;

    public GameObject effect;
    public Animator camAnim;

    public Text healthDisplay;

    public GameObject gameOver;

    public AudioClip gameOverSound;

    public GameObject camra;

    void Update()
    {
        healthDisplay.text = health.ToString();

        //Reload the Scene when player health zero or less

        if(health <= 0)
        {

            // Disable the Spawner Component than Obstacles will not instiate

            FindObjectOfType<Spawner>().GetComponent<Spawner>().enabled=false;

           
           

            camra.GetComponent<AudioSource>().Stop();

            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            gameOver.SetActive(true);

            
            

            Destroy(gameObject);
        }

        //It smoothly move character
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow ) && transform.position.y < maxHieght)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect,transform.position,Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincriment);
            //transform.position = targetPos;             //It Snap from one position to other
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHieght)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincriment);
            //transform.position = targetPos;
        }
    }
}
