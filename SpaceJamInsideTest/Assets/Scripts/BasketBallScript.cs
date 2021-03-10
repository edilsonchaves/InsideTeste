using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int angleBall;
    [SerializeField] int forcePowerBall;
    bool touchFloor;
    float timerReset;
    medidorForça medidorForca;
    MedidorAngulo medidorAngulo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        medidorForca = GameObject.Find("PowerShoot").GetComponent<medidorForça>();
        medidorAngulo = GameObject.Find("AngleBasketBall").GetComponent<MedidorAngulo>();

    }

    // Update is called once per frame
    void Update()
    {
        angleBall = medidorAngulo.GetAngle();
        this.transform.eulerAngles = new Vector3(-angleBall, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Space) && !rb.useGravity)
        {
            Lançamento();
        }
        if (touchFloor)
        {

            timerReset += Time.deltaTime;
            if (timerReset >= 3)
            {
                timerReset = 0;
                ResetBall();
                Debug.Log("ResetBall");
            }
        }
        else
        {
            if (this.transform.position.y < 0)
            {
                ResetBall();
            }
        }
    }

    public void Lançamento()
    {
        this.transform.eulerAngles = new Vector3(-angleBall, 0, 0);
        forcePowerBall = medidorForca.DeterminandoVelocidade();
        rb.AddForce(transform.forward* forcePowerBall, ForceMode.Force);
        rb.useGravity = true;
    }
    void ResetBall()
    {
        touchFloor = false;
        rb.useGravity = false;
        this.transform.localPosition = new Vector3(0,-0.4f,0.8f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckCesta"))
        {
            Debug.Log("Cesta");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Quadra"))
        {
            touchFloor = true;
        }
    }
}
