﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBox : MonoBehaviour {

    public rotateBig Target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Target.playerOnPlatform = true;
        }
    }
}
