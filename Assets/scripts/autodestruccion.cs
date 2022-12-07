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
        temporizador = Random.Range(tiempominimo, tiempoMaximo);
        BarraDeVida.maxValue= temporizador;
        estaActiva= true;
        BarraDeVida.gameObject.SetActive(true);
        tiempo.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (temporizador > 0f)
        {
            temporizador = temporizador - Time.deltaTime;
            //Debug.Log(temporizador);
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
    
        malla.SetActive(true);
        particulas.SetActive(true);

        LeanTween.scale(gameObject, Vector3.one, 1.0f).setOnComplete(()=>
        {
               
                particulas.SetActive(false);

        });
         
        temporizador = Random.Range(tiempominimo, tiempoMaximo);
        BarraDeVida.maxValue= temporizador;
        estaActiva= true;
        BarraDeVida.gameObject.SetActive(true);
        tiempo.gameObject.SetActive(true);
        

    }
   
    public void desaparecer()
    {
        if (estaActiva == true)
        {
            estaActiva = false;
            
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

    }
}
