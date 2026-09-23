using UnityEngine;

public class Player2PaddleController : MonoBehaviour
{
public float speed = 5f;

    public SpriteRenderer spriteRenderer;
    public bool isPlayer = false;

    void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer1;
        else
            spriteRenderer.color = SaveController.Instance.colorPlayer2;
    }

    void Update()
{
    // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
    float moveInput = Input.GetAxis("Horizontal");

    // Calcula a nova posição da raquete baseada na entrada e na velocidade
    Vector3 newPosition = transform.position
        + Vector3.up * moveInput * speed * Time.deltaTime;

    // Limita a posição vertical da raquete para que ela não saia da tela
    newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

    // Atualiza a posição da raquete
    transform.position = newPosition;
    }

}
