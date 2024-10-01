using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private bool estaVivo ;
    [SerializeField] private int forcaPulo;
    [SerializeField] private float velocidade;
    private Rigidbody rb;
    private bool estaPulando;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar",true);
            Walk();
        }

        else if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarPraTras", true);
            Walk();
        }
        else
        {
            animator.SetBool("Andar", false);
            animator.SetBool("AndarPraTras", false);
        }
        
        //Evitar o bug da movimentação
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Andar", false);
            animator.SetBool("AndarPraTras", false);
            
        }
        //Pulo 
        if(Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            animator.SetTrigger("Pular");
            Jump();
        }
           if(Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("Pegando");
        }

        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("Ataque");
        }

         if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Correndo",true);
            Walk(10);
        }
        else
        {
            animator.SetBool("Correndo", false);

        }

        if(!estaVivo)
        {
            animator.SetTrigger("EstaVivo");
            estaVivo = true;
        }
    }

    private void Walk(float velo = 1)
    {   if((velo == 1))
        {
            velo = velocidade;
        }
        {
        float moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, moveV * velocidade * Time.deltaTime);
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        estaPulando = true;
        animator.SetBool("EstaNoChao", false);   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            estaPulando = false;
            animator.SetBool("EstaNoChao", true);    
        }
    }
}