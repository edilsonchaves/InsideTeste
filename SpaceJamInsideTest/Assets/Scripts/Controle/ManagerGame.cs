using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerGame Instance { get; private set; }
    public enum TipoPartidaEnum { Jogo,Treino}
    [SerializeField] TipoPartidaEnum _tipoPartida;
    [SerializeField] int _dificuldade;

    public TipoPartidaEnum TipoPartida
    {
        get { return _tipoPartida;}
        set { _tipoPartida = value;}
    }

    public int Dificuldade
    {
        get { return _dificuldade; }
        set { _dificuldade = value; }
    }
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
    public void AlterarNivelDificuldade(int valor)
    {
        _dificuldade = valor;
        Inicializarjogo(0);
    }
    public void Inicializarjogo(int valor)
    {
        if (valor == 0)
        {
            _tipoPartida = TipoPartidaEnum.Jogo;
        }
        else
        {
            _tipoPartida = TipoPartidaEnum.Treino;
        }
        SceneManager.LoadScene("GameScene");
    }
}
