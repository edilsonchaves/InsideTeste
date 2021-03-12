using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasControllerMenu : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject dificuldadePartidasOficiaisCanvas;
    [SerializeField] GameObject instrucaoCanvas;
    // Start is called before the first frame update
    public void MenuCanvasActive()
    {
        menuCanvas.SetActive(true);
        dificuldadePartidasOficiaisCanvas.SetActive(false);
        instrucaoCanvas.SetActive(false);
    }

    public void DificuldadeCanvasActive()
    {
        menuCanvas.SetActive(false);
        dificuldadePartidasOficiaisCanvas.SetActive(true);
        instrucaoCanvas.SetActive(false);
    }
    public void InstrucaoCanvasActive()
    {
        menuCanvas.SetActive(false);
        dificuldadePartidasOficiaisCanvas.SetActive(false);
        instrucaoCanvas.SetActive(true);
    }
    public void AlterarNivelDificuldade(int valor)
    {
        ManagerGame.Instance._dificuldade = valor;
        Inicializarjogo(0);
    }
    public void Inicializarjogo(int valor)
    {
        if (valor == 0)
        {
            ManagerGame.Instance._tipoPartida = ManagerGame.TipoPartidaEnum.Jogo;
        }
        else
        {
            ManagerGame.Instance._tipoPartida = ManagerGame.TipoPartidaEnum.Treino;
        }
        SceneManager.LoadScene("GameScene");
    }
}
