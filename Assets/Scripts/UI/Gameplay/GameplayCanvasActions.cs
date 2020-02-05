using UnityEngine;
using TMPro;

public class GameplayCanvasActions : MonoBehaviour
{
    [SerializeField] private IntReference WoodPool;
    [SerializeField] private IntReference WaterPool;
    [SerializeField] private IntReference EnergyPool;
    [SerializeField] private TextMeshProUGUI woodPoolText;
    [SerializeField] private TextMeshProUGUI waterPoolText;
    [SerializeField] private TextMeshProUGUI energyPoolText;
    
    private void Start()
    {
        UpdatePools();
    }

    public void UpdatePools()
    {
        woodPoolText.text = string.Format("{0}",WoodPool.Value);
        waterPoolText.text = string.Format("{0}",WaterPool.Value);
        energyPoolText.text = string.Format("{0}",EnergyPool.Value);
    }
}
