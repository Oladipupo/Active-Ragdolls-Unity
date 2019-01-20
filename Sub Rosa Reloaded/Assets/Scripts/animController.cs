using UnityEngine;
using System.Collections;

public class animController : MonoBehaviour {

   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("w"))
        {
            anim.Play("Walk");
        }
        else if (Input.GetKeyUp("w"))  {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown("s")){
            anim.Play("Walkback");
        }
        else if (Input.GetKeyUp("s"))  {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.Play("JumpHold");
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            anim.Play("JumpRel");
        }
    }
}﻿