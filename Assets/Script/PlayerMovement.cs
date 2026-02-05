using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    
    // On définit les noms des axes pour chaque joueur
    // Ex: "HorizontalP1", "VerticalP1", etc.
    public string horizontalAxis;
    public string verticalAxis;

    void Update()
    {
        // Récupération des entrées clavier
        float moveX = Input.GetAxisRaw(horizontalAxis);
        float moveY = Input.GetAxisRaw(verticalAxis);

        // Calcul du mouvement
        Vector3 movement = new Vector3(moveX, 0, moveY).normalized;
        
        // Application du déplacement
        transform.position += movement * speed * Time.deltaTime;
    }
}