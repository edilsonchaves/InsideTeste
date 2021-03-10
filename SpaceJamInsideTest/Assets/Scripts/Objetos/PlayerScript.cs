using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]GameObject cestaObjetivo;
    void Start()
    {
        cestaObjetivo = GameObject.FindGameObjectWithTag("CheckCesta");
    }
    public void AjustarRotacaoPlayer()
    {
        Vector3 playerCesta = new Vector3(cestaObjetivo.transform.position.x, transform.position.y, cestaObjetivo.transform.position.z);

        transform.LookAt(playerCesta);
    }
}
