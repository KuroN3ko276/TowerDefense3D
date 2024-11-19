using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public void SetTarget(Node node)
    {
        this.target = node;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
}
