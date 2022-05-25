using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public Animator anim;

    [HideInInspector] public FinalBossCombatManager fbcm;

    public GameObject bossBar;
    [HideInInspector] public Animator bossBarFillAnim;
    [HideInInspector] public Animator bossBarBorderAnim;

    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponentInChildren<Animator>();
        fbcm = GameObject.Find("FinalBoss").GetComponent<FinalBossCombatManager>();

        bossBarFillAnim = bossBar.transform.GetChild(0).GetComponent<Animator>();
        bossBarBorderAnim = bossBar.transform.GetChild(1).GetComponent<Animator>();

        bossBar.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.Play("FbBlockAnim");
            bossBar.SetActive(true);

            fbcm.healthBar = GameObject.Find("Final Boss Health Bar").GetComponent<FinalBossHealthbarScript>(); //get instance of UI healthbar script
            fbcm.healthBar.SetMaxHealth(fbcm.bossHealth); //pass initial health (max health) as max health on slider

            //bossBarFillAnim.Play("BossBarFadeIn");
            bossBarBorderAnim.Play("BossBarFadeIn");

            if (bossBarBorderAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2f)
            {
                bossBarBorderAnim.SetTrigger("fadedIn"); //to return to a null state in Animator
            }

            
            if (bossBarFillAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2f)
            {
                bossBarFillAnim.SetTrigger("fadedIn");
            }
        }
    }
}
