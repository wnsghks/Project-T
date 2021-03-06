﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{
    [SerializeField] 
    protected Animator anim { get; private set; }

    [SerializeField]
    protected Rigidbody2D rigidbody;
    
    public Status damage { get; protected set; } = new Status();
    protected Status speed = new Status();
    protected Status health = new Status();
    protected float curHealth;

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();

        damage.baseValue = 10.0f;
        speed.baseValue = 100.0f;
        health.baseValue = 100.0f;
        OnHealthRecovery();
    }

    protected void OnHealthRecovery( int _percent = 100 )
    {
        curHealth += health.Value * ( Mathf.Clamp( _percent, 0, 100 ) * 0.01f );

        if ( health.Value < curHealth )
        {
            curHealth = health.Value;
        }
    }

    protected void InverseAxisX( Vector2 _pos )
    {
        if ( transform.position.x - _pos.x < 0.0f )
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
