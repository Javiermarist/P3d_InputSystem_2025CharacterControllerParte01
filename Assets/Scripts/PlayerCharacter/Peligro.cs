using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Peligro : MonoBehaviour
{
    public PlayerController2 playerController2;
    public SistemaDano sistemaDano;
    public Animator animator;

    public int puntos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sistemaDano.RestarVida(puntos);
            if (sistemaDano.GetVida() <= 0)
            {
                Muerte();
            }
            else
            {
                animator.SetTrigger("Dano");
            }
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Debug.Log("Te ibas muerto");
        playerController2.enabled = false;

        StartCoroutine(ReiniciarJuego());
    }

    private IEnumerator ReiniciarJuego()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Juego");
    }
}
