using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TMPro.TextMeshProUGUI CoinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin")) {
            // Debug.Log("Collect Coin");
            AddCoin();
            Destroy(other.gameObject);

        }
        else if(other.CompareTag("End"))
        {
           // Debug.Log("Congrats");
            playerController.runningSpeed = 0;

            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self); //At the end of the game player turns his face to user.
            EndPanel.SetActive(true);

            if(score >= maxScore)
            {
               // Debug.Log("You win");
                PlayerAnim.SetBool("win",true);
            }
            else
            {
                //Debug.Log("You Lost");
                PlayerAnim.SetBool("lose", true);

            }
        }
        // end bölgesine ulaþtýðýnda hýzý sýfýrlar.
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touched Obstacle... ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
