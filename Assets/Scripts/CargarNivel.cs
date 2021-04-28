using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{


    //Metodo para cargar la escena
    public void LoadScene(string nombreEscena)
    {

        SceneManager.LoadScene(nombreEscena);

    }


    
}
