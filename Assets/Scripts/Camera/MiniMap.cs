using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Camera cam;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    private void Update() {
        SeguirJogador();
    }

    private void SeguirJogador()
    {
        gameObject.transform.position = new Vector3(player.position.x,player.position.y,-10f);
    }
}
