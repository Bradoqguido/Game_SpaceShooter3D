using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlProjetilPlayer : MonoBehaviour
{
    public Rigidbody rbProjetil;
    public int velocidadeProjetil = 1;
    private Vector3 vetorDeForcaProjetil;
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.rbProjetil = GetComponent<Rigidbody>();
        vetorDeForcaProjetil.x = 0;
        vetorDeForcaProjetil.z = this.velocidadeProjetil;
        vetorDeForcaProjetil.y = 0;

        // converte a for�a para a dire��o do player
        this.vetorDeForcaProjetil = transform.TransformDirection(this.vetorDeForcaProjetil);

        // Adiciona a for�a inicial do projetil.
        this.rbProjetil.AddForce(this.vetorDeForcaProjetil);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Atualiza a posi��o e exist�ncia do projetil.
    void FixedUpdate()
    {
        float distanciaPlayerProjetil = Vector3.Distance(transform.position, playerPrefab.transform.position);

        if (distanciaPlayerProjetil > 10)
        {
            // Destroi o objeto se ele ultrapassar a dist�ncia de 100.
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Se o inimigo for atingido a bala se destroi e destroi o inimigo.

        if (col.gameObject.name != "Player" && col.gameObject.name != "terreno")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
