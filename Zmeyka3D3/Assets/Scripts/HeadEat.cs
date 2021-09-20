using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HeadEat : MonoBehaviour
{
    float EatPiople;
    float Piople;
    public GameObject Snake;
    private SnakeMovement _actionTarget;
    public GameObject deamontguiText;
    public GameObject skillguiText;

    int deamond = 0;

public GameObject Menu;
     void Start()
     {
                     
     }
      void OnTriggerStay (Collider col) // столкновение с объектами
    {

        if(col.tag == "Bot")
        
        {
            if (gameObject.GetComponent<MeshRenderer>().material.color == col.GetComponent<SkinnedMeshRenderer>().material.color)
            {
                Destroy(col.gameObject);
                // Если змейка съедает 3 людей, она увеличивается на одну едилицу
                EatPiople = EatPiople +1;
                Piople = Piople +1;

                skillguiText.GetComponent<TextMeshProUGUI>().text = Piople.ToString();

                
                if (EatPiople == 3)
                {
                    EatPiople = 0;

                    _actionTarget = Snake.GetComponent<SnakeMovement>();
                    _actionTarget.BobySnake();
                }

                Destroy(col.gameObject);

            }
            else
            {
                DestroySnake();               
            }


        }

        if(col.tag == "deamond")
        {
            Destroy(col.gameObject);


            deamond = deamond + 1;
            deamontguiText.GetComponent<TextMeshProUGUI>().text = deamond.ToString();

        }

        if(col.tag == "boomb")
        {
            DestroySnake();
    
        }

        if(col.tag == "Finish")
        {
            SceneManager.LoadScene (0);
        }



        
    }

    void DestroySnake()
    {
        Destroy(Snake.gameObject);
        Time.timeScale = 0;
        Menu.SetActive (true);
        SceneManager.LoadScene (0);
    }



}
