using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animacao : MonoBehaviour
{
    private static Animacao _instance;
    public static Animacao Instance => _instance;
    [SerializeField] private float tempoAnimacaoEscorregar = 1f;
    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);
    }

    public void Escorregar()
    {
        transform.DORotate(new Vector3(0,0,360f),tempoAnimacaoEscorregar,RotateMode.FastBeyond360).SetRelative();
         StartCoroutine(SemControle());
    }

    public IEnumerator SemControle()
    {
        GameManager.Instance.SetAnimating(true);
        yield return new WaitForSeconds(tempoAnimacaoEscorregar);
        GameManager.Instance.SetAnimating(false);
    }

}
