using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedidorForça : MonoBehaviour
{
    [SerializeField] Slider sliderMovement;
    [SerializeField] float[] forcePower;
    [SerializeField] bool partidaOficial;
    [SerializeField] int direcao;
    [SerializeField] float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        if(ManagerGame.Instance.TipoPartida.ToString()== "Jogo")
        {
            partidaOficial = true;
            direcao = 1;
            velocidade = 0.7f * ManagerGame.Instance.Dificuldade;
        }
        else
        {
            partidaOficial = false;
            direcao = 0;
            velocidade = 0;
        }

    }
    void Update()
    {
        if (partidaOficial)
        {
            sliderMovement.value += velocidade * direcao*Time.deltaTime;
            VerificarMudancaDirecao();
        }

    }
    void VerificarMudancaDirecao()
    {
        if (direcao == 1)
        {
            if (sliderMovement.value==1)
            {
                direcao = -1;
            }
        }
        else
        {
            if (sliderMovement.value == 0)
            {
                direcao = 1;
                
            }
        }
    }
    float DeterminarPercentualPerdidoForca()
    {
        Debug.Log("Slider Value"+sliderMovement.value);
        float distanceCenter = Mathf.Abs(0.5f - sliderMovement.value);
        Debug.Log("Distance Center: "+ distanceCenter);
        float percentual = distanceCenter * 100 / 0.5f;
        Debug.Log("distancia meio: " + percentual);

        return percentual;
    }


    public int DeterminandoVelocidade()
    {
        return Mathf.RoundToInt(forcePower[1] - DeterminarPercentualPerdidoForca() / 100 * (forcePower[1] - forcePower[0]));
    }
}
