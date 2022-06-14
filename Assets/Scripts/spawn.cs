using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Controla o respaw de inimigos.
    public float tempoParaRespawnInimigo = 5;
    public GameObject inimigoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInimigo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Controla o respawn de inimigos por tempo.
        if (tempoParaRespawnInimigo <= 0)
        {
            tempoParaRespawnInimigo = 10;
            Debug.Log("Iniciando respawn do inimigo.");
            SpawnInimigo();
            Debug.Log("Respawn do inimigo completo.");
        }
        tempoParaRespawnInimigo -= Time.deltaTime;

        // Controla o respawn do Player por tempo.
        if (GameObject.Find("Player") == null)
        {
            Debug.Log("Acabou o jogo, game over!");
            Loader.Load(Loader.Scene.GameScene);
        }
    }

    void SpawnInimigo()
    {
        Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
        Instantiate(inimigoPrefab, position, Quaternion.identity);
    }
}
