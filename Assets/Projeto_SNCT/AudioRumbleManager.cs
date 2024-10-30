using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class audioManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public bool naDireita;
    public bool naEsquerda;
    public bool acima;
    public AudioSource audioSourceDireita;
    public AudioSource audioSourceEsquerda;
    public AudioSource audioSourceAcima;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceDireita.Play();
        audioSourceEsquerda.Play();
        audioSourceAcima.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // código de adriano para encontrar os personagens na cena 
        if (player1 == null)
        {
            string[] playerNames = { "Fighter1(Keyboard:/Keyboard)_player", "Fighter2(Keyboard:/Keyboard)_player", "Fighter3(Keyboard:/Keyboard)_player", "Fighter4(Keyboard:/Keyboard)_player", "Fighter5(Keyboard:/Keyboard)_player" };
            foreach (string name in playerNames)
            {
                GameObject foundPlayer = GameObject.Find(name);
                if (foundPlayer != null)
                {
                player1 = foundPlayer;
                }
            }
        }
        if (player2 == null)
        {
            string[] playerNames2 = { "Fighter1()_player", "Fighter2()_player", "Fighter3()_player", "Fighter4()_player", "Fighter5()_player" };
            foreach (string name in playerNames2)
            {
                GameObject foundPlayer2 = GameObject.Find(name);
                if (foundPlayer2 != null)
                {
                player2 = foundPlayer2;
                }
            }
        }
        if (player2.transform.position.x - player1.transform.position.x >= 0)
        {
            audioSourceDireita.mute = false;
            audioSourceEsquerda.mute = true;
            audioSourceAcima.mute = true;
            // Gamepad.current.SetMotorSpeeds(0f, 5f);
            // Debug.LogWarning("inimigo à direita");
            // naDireita = true;
            // naEsquerda = false;
            // acima = false;
            // audioSource.Play();
        }

        else if (player2.transform.position.x - player1.transform.position.x <= 0){
            audioSourceDireita.mute = true;
            audioSourceEsquerda.mute = false;
            audioSourceAcima.mute = true;
            // Gamepad.current.SetMotorSpeeds(5f, 0f);
            // audioSource.Stop();
            // audioSource.clip = esquerdaClip;
            // Debug.LogWarning("inimigo à esquerda");
            // audioSource.loop = true;
            // naDireita = false;
            // naEsquerda = true;
            // acima = false;
            // audioSource.Play();
        }

        if (player2.transform.position.y > 0){
            audioSourceDireita.mute = true;
            audioSourceEsquerda.mute = true;
            audioSourceAcima.mute = false;
            // audioSource.Stop();
            // audioSource.clip = acimaClip;
            // Debug.LogWarning("inimigo acima");
            // audioSource.loop = true;
            // naDireita = false;
            // naEsquerda = false;
            // acima = true;
            // audioSource.Play();
        }
    }
}
