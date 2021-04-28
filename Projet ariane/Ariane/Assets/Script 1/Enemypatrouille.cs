
using UnityEngine;

public class Enemypatrouille : MonoBehaviour
{
    public float speed; //vitesse de l'ennemie
    public Transform[] waypoints; //on mettra à l'intérieur tout les points vers lequel l'enemie doit se deplacer
    private Transform target; //cible vers laquelle l'ennemie va se déplacer 
    private int destpoint = 0; //cela va etre le point de destination

    public SpriteRenderer graphics; 

    
    void Start()
    {
        target = waypoints[0];
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position; 
        //position cible - position acutuelle de l'ennemie pour savoir dans quelle 
        //direction il faut se déplacer pour aller au prochain waypoint
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 
        //deplacement par rapport au parent

        if(Vector3.Distance(transform.position, target.position) < 0.3f) 
            //si la distance entre object actuel et le waypoint qui se dirige est inférieur a 0.3 on va vers un autre waypoint,
            //0.3 est une valeur de sécurité
        {
            destpoint = (destpoint + 1) % waypoints.Length;
            //destpoint correspond à l'indexe du waypoint vers lequel on se dirige, le modulo permet a l'ennemie une fois qu'il 
            //a parcouru tout les waypoints de recommencer  à 0

            target = waypoints[destpoint];
            graphics.flipX = !graphics.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            healthbar healthbar = collision.transform.GetComponent<healthbar>();
            healthbar.SetDammages(0.1f);
            Debug.Log("aie");
        }
    }
}
