using TMPro;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour
{
    [Header ("Pools")]
    [SerializeField] private IntReference WoodPool;
    [SerializeField] private IntReference WaterPool;
    [SerializeField] private IntReference EnergyPool;
    [Header ("Needs")]
    [SerializeField] private IntReference WoodNeeded;
    [SerializeField] private IntReference WaterNeeded;
    [SerializeField] private IntReference EnergyNeeded;
    [Header("Canvas")]
    [SerializeField] private GameObject BridgeCanvas;
    [SerializeField] private GameObject WoodImage;
    [SerializeField] private TextMeshProUGUI WoodText;
    [SerializeField] private GameObject WaterImage;
    [SerializeField] private TextMeshProUGUI WaterText;
    [SerializeField] private GameObject EnergyImage;
    [SerializeField] private TextMeshProUGUI EnergyText;
    [Header("Internal")]
    [SerializeField] private GameEvent BridgeRepaired;
    [SerializeField] private Collider2D otherCollider;
    [SerializeField] private SpriteRenderer bridgeSpriteRenderer;
    [SerializeField] private SpriteRenderer SuperiorBbridgeSpriteRenderer;
    [SerializeField] private Sprite bridgeDestroyedSprite;
    [SerializeField] private Sprite bridgeRepairedSprite;

    [SerializeField] private GameObject fire;

    private bool playerInside;
    private bool thisZoneIsRepaired;

    private void Start()
    {
        bridgeSpriteRenderer.sprite = bridgeDestroyedSprite;
        if (!gameObject.tag.Equals(Global.BRIDGETAG))
            SuperiorBbridgeSpriteRenderer.sprite = bridgeDestroyedSprite;
        BuildCanvas();
    }

    private void BuildCanvas()
    {
        if (WoodNeeded.Value > 0)
        {
            WoodImage.SetActive(true);
            WoodText.text = WoodNeeded.Value.ToString();
        }
        else
        {
            WoodImage.SetActive(false);
        }

        if (WaterNeeded.Value > 0)
        {
            WaterImage.SetActive(true);
            WaterText.text = WaterNeeded.Value.ToString();
        }
        else
        {
            WaterImage.SetActive(false);
        }

        if (EnergyNeeded.Value > 0)
        {
            EnergyImage.SetActive(true);
            EnergyText.text = EnergyNeeded.Value.ToString();
        }
        else
        {
            EnergyImage.SetActive(false);
        }

        BridgeCanvas.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG) && !thisZoneIsRepaired)
        {
            BridgeCanvas.SetActive(true);
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Global.PLAYERTAG) && !thisZoneIsRepaired)
        {
            BridgeCanvas.SetActive(false);
            playerInside = false;
        }
    }

    public void RepairToolTriggered()
    {
        if (playerInside && otherCollider != null && !thisZoneIsRepaired)
            RepairBridge(otherCollider);
    }

    private void RepairBridge(Collider2D coll)
    {
        if (WoodNeeded.Value <= WoodPool.Value && WaterNeeded.Value <= WaterPool.Value && EnergyNeeded.Value <= EnergyPool.Value)
        {
            WoodPool.Value -= WoodNeeded.Value;
            WaterPool.Value -= WaterNeeded.Value;
            EnergyPool.Value -= EnergyNeeded.Value;
            //Disparar Animación
            coll.enabled = false;
            bridgeSpriteRenderer.sprite = bridgeRepairedSprite;

            if (fire != null) fire.SetActive(false);

            if (!gameObject.tag.Equals(Global.BRIDGETAG))
                SuperiorBbridgeSpriteRenderer.sprite = bridgeRepairedSprite;
            thisZoneIsRepaired = true;
            BridgeCanvas.SetActive(false);
            BridgeRepaired.Raise();
        }
    }
}
