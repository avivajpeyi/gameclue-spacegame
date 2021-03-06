﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedHoverMovement : MonoBehaviour
{
    public Vector3 targetCenterPosition;
    public float hoverRadius = 3f;
    public float speed = 1;
    private Rigidbody2D rb;
    private HoverMovement hoverMovement;

    void Awake()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        this.hoverMovement = this.gameObject.GetComponent<HoverMovement>();
        this.hoverMovement.enabled = false;
    }

    void Update()
    {
        if (!IsAtTarget())
        {
            Vector3 currentPosition = this.transform.position;
            Vector3 direction = targetCenterPosition - currentPosition;
            direction = direction.normalized;

            this.rb.velocity = direction * speed;
        }
        else
        {
            // Activate HoverMovement
            this.rb.velocity = Vector3.zero;
            hoverMovement.SetTargetPoint(targetCenterPosition);
            hoverMovement.SetTargetRadius(this.hoverRadius);

            this.enabled = false;
            hoverMovement.enabled = true;
 
        }
    }

    bool IsAtTarget()
    {
        return Vector3.Distance(this.rb.position, targetCenterPosition) <= hoverRadius;
    }
}
