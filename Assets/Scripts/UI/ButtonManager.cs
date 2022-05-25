using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator fadeAnim;

    void Start()
    {
        fadeAnim = GameObject.Find("Black").GetComponent<Animator>();
    }

    public void FadeToBlack()
    {
        fadeAnim.Play("fadeToBlack");
    }

    public void PlayGame() //called in fade to black animation keyframe
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("ControlScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
