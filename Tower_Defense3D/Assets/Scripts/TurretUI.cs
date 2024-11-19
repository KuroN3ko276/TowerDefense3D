using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    public GameObject ui;
    public TMP_Text upgradeCost;
    public TMP_Text sellAmount;
    public Button upgradeButton;
    private Node target;
    public void SetTarget(Node node)
    {
        this.target = node;
        transform.position = target.GetBuildPosition();
        if(!target.isUpgrade)
        {
            upgradeCost.text = "$"+target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        } else{
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$"+target.turretBlueprint.GetSellAmount();
        
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
