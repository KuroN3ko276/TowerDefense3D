using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;  
    public GameObject buildEffect;
    public GameObject sellEffect;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public TurretUI turretUI;
    
    public bool CanBuild { get { return turretToBuild != null;}}
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;}}

    private void Awake() {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in screen!!");
        }
        instance = this;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public void SelectNode(Node node)
    {
        if(selectedNode ==node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        turretUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
