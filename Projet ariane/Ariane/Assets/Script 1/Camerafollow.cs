
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    void Update()
    {
        //déplacer la caméra vers la position du joueur dans le temps 
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        //transform correspond à l'objet caméra
        //Smoothdamp permet de déplacer un objet d'un endroit à un autre
        //posOffset sert a donner du recul a notre caméra
        //timeOffset permet d'ajouter un décalage dans le temps entre le moment ou le joueur bouge et entre le moment ou la caméra bouge
        //velocity est obligatoire pour utiliser un SmoothDamp
    }
}
