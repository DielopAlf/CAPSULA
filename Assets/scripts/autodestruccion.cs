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
    // public ParticleSystem sistemaParticulas;
        
    
    



    void Start()
    {
        Aparecer();
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
           
        }
        else
        {
            desaparecer();
        }
    }
    public void Aparecer()
    {
        //sistemaParticulas.Play();
        //sistemaParticulas.Stop();
        malla.SetActive(true);
        gameObject.transform.localScale = Vector3.one;
        temporizador = Random.Range(tiempominimo, tiempoMaximo);
        BarraDeVida.maxValue= temporizador;
        estaActiva= true;
        BarraDeVida.gameObject.SetActive(true);
        tiempo.gameObject.SetActive(true);
        //particulas.SetActive(false);

    }
    void Activar()
    {
        //Instantiate(particulas, gameObject.transform.position, Quaternion.identity);
        //if (particulas.activeSelf == false)
       // {
            //particulas.SetActive(true);

       // }

    }
    public void desaparecer()
    {
        if (estaActiva == true)
        {
            estaActiva = false;
//            malla.SetActive(false);
            BarraDeVida.gameObject.SetActive(false);
            tiempo.gameObject.SetActive(false);

            particulas.SetActive (true);
 
            LeanTween.scale(gameObject, Vector3.zero, 1.0f).setOnComplete(()=>{
                malla.SetActive(false);
                particulas.SetActive(false);

                StartCoroutine(Resetearcapsula());
            });



            

        }
    }
   


    public IEnumerator Resetearcapsula()
    {
        yield return new WaitForSeconds(Random.Range(1f, 6f));
        Aparecer();
        Instantiate(particulas, gameObject.transform.position, Quaternion.identity);
        //LeanTween.scale(gameObject, Vector3.zero, 0.6f).setOnComplete(Activar);

    }
}
