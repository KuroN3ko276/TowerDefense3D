using UnityEngine;

public class CameraController : MonoBehaviour
{
    //private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThichness = 10f;
    public float scrollSpeed = 5f;
    // Giới hạn cho trục Y
    public float minY = 10f;
    public float maxY = 80f;

    // Giới hạn cho trục X
    public float minX = 20f; 
    public float maxX = 90f;  
    // Giới hạn cho trục Z
    public float minZ = -5f; 
    public float maxZ = 70f;  

    void Update()
    {
        if(GameManager.isGameOver)
        {
            this.enabled = false;
            return;
        }
        // if(Input.GetKeyDown(KeyCode.Escape))
        //     doMovement = !doMovement;
        // if(!doMovement)
        //     return;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThichness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }   

        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThichness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        } 

        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThichness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThichness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos; // Cập nhật vị trí camera
    }
}