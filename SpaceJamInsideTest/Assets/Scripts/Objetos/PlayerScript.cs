using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]GameObject cestaObjetivo;
    public void AjustarRotacaoPlayer()
    {
        if (cestaObjetivo == null)
        {
            cestaObjetivo = GameObject.FindGameObjectWithTag("CheckCesta");
        }
        Vector3 playerCesta = new Vector3(cestaObjetivo.transform.position.x, transform.position.y, cestaObjetivo.transform.position.z);
        transform.LookAt(playerCesta);
    }
}
