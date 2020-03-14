using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public GameObject BuildTurret(Node node)
    {
        if (!CanBuild)
        {
            return null;
        }

        if (!HasMoney)
        {
            return null;
        }

        PlayerStats.Money -= turretToBuild.price;
        Debug.Log("money:" + PlayerStats.Money);
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPos(), Quaternion.identity);

        GameObject effect = Instantiate(turretToBuild.buildEffect, node.GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);
        return turret;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectedNode(Node node)
    {
        if (selectedNode == node)
        {
            DeSelectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(selectedNode);
    }

    public void DeSelectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}