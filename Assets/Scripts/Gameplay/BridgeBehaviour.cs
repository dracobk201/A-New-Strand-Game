﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour
{
    [Header ("Pools")]
    [SerializeField]
    private IntReference WoodPool;
    [SerializeField]
    private IntReference WaterPool;
    [SerializeField]
    private IntReference EnergyPool;
    [Header ("Needs")]
    [SerializeField]
    private IntReference WoodNeeded;
    [SerializeField]
    private IntReference WaterNeeded;
    [SerializeField]
    private IntReference EnergyNeeded;
    [Header("Internal")]
    [SerializeField]
    private GameEvent BridgeRepaired;
    [SerializeField]
    private Collider2D otherCollider;
    [SerializeField]
    private SpriteRenderer bridgeSpriteRenderer;
    private bool playerInside;
    private bool thisZoneIsRepaired;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG))
            playerInside = false;
    }

    public void RepairToolTriggered()
    {
        if (playerInside && otherCollider != null && !thisZoneIsRepaired)
            RepairBridge(otherCollider);
    }

    private void RepairBridge(Collider2D coll)
    {
        if (WoodNeeded.Value <= WoodPool.Value && 
            WaterNeeded.Value <= WaterPool.Value && 
            EnergyNeeded.Value <= EnergyPool.Value)
        {
            WoodPool.Value -= WoodNeeded.Value;
            WaterPool.Value -= WaterNeeded.Value;
            EnergyPool.Value -= EnergyNeeded.Value;
            //Disparar Animación
            coll.enabled = false;
            bridgeSpriteRenderer.color = Color.green;
            thisZoneIsRepaired = true;
            BridgeRepaired.Raise();
        }
    }
}