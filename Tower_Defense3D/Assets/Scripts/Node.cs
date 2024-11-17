using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Optinal")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        { 
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Can't build there !!! - TODO: Display on screen");
            return;
        }
        //Build a turret
        buildManager.BuildTurretOn(this);
    }
    private void OnMouseEnter() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        GetComponent<Renderer>().material.color = hoverColor;  
    }

    private void OnMouseExit() 
    {
        rend.material.color = startColor;    
    }
}
