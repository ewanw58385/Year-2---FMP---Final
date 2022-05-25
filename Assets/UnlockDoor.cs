using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : BaseItem
{
    public SpecialPlatform sp; //assigned in inspector
    public Animator lockAnim; //assigned in inspector
    public Animator fadeToWhite;
    public GameObject keyText;

    public override void Initialise()
    {
        base.Initialise();

        if (sp.keyPickedUp)
        {
            keyText.SetActive(true);

            lockAnim.Play("unlocked");

            InvokeRepeating("CheckForLockAnimation", 0f, 0.01f); //invoke because instantiate method is only called once
        }
    }

    public void CheckForLockAnimation()
    {
        if (lockAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            fadeToWhite.Play("fadeToWhite");
            Destroy(GameObject.FindWithTag("playerHealthbar"));
        }

        if (lockAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 4f)
        {
            SceneManager.LoadScene("RestartScene");
        }
    }
}
