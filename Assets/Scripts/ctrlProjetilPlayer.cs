using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlProjetilPlayer : MonoBehaviour
{
    public Rigidbody rbProjetil;
    public int velocidadeProjetil = 1;
    private Vector3 vetorDeForcaProjetil;
    public GameObject playerPrefab;

    public AudioSource colisionSound;
    public AudioSource pickUpPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        this.rbProjetil = GetComponent<Rigidbody>();
        vetorDeForcaProjetil.x = 0;
        vetorDeForcaProjetil.z = this.velocidadeProjetil;
        vetorDeForcaProjetil.y = 0;

        // converte a força para a direção do player
        this.vetorDeForcaProjetil = transform.TransformDirection(this.vetorDeForcaProjetil);

        // Adiciona a força inicial do projetil.
        this.rbProjetil.AddForce(this.vetorDeForcaProjetil);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Atualiza a posição e existência do projetil.
    void FixedUpdate()
    {
        float distanciaPlayerProjetil = Vector3.Distance(transform.position, playerPrefab.transform.position);

        if (distanciaPlayerProjetil > 100)
        {
            // Destroi o objeto se ele ultrapassar a distância de 100.
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Se o inimigo for atingido a bala se destroi e destroi o inimigo.
        if (col.gameObject.name.Contains("Enemy"))
        {
            colisionSound.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        // Se o inimigo for atingido a bala se destroi e destroi o objeto.
        if (col.gameObject.name.Contains("Heart"))
        {
            pickUpPowerUp.Play();
            GameObject playerObject = GameObject.Find("Player");
            personagem scriptPlayer = (personagem)playerObject.GetComponent(typeof(personagem));
            scriptPlayer.AddVidaAoPlayer(10);

            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
