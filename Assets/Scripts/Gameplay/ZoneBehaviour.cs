using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{
    [Header ("Pools")]
    [SerializeField]
    private IntReference WoodPool;
    [SerializeField]
    private IntReference WaterPool;
    [SerializeField]
    private IntReference EnergyPool;
    [Header ("Refills")]
    [SerializeField]
    private IntReference WoodGenerated;
    [SerializeField]
    private IntReference WaterGenerated;
    [SerializeField]
    private IntReference EnergyGenerated;
    [SerializeField]
    private GameEvent PoolRecharged;
    private bool zoneWithResource;
    private bool playerInside;

    private void Start()
    {
        playerInside = false;
        zoneWithResource = true;
    }

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

    public void ActionTriggered()
    {
        if (playerInside && zoneWithResource)
            RechargePool();
    }

    public void ZoneRechargeResource()
    {
        zoneWithResource = true;
    }

    private void RechargePool()
    {
        WoodPool.Value += WoodGenerated.Value;
        WaterPool.Value += WaterGenerated.Value;
        EnergyPool.Value += EnergyGenerated.Value;
        zoneWithResource = false;
        PoolRecharged.Raise();
    }
}
