using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{
    [Header ("Pools")]
    [SerializeField] private IntReference WoodPool;
    [SerializeField] private IntReference WaterPool;
    [SerializeField] private IntReference EnergyPool;
    [Header ("Refills")]
    [SerializeField] private IntReference WoodGenerated;
    [SerializeField] private IntReference WaterGenerated;
    [SerializeField] private IntReference EnergyGenerated;
    [SerializeField] private GameEvent PoolRecharged;
    [SerializeField] private Vector3Reference PersonPosition;
    [SerializeField] private GameObject SpawnerPoint;
    [SerializeField] private Animator zoneAnimator;
    private bool zoneWithResource;
    private bool playerInside;

    private void Start()
    {
        playerInside = false;
        zoneWithResource = true;
        zoneAnimator.SetBool(Global.ZONEONANIMATION,true);

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
        zoneAnimator.SetBool(Global.ZONEONANIMATION,true);
    }

    private void RechargePool()
    {
        WoodPool.Value += WoodGenerated.Value;
        WaterPool.Value += WaterGenerated.Value;
        EnergyPool.Value += EnergyGenerated.Value;
        zoneWithResource = false;
        zoneAnimator.SetBool(Global.ZONEONANIMATION,false);
        PersonPosition.Value = SpawnerPoint.transform.position;
        PoolRecharged.Raise();
    }
}
