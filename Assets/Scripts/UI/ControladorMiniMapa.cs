using UnityEngine;

public class ControladorMiniMapa : MonoBehaviour
{
    // 1.7
    //ControladorCorrida.Instance.posChegada
    [SerializeField] private Transform posMap;
    [SerializeField] private GameObject goal;
    [SerializeField] private Transform referencia;
    private Vector2 vetor;
    private float rotacao;
    private void Update() {
        if(GameManager.Instance.GetCorrida) AtualizarGoal();
        else goal.SetActive(false);
    }

    private void AtualizarGoal()
    {
        goal.SetActive(true);
        vetor = (ControladorCorrida.Instance.posChegada.position - posMap.position).normalized * 50f;
        goal.transform.localPosition = vetor;

        rotacao = Vector2.SignedAngle(referencia.localPosition,goal.transform.localPosition);
        Debug.Log(rotacao);
        goal.transform.eulerAngles = new Vector3(0,0,rotacao);
    }
}
