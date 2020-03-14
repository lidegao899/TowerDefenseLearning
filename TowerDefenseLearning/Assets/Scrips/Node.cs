using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    public Color notEnoughColor;

    private Color startColor;

    private Renderer rend;

    [Header("Optional")]
    public TurretBlueprint turretBlueprint = null;

    [HideInInspector]
    private GameObject currentTurret;

    private bool isUpgraded = false;

    public Vector3 positionOffset;

    private BuildManager buildManager;

    public NodeUI nodeUI;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        turretBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (turretBlueprint != null)
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turretBlueprint != null)
        {
            buildManager.SelectedNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (!buildManager.HasMoney)
        {
            return;
        }

        buildTurret();
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset;
    }

    private void buildTurret()
    {
        turretBlueprint = buildManager.GetTurretToBuild();

        if (turretBlueprint == null)
        {
            return;
        }

        PlayerStats.Money -= turretBlueprint.price;
        Debug.Log("money:" + PlayerStats.Money);
        currentTurret = Instantiate(turretBlueprint.prefab, GetBuildPos(), Quaternion.identity);

        GameObject effect = Instantiate(turretBlueprint.buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void upgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradePrice)
        {
            Debug.Log("not enough money!");
            return;
        }

        if (isUpgraded)
        {
            return;
        }

        isUpgraded = true;
        PlayerStats.Money -= turretBlueprint.upgradePrice;
        Destroy(currentTurret);

        GameObject turret = Instantiate(turretBlueprint.prefabUpgraded, GetBuildPos(), Quaternion.identity);

        GameObject effect = Instantiate(turretBlueprint.buildEffect, GetBuildPos(), Quaternion.identity);

        Debug.Log("turret upgraded!");
    }

    public void SellTurret()
    {
        if (currentTurret == null)
        {
            return;
        }

        PlayerStats.Money += turretBlueprint.sellPrice;
        Destroy(currentTurret);

        // sell effect
        GameObject effect = Instantiate(turretBlueprint.buildEffect, GetBuildPos(), Quaternion.identity);

        isUpgraded = false;
        turretBlueprint = null;
        currentTurret = null;
    }
}