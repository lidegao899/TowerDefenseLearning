using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject ui;

    public Text sellPriceText;

    public Text upgradePriceText;

    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.transform.position;

        sellPriceText.text = "$" + target.turretBlueprint.sellPrice;

        upgradePriceText.text = "$" + target.turretBlueprint.upgradePrice;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.upgradeTurret();
        BuildManager.instance.DeSelectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeSelectNode();
    }
}
