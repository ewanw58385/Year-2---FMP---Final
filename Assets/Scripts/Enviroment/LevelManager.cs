using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
