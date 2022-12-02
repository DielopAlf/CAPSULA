using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class autodestruccion : MonoBehaviour
{
    public float tiempominimo = 10;
    public float tiempoMaximo = 30;
    public Slider BarraDeVida;
    public TextMeshProUGUI tiempo;
    public GameObject malla;
    float temporizador;
    bool estaActiva;
    public GameObject particulas;
        
    
    



    void Start()
    {
        aparecer();
    }

    // Update is called once per frame
    void Update()
    {
        if (temporizador > 0f)
        {
            temporizador = temporizador - Time.deltaTime;
            Debug.Log(temporizador);
            BarraDeVida.value = temporizador;
            tiempo.text = temporizador.ToString("0.00");
            particulas.SetActive(true);
        }
        else
        {
            desaparecer();
        }
    }
    public void aparecer()
    {
        malla.SetActive(true);

        temporizador = Random.Range(tiempominimo, tiempoMaximo);
        BarraDeVida.maxValue= temporizador;
        estaActiva= true;
        BarraDeVida.gameObject.SetActive(true);
        tiempo.gameObject.SetActive(true);
        particulas.SetActive(false);
    }
    public void desaparecer()
    { 
        if(estaActiva == true)
        {
            estaActiva = false;
            malla.SetActive(false);
            BarraDeVida.gameObject.SetActive(false);
            tiempo.gameObject.SetActive(false);
            LeanTween.scale(gameObject, Vector3.one * 1.5f, 0.0f);
            particulas.SetActive(true);


            StartCoroutine(Resetearcapsula());


        }


    }


    public IEnumerator Resetearcapsula()
    {
        yield return new WaitForSeconds(Random.Range(1f, 6f));
        aparecer();
        LeanTween.scale(gameObject, Vector3.one * 0.0f, 1.5f);
        particulas.SetActive(true);
    }

}
