using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public int P1Life;
    public int P2Life;

    public GameObject P1Wins;
    public GameObject P2Wins;

    public GameObject[] P1Sticks;
    public GameObject[] P2Sticks;

    public AudioSource hurtSound;

    public string mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Life <= 0)
        {
            player1.SetActive(false);
            P2Wins.SetActive(true);
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
            P1Wins.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R) && (P1Life <= 0 || P2Life <= 0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    public void HurtP1()
    {
        P1Life -= 1;

        for (int i = 0; i < P1Sticks.Length; i++)
        {
            if (P1Life > i)
            {
                P1Sticks[i].SetActive(true);
            } else
            {
                P1Sticks[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;

        for (int i = 0; i < P2Sticks.Length; i++)
        {
            if (P2Life > i)
            {
                P2Sticks[i].SetActive(true);
            }
            else
            {
                P2Sticks[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }
}
