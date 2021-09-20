using UnityEngine;

public class DestroyPlusOne : MonoBehaviour
{
    private float moveSpeed = 50f;
    void Update()
    {
        transform.position += new Vector3 (0, moveSpeed * Time.deltaTime, 0);
        Destroy (gameObject, 0.5f); 
    }
}