using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MatchInfoCanvas : MonoBehaviour
{
    [SerializeField]GameObject matchInfoGameObject;
    [SerializeField] Text textoTempo;
    [SerializeField] Text textoArremessoCesta;
    [SerializeField] Text textoAproveitamento;
    public void InicializarMatchInfo()
    {
        if (ManagerGame.Instance.TipoPartida.ToString() == "Jogo")
        {
            matchInfoGameObject.SetActive(true);
        }
        else
        {
            matchInfoGameObject.SetActive(false);
        }
    }

    public void AtualizarDados( int tempoRestante, float quantArremessos,float quantCestas, int aproveitamento)
    {
        textoTempo.text = "" + tempoRestante;
        textoArremessoCesta.text = quantCestas+"/"+quantArremessos;
        if (aproveitamento >= 0)
        {
            textoAproveitamento.text = "" + aproveitamento + "%";
        }
        else
        {
            textoAproveitamento.text = "------";
        }

    }
}
