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
    MedidorForça medidorForca;
    MedidorAngulo medidorAngulo;
    GameScript gameScript;
    ParticlesEffect particle;
    bool fizCesta;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        medidorForca = GameObject.Find("PowerShoot").GetComponent<MedidorForça>();
        medidorAngulo = GameObject.Find("AngleBasketBall").GetComponent<MedidorAngulo>();
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        particle = GameObject.Find("ParticleSystem").GetComponent<ParticlesEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        angleBall = medidorAngulo.GetAngle();
        this.transform.eulerAngles = new Vector3(-angleBall, transform.eulerAngles.y, transform.eulerAngles.z);
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
            if (this.transform.position.y < 0 || gameScript.partidainfo.TempoPartida <= 0)
            {
                ResetBall();
            }
        }
    }

    public void Lançamento()
    {
        this.transform.eulerAngles = new Vector3(-angleBall, transform.eulerAngles.y, transform.eulerAngles.z);
        forcePowerBall = medidorForca.DeterminandoVelocidade();
        rb.AddForce(transform.forward* forcePowerBall, ForceMode.Force);
        rb.useGravity = true;
        gameScript.AlteraçãoQuantArremesso();
    }
    void ResetBall()
    {
        if (fizCesta)
        {
            fizCesta = false;
            gameScript.DefinirNovaPosicaoPlayer();
        }
        touchFloor = false;
        rb.useGravity = false;
        transform.localPosition = new Vector3(0,-0.4f,0.8f);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckCesta") && !touchFloor)
        {
            Debug.Log("Cesta");
            gameScript.AlteraçãoQuantCesta();
            particle.CestaPartcileSystem();
            fizCesta = true;
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
