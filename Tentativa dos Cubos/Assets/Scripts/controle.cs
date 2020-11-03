using UnityEngine;

public class controle : MonoBehaviour
{
    public Vector3 direcao;
    public float velocidade;
    Rigidbody rb;

    public Material azul;
    public Material normal;
    public Material vermelho;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
