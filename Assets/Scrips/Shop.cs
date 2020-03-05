using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bulidManaget;

    public TurretBlueprint StandardTurret;
    public TurretBlueprint LaserTurret;
    public TurretBlueprint MissileTurret;

    // Start is called before the first frame update
    void Start()
    {
        bulidManaget = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Sand");
        bulidManaget.SetTurretToBuild(StandardTurret);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile");
        bulidManaget.SetTurretToBuild(MissileTurret);
    }
    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser");
        bulidManaget.SetTurretToBuild(LaserTurret);
    }
}
