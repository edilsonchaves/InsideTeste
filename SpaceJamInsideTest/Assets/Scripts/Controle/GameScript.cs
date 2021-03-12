using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform[] quadraPositionLimit;
    [SerializeField] MatchInfoCanvas matchInfoCanvas;
    public PartidaInfo partidainfo;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject endGameCanvas;
    bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        DefinirNovaPosicaoPlayer();
        matchInfoCanvas.InicializarMatchInfo();
        if (ManagerGame.Instance.TipoPartida.ToString() == "Jogo")
        {
            partidainfo = new PartidaInfo();
            inGame = true;
        }
    }

    void Update()
    {
        if (ManagerGame.Instance.TipoPartida.ToString() == "Jogo" && inGame)
        {
            partidainfo.TempoPartida -= Time.deltaTime;
            matchInfoCanvas.AtualizarDados(Mathf.CeilToInt(partidainfo.TempoPartida), partidainfo.QuantArremessos, partidainfo.QuantCestas, partidainfo.Aproveitamento());
            if (partidainfo.TempoPartida <= 0)
            {
                inGame = false;
                gameCanvas.SetActive(false);
                endGameCanvas.SetActive(true);
                endGameCanvas.GetComponent<EndGameCanvas>().AtualizarUI(partidainfo.QuantCestas, partidainfo.QuantArremessos, partidainfo.Aproveitamento());
            }
        }
    }
    public void DefinirNovaPosicaoPlayer()
    {
        float posicaoRandomicaX = Random.Range(quadraPositionLimit[0].position.x, quadraPositionLimit[1].position.x);
        float posicaoRandomicaZ = Random.Range(quadraPositionLimit[0].position.z, quadraPositionLimit[1].position.z);
        player.transform.position = new Vector3(posicaoRandomicaX,player.transform.position.y, posicaoRandomicaZ);
        player.GetComponent<PlayerScript>().AjustarRotacaoPlayer();
    }

    public void AlteraçãoQuantArremesso()
    {
        partidainfo.QuantArremessos++;
    }
    public void AlteraçãoQuantCesta()
    {
        partidainfo.QuantCestas++;
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
[System.Serializable]
public class PartidaInfo
{
    [SerializeField] float _tempoPartida;
    [SerializeField] float _quantArremessos;
    [SerializeField] float _quantCestas;
    public float TempoPartida { get { return _tempoPartida; } set { _tempoPartida = value; } }
    public float QuantArremessos { get { return _quantArremessos; } set { _quantArremessos = value; } }
    public float QuantCestas { get { return _quantCestas; } set { _quantCestas = value; } }

    public PartidaInfo()
    {
        _tempoPartida = 300;
        _quantArremessos = 0;
        _quantCestas = 0;
    }

    public int Aproveitamento()
    {
        if (_quantArremessos > 0)
        {
            return Mathf.RoundToInt(_quantCestas / _quantArremessos*100);
        }
        else
        {
            return -1;
        }

    }
}
