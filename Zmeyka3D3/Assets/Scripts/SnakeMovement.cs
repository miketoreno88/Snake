using TMPro;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;

    public int Length = 1;

    //public TextMeshPro PointsText;

    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private SnakeTail componentSnakeTail;

    private Vector3 touchLastPos;
    private float sidewaysSpeed;
    
    public Transform eyes; 

    private void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<SnakeTail>();

        for (int i = 0; i < Length; i++) 
        {
            componentSnakeTail.AddCircle();
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Vector3) mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);

                 
            if (delta.x < 0)
            {
                eyes.transform.rotation= Quaternion.Lerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0, -30, 0), delta.x * -80f);
            }
        
            if (delta.x > 0)
            {
                eyes.transform.rotation= Quaternion.Lerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0, 30, 0), delta.x * 80f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4)
        {
            sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        }

        componentRigidbody.velocity = new Vector3 (sidewaysSpeed * 15, 0, ForwardSpeed);

        if (transform.position.x > 4f)
        {
            transform.position = new Vector3(4f, transform.position.y, transform.position.z);
            
        }
        if (transform.position.x < -4f)
        {
            transform.position = new Vector3(-4f, transform.position.y, transform.position.z);
        }
        sidewaysSpeed = 0;
    }

      public void BobySnake()
    {
        Length++;
        componentSnakeTail.AddCircle();
    }
}



