using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class medidorForça : MonoBehaviour
{
    [SerializeField]GameObject medidorObject;
    [SerializeField] float[] forcePower;
    [SerializeField] GameObject pontoMax;
    [SerializeField] GameObject pontoMinimo;
    [SerializeField] bool jogoSendoExecutado;
    [SerializeField] int direcao;
    [SerializeField] int velocidade;
    // Start is called before the first frame update
    void Start()
    {
        direcao = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (jogoSendoExecutado)
        {
            medidorObject.transform.localPosition= new Vector3(medidorObject.transform.localPosition.x, medidorObject.transform.localPosition.y + Time.deltaTime* velocidade * direcao, medidorObject.transform.localPosition.z);
            verificarMudancaDirecao();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Velocidade Bola: " + DeterminandoVelocidade());
            }
        }

    }

    private void verificarMudancaDirecao()
    {
        if (direcao == 1)
        {
            if(medidorObject.transform.localPosition.y >= pontoMax.transform.localPosition.y)
            {
                direcao = -1;
                medidorObject.transform.localPosition = new Vector3(medidorObject.transform.localPosition.x, pontoMax.transform.localPosition.y, medidorObject.transform.localPosition.z);
            }
        }
        else
        {
            if (medidorObject.transform.localPosition.y <= pontoMinimo.transform.localPosition.y)
            {
                direcao = 1;
                medidorObject.transform.localPosition = new Vector3(medidorObject.transform.localPosition.x,pontoMinimo.transform.localPosition.y, medidorObject.transform.localPosition.z);
            }
        }
    }
    float DeterminarPercentualPerdidoForca() {
        float medidorPosition = Mathf.RoundToInt(medidorObject.GetComponent<RectTransform>().position.y);
        float pontoMaxPosition = pontoMax.GetComponent<RectTransform>().position.y;
        float pontominPosition = pontoMinimo.GetComponent<RectTransform>().position.y;
        float distanciaMeioMedidor = Mathf.Abs(medidorPosition - (pontoMaxPosition+ pontominPosition)/2);
        float percentual = distanciaMeioMedidor*100/ ((pontoMaxPosition - pontominPosition) / 2);
        Debug.Log("distancia meio: "+ percentual);
       
        return percentual;
    }


    public int DeterminandoVelocidade() {
        return Mathf.RoundToInt(forcePower[1] - DeterminarPercentualPerdidoForca()/100 * (forcePower[1] - forcePower[0]));
    }

    public void HabilitarMedidorForca(bool valor)
    {
        jogoSendoExecutado = valor;
    }
}
