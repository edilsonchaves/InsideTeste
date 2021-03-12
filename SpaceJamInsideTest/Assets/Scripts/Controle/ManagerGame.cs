using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerGame Instance { get; private set; }
    public enum TipoPartidaEnum { Jogo,Treino}
    public TipoPartidaEnum _tipoPartida;
    public int _dificuldade;
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
    
}
