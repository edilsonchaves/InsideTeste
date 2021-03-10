using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform[] quadraPositionLimit;
    // Start is called before the first frame update
    void Start()
    {
        DefinirNovaPosicaoPlayer();

    }
    public void DefinirNovaPosicaoPlayer()
    {
        float posicaoRandomicaX = Random.Range(quadraPositionLimit[0].position.x, quadraPositionLimit[1].position.x);
        float posicaoRandomicaZ = Random.Range(quadraPositionLimit[0].position.z, quadraPositionLimit[1].position.z);
        player.transform.position = new Vector3(posicaoRandomicaX,player.transform.position.y, posicaoRandomicaZ);
        player.GetComponent<PlayerScript>().AjustarRotacaoPlayer();
    }
}
