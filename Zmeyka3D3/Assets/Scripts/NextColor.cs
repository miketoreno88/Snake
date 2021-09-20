using UnityEngine;

public class NextColor : MonoBehaviour
{
    // Start is called before the first frame update
      void OnTriggerStay (Collider col) 
    {
        if(col.tag == "NextColor")
        {
            gameObject.GetComponent<MeshRenderer>().material = col.GetComponent<MeshRenderer>().material;
        }
    }

}
