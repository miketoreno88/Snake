using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    public GameObject Menu;
    public GameObject Panel;
    public GameObject Panel2;

    private void Start()
    {
        Time.timeScale = 0;
        Panel.SetActive (false);
        Panel2.SetActive (false);
    }

    private void Update()
    {
        if (Target != null) // камера следует за объектом
        {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z;
        transform.position = transformPosition; 
        }

    }

        public void Play()
    {
            Time.timeScale = 1;
            Menu.SetActive (false);
            Panel.SetActive (true);
            Panel2.SetActive (true);
    }
    public void Exit()
    {
        Application.Quit();    // закрыть приложение
    }
    
}
