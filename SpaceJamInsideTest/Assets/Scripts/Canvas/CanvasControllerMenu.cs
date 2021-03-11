using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControllerMenu : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject dificuldadePartidasOficiaisCanvas;
    // Start is called before the first frame update
    public void MenuCanvasActive()
    {
        menuCanvas.SetActive(true);
        dificuldadePartidasOficiaisCanvas.SetActive(false);
    }

    public void DificuldadeCanvasActive()
    {
        menuCanvas.SetActive(false);
        dificuldadePartidasOficiaisCanvas.SetActive(true);
    }
}
