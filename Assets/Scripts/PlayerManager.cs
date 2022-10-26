using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]private GameObject panel;
    [SerializeField] private Text scoreText,panelText;
    private int score = 0;


    private void Update()
    {
        if (score ==5)
        {
            panel.SetActive(true);
            panelText.text = "You Win!!!";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Money")
        {
 
                Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
            
           
        }
        else if(other.gameObject.tag=="Obstacles")
        {
            Destroy(gameObject);
            panel.SetActive(true);
            panelText.text = "You Lose!!!";

        }
    }
}
