using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class personagem : MonoBehaviour
{
    // Variáveis de controle de movimento do player.
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = .9f;

    private PlayerInput playerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction shootAction;

    public int vida = 100;
    private Text txtVida;

    // Controla a direção do disparo.
    private Vector3 posicaoProjetil;

    // prefab do projetil.
    public GameObject projetilPrefab;

    public AudioSource shootSound;

    public AudioSource damageSound;

    public AudioSource destructionSound;

    public AudioSource pickUpPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        txtVida = GameObject.Find("txtVida").GetComponent<Text>();
        vida = 100;
        txtVida.text = $"Vida: {vida}";

        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        shootAction = playerInput.actions["Shoot"];
    }

    // Update is called once per frame
    void Update()
    {
        txtVida.text = $"Vida: {vida}";

        if (vida <= 0)
        {
            destructionSound.Play();
            Destroy(gameObject);
        }

        MovimentarPersonagem();

        if (shootAction.triggered)
        {
            Atirar();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Se o inimigo encostar no player o player morre.
        if (col.gameObject.name == "Heart")
        {
            Debug.Log("Coletando Vida.");
            pickUpPowerUp.Play();
            Destroy(col.gameObject);
        }
    }

    void MovimentarPersonagem()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // rotaciona a camera
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Atirar()
    {
        // Calcula a posição relativa do projetil evitando a colisão acidental com o player.
        float distanciaPlayerProjetil = 5f;
        float alturaPlayerProjetil = 0.3f;

        float angulo = transform.eulerAngles.y * Mathf.Deg2Rad;
        this.posicaoProjetil.x = transform.position.x + distanciaPlayerProjetil * Mathf.Sin(angulo);
        this.posicaoProjetil.y = transform.position.y + alturaPlayerProjetil;
        this.posicaoProjetil.z = transform.position.z + distanciaPlayerProjetil * Mathf.Cos(angulo);

        // Cria o projetil em tempo de execução.
        shootSound.Play();
        Instantiate(projetilPrefab, posicaoProjetil, transform.rotation);
    }

    public void DarDanoAoPlayer(int intDano)
    {
        Debug.Log("Dando dano ao player.");
        damageSound.Play();
        vida -= intDano;
    }

    public void AddVidaAoPlayer(int intVida)
    {
        Debug.Log("Recebendo vida.");
        vida += intVida;
    }
}
