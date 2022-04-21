using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Player;
    //public GameObject diedTextGameObject;
    private int puntos;
    private int obstaculos = 1;
    public float speed = 25f;
    //public float giro = 90f;
    
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 10f, strafeAcceleration = 2f, hoverAcceleration = 2f;
    
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    
    public GameObject[] hearts;
    public int life;
    
    public GameObject loseTextObject;
    public GameObject restartButton;
    public TextMeshProUGUI fallText;

    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        
        puntos = 0;

        setCountText();
        winTextObject.SetActive(false);

        LifeCountText();
        loseTextObject.SetActive(false);
        
        restartButton.SetActive(false);
    }
    
    void LifeCountText()
    {
        if (life <= 0)
        {
            loseTextObject.SetActive(true);
            restartButton.SetActive(true);
            speed = 0;
            lookRateSpeed = 0;
            rollInput = 0;
            rollSpeed = 0;
            rollAcceleration = 0;
            forwardSpeed = 0;
            strafeSpeed = 0;
            hoverSpeed = 0;
        }
    }
    
    void FallText()
    {
        fallText.text = "¡Hey! No te salgas de la zona";
        loseTextObject.SetActive(true);
        restartButton.SetActive(true);
        speed = 0;
        lookRateSpeed = 0;
        rollInput = 0;
        rollSpeed = 0;
        rollAcceleration = 0;
        forwardSpeed = 0;
        strafeSpeed = 0;
        hoverSpeed = 0;
    }
    
    void NoPoints()
    {
        fallText.text = "Puntos insuficientes ¡Perdiste!";
        loseTextObject.SetActive(true);
        restartButton.SetActive(true);
        speed = 0;
        lookRateSpeed = 0;
        rollInput = 0;
        rollSpeed = 0;
        rollAcceleration = 0;
        forwardSpeed = 0;
        strafeSpeed = 0;
        hoverSpeed = 0;
    }
    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
        
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
        
        //If you press R
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("EscenaJuego");
        }

    }
    
    private void LifeUpdate()
    
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
    }
    void setCountText()
    {
        countText.text = "Puntos: " + puntos.ToString() + "/70";
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coin")) 
        {
            other.gameObject.SetActive(false);
            puntos = puntos + 1;

            setCountText();
        }

        if (other.gameObject.CompareTag("Obstaculos")) 
        {
            if (puntos >= 1)
            {
                other.gameObject.SetActive(false);
                puntos = puntos - obstaculos;
                
                setCountText();
            }
        }
        
        if (other.gameObject.CompareTag("Damage"))
        {
            
            life = life - 1;
            
            LifeUpdate();
            LifeCountText();
        }
        
        if (other.gameObject.CompareTag("Meta")) 
        {
            if(puntos >= 70)
            {
                other.gameObject.SetActive(false);
                winTextObject.SetActive(true);
                restartButton.SetActive(true);
                speed = 0;
                lookRateSpeed = 0;
                rollInput = 0;
                rollSpeed = 0;
                rollAcceleration = 0;
                forwardSpeed = 0;
                strafeSpeed = 0;
                hoverSpeed = 0;
            }
            else 
            {
                other.gameObject.SetActive(false);
                NoPoints();
            }
        }
        if (other.gameObject.CompareTag("FallDamage"))
        {
            FallText();
        }
    }
    
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
    
}

