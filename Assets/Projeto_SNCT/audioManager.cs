using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public bool naDireita;
    public bool naEsquerda;
    public bool acima;
    public AudioSource audioSource;
    public AudioClip direitaClip;
    public AudioClip esquerdaClip;
    public AudioClip acimaClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player2.transform.position.x - player1.transform.position.x >= 0)
        {
            audioSource.clip = direitaClip;
            Debug.LogWarning("inimigo à direita");
            audioSource.loop = true;
            naDireita = true;
            naEsquerda = false;
            acima = false;
            audioSource.Play();
        }

        else if (player2.transform.position.x - player1.transform.position.x <= 0){
            audioSource.clip = esquerdaClip;
            Debug.LogWarning("inimigo à esquerda");
            audioSource.loop = true;
            naDireita = false;
            naEsquerda = true;
            acima = false;
            audioSource.Play();
        }

        if (player2.transform.position.y > 0){
            audioSource.clip = acimaClip;
            Debug.LogWarning("inimigo acima");
            audioSource.loop = true;
            naDireita = false;
            naEsquerda = false;
            acima = true;
            audioSource.Play();
        }
    }
}
