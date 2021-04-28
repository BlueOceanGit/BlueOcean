using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D[] basura;
    public bool spawning = false;
    private Vector2 Ypos;
    public Vector2 originPoint;
    public Vector2 endPoint;
    public float speed = 3f;
    public float delay = 1.5f;
    public float minDelay = 0.7f;

    public Button startButton;
    public Image infoImage;
    public Text infoText;

    //Para poder mover el fondp
    public Movimientofondo VelocidadDelFondo;


    public string[] fishInfo = new string[] { "", 
    "",
        "Sdan con las mascarillas y mueren asfixiados", "Páramo "};
    public string[] turtleInfo = new string[] { "Las bolsas de plástico presentes en el océano son una trampa mortal para las tortugas, pues estas confunden las mismas con medusas, una de sus comidas más habituales. Al intentar ingerir estas bolsas, el intestino de la tortuga puede llegar a bloquearse, lo que puede provocar la muerte de la misma por desnutrición.",
        "El aumento de la temperatura en el mar provoca que nazcan más tortugas hembra que macho, lo que dificulta su reproducción", "Se estima que las desde 2020 más de un billón y medio de mascarillas han llegado al océano, lo cual supone un grave problema para todo tipo de animales marítimos, pues estos se enredan con las mascarillas y mueren asfixiados ", "Páramo " };
    public string[] dolphinInfo = new string[] { "Los plásticos que flotan en el océano pueden provocar que los delfines que se los comen se mueran de hambre, pues sus estómagos se llenan de desechos y dejan de comer y cazar comida real",
    "Muchas especies de delfines se encuentran en peligro de extinción debido a las redes de enmalle, que al quedar enredados en ellas pueden llegar a perder extremidades completas. Además, ciertos delfines de río también se encuentran en peligro de extinción por la construcción de presas y debido a la contaminación que generan en ríos ciertas empresas",
        "Se estima que las desde 2020 más de un billón y medio de mascarillas han llegado al océano, lo cual supone un grave problema para todo tipo de animales marítimos, pues estos se enredan con las mascarillas y mueren asfixiados", "Páramo " };
    public string[] sealInfo = new string[] { "Tierras del ", "Abismo del ", "Gruta del ", "Páramo " };

    public string[] winInfo = new string[] {};

    public GameObject[] animals;
    private GameObject fishInstance;
    public Vector2 spawnPos;

   


    void Awake()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(true);
        infoImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (spawning == true)
        {
            StartCoroutine(spawnDelay());
        }
    }

    public void Playing()
    {
        startButton.gameObject.SetActive(false);
        spawning = true;
        VelocidadDelFondo.velocidad = 1;
        fishInstance = (GameObject)Instantiate(animals[Random.Range(0, animals.Length)], spawnPos, Quaternion.identity);
        
    }

    IEnumerator spawnDelay()
    {
        spawning = false;
        yield return new WaitForSeconds(delay);
        Rigidbody2D basuraInstancia = (Rigidbody2D)Instantiate(basura[Random.Range(0, basura.Length)], originPoint, Quaternion.identity);
        basuraInstancia.velocity = endPoint * speed;
        if (delay > minDelay)
        {
            delay -= 0.05f;
            if (delay < minDelay)
            {
                delay = minDelay;
            }
        }
        spawning = true;
    }

    public void ShowInfo()
    {
        Time.timeScale = 0;
        if (fishInstance.tag == "Dolphin")
        {
            int animalText = Random.Range(0, dolphinInfo.Length);
            infoText.text = dolphinInfo[animalText] +".";
            infoImage.gameObject.SetActive(true);
        }
        else if (fishInstance.tag == "Turtle")
        {
            int animalText = Random.Range(0, turtleInfo.Length);
            infoText.text = turtleInfo[animalText] + ".";
            infoImage.gameObject.SetActive(true);
        }
        else if (fishInstance.tag == "Fish")
        {
            int animalText = Random.Range(0, fishInfo.Length);
            infoText.text = fishInfo[animalText] + ".";
            infoImage.gameObject.SetActive(true);
        }
        else
        {
            int animalText = Random.Range(0, sealInfo.Length);
            infoText.text = sealInfo[animalText] + ".";
            infoImage.gameObject.SetActive(true);

        }


    }

    public void Return()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}
