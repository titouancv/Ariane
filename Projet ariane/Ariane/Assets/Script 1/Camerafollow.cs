
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    void Update()
    {
        //d�placer la cam�ra vers la position du joueur dans le temps 
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        //transform correspond � l'objet cam�ra
        //Smoothdamp permet de d�placer un objet d'un endroit � un autre
        //posOffset sert a donner du recul a notre cam�ra
        //timeOffset permet d'ajouter un d�calage dans le temps entre le moment ou le joueur bouge et entre le moment ou la cam�ra bouge
        //velocity est obligatoire pour utiliser un SmoothDamp
    }
}
