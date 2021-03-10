using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerGame Instance { get; private set; }
    enum TipoPartidaEnum { Jogo,Treino}
    [SerializeField] TipoPartidaEnum tipoPartida;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Inicializarjogo(int valor)
    {
        if (valor == 0)
        {
            tipoPartida = TipoPartidaEnum.Jogo;
        }
        else
        {
            tipoPartida = TipoPartidaEnum.Treino;
        }
        SceneManager.LoadScene("GameScene");
    }
}
