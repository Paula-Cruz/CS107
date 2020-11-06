using System;
using UnityEngine;

public class Controle : MonoBehaviour
{
    Vector3 direcao;
    public float velocidade;
    
    Rigidbody rb;
    Renderer cor;

    public Material Azul;
    public Material Amarelo;
    public Material Vermelho;
    public Material Roxo;

    bool estouAzul = false;
    float tempoAzul = 0;
    public float tempoAzullimite = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cor = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // TEMPORIZADOR
        if (estouAzul)
        {
            tempoAzul += Time.deltaTime;
            if (tempoAzul > tempoAzullimite)
            {
                MudaCor(Amarelo);
                tempoAzul = 0;
            }
        }
        // MOVIMENTO
        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(direcao * velocidade * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Vitoria();
        }
        
        if (other.GetComponent<Vermelho>() != null)
        {
            Morre();
        }
        else if (other.GetComponent<Azul>() != null)
        {
            if (estouAzul == true)
            {
                Morre();
            }
            else
            {
                MudaCor(Azul);
            }
        }
    }

    private void Vitoria()
    {
        cor.material = Roxo;
    }

    private void MudaCor(Material material)
    {
        cor.material = material;
        if (material == Azul)
        {
            estouAzul = true;
        }
        else
        {
            estouAzul = false;
        }

    }

    private void Morre()
    {
        cor.enabled = false;
        Time.timeScale = 0;
    }
}
