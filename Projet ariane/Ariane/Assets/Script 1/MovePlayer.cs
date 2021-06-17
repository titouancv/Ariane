
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed; //vitesse de d�placement
    public float jumpForce; //force de saut
    private float horizontalMouvement;
    public float groundCheckradius;
    public LayerMask collisionlayer;


    private bool isJumping;
    private bool isGrounded;
    

    public Transform GroundCheck;
    

    public Rigidbody2D rb; //ref au rb du perso
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriterenderer;


    void Update() //uptade r�serv� � tout ce qui n'est pas physique
    {
 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x); //renvoyer une vitesse positive
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate() //update r�serv� � physique
    {
        horizontalMouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //mouvement horizontal au fil du temps



        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckradius, collisionlayer);




        Movejoueur(horizontalMouvement); //d�placement du joueur

    }

    void Movejoueur(float _horizontalMouvement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y); //calcul de la v�locit� du perso
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity,.05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void flip(float _velocity) //pour se tourner quand on va a gauche ou a droite
    {
        if(_velocity > 0.1f)
        {
            spriterenderer.flipX = false;
        } 
        else if(_velocity < -0.1f)
        {
            spriterenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, groundCheckradius);
    }
}
