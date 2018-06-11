﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiMovement : MonoBehaviour {

    bool whichWay = true;
    public float speed;
    private Animator animator;
    public Slider healthBar;
    private bool invulnerable = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("StopRight") && whichWay == true) {
            Debug.Log("going left");
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            whichWay = false;

        }
        if (collision.gameObject.name.Equals("StopLeft") && whichWay == false)
        {
            Debug.Log("going right");
            gameObject.transform.Rotate(new Vector3(0, -180, 0));
            whichWay = true;

        }
        if (collision.gameObject.name.Equals("CharacterRobotBoy")) {
            if (invulnerable != true) {
                if (healthBar.value != 0) {
                    healthBar.value -= 0.5F;
                    StartCoroutine(playerIsInvulnerableForFewSeconds());
                } else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
    IEnumerator playerIsInvulnerableForFewSeconds() {
        invulnerable = true;
        yield return new WaitForSeconds(1.5F);
        invulnerable = false;
    }

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update() {
        animator.SetTrigger("skill_1");
        if (whichWay == true) {      
            gameObject.transform.Translate(new Vector3(0.04F, 0, 0));
        }
        if (whichWay == false) {

            gameObject.transform.Translate(new Vector3(0.04F, 0, 0));
        }
            


    }
}
