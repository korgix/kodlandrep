using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void Save()
    {
        Vector3 vector = player.transform.position;
        int health = player.GetComponent<PlayerController>().GetHealth();
        int crystal = player.GetComponent<PlayerMove>().GetCrystal();
        if (health > 0)
        {
            PlayerPrefs.SetFloat("playerX", vector.x);
            PlayerPrefs.SetFloat("playerY", vector.y);
            PlayerPrefs.SetFloat("playerZ", vector.z);
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.SetInt("crystal", crystal);
            PlayerPrefs.Save();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ObAuthor()
    {
        SceneManager.LoadScene(2);
    }
}
