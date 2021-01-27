using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float m_sensitivity = 100f; // mouse sensitivity
    public float m_clampAngle = 90f; // this limits our look up 
    public Transform m_playerObject; // Store player container
    public Transform m_camera; // Store the camera transform

    private Vector2 m_mousePos; // store mouse position

    private float m_xRotation = 0f; // final loop up rotation value

   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock our cursor to the center of screen
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // GetMousePos(); //get mouse position
        ClampUpRotation();              // FixXRotation();//clamp the look up
        LookAt();// look at mouse position
        
    }

    //Get mouse position
    private void GetMousePos()
    {
        m_mousePos.x = Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        m_mousePos.y = Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;
    }
    //FixXRotation - means that we can clamp ou our look up function
    private void ClampUpRotation()
    {
        m_xRotation -= m_mousePos.y;
        m_xRotation = Mathf.Clamp(m_xRotation, -m_clampAngle, m_clampAngle);

    }
 
    //Look at mouse pos
    private void LookAt()
    {
        m_camera.transform.localRotation = Quaternion.Euler(m_xRotation, 0, 0);
        m_playerObject.Rotate(Vector3.up * m_mousePos.x);             
    }
}
