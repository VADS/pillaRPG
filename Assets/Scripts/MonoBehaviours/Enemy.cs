﻿using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    float hitPoints;
    public int damageStrength;
    Coroutine damageCoroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.damageCharacter(damageStrength, 1.0f));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    public override IEnumerator damageCharacter(int damage, float interval)
    {
        while(true)
        {
            hitPoints -= damage;

            if (hitPoints <= float.Epsilon)
            {
                killCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void resetCharacter()
    {
        hitPoints = startingHitPoints;
    }

    private void OnEnable()
    {
        resetCharacter();
    }
}