using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGameCanvas : MonoBehaviour
{
    public Text cestaArremessoText;
    public Text aproveitamentoCanvas;
    // Start is called before the first frame update
    public void AtualizarUI(float cesta, float arremesso,int aproveitamento)
    {
        cestaArremessoText.text = "Cesta/Arremesso\n"+ cesta+"/"+arremesso;
        if (aproveitamento >= 0)
        {
            aproveitamentoCanvas.text = "Aproveitamento\n" + aproveitamento+"%";
        }
        else
        {
            aproveitamentoCanvas.text = "Aproveitamento\n" +"------";
        }

    }
}
