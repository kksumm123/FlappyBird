﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollX : MonoBehaviour
{
    public float speedX = -1;

    void Update()
    {
        transform.Translate(speedX * GameManager.instace.scrollSpeedMult * Time.deltaTime, 0, 0);
    }
}
