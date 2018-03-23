﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    Animator anim;
    private Rigidbody2D characterBody;
    private SpriteRenderer characterSprite;
    public int characterSpeed = 3;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("AnimState", 0);
        anim.SetBool("isMoving", false);
        characterBody = GetComponent<Rigidbody2D>();
        characterSprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        checkDepth();

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("AnimState", 0);
            anim.SetBool("isMoving", true);
            characterBody.velocity = Vector2.right * characterSpeed; // x = 1, y = 0

        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("AnimState", 1);
            anim.SetBool("isMoving", true);
            characterBody.velocity = Vector2.up * characterSpeed ; // x = 0, y = 1
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("AnimState", 2);
            anim.SetBool("isMoving", true);
            characterBody.velocity = Vector2.left * characterSpeed; // x = -1, y = 0
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("AnimState", 3);
            anim.SetBool("isMoving", true);
            characterBody.velocity = Vector2.down * characterSpeed; // x = 0, y = -1
        }
        else
        {
            characterBody.velocity = Vector2.zero; // x = 0, y = 0 
            anim.SetBool("isMoving", false);
        }
    }

    private void checkDepth()
    {
        if (transform.position.y < 0) characterSprite.sortingOrder = 1;
        else if (transform.position.y >= 0) characterSprite.sortingOrder = 0;
    }
}
