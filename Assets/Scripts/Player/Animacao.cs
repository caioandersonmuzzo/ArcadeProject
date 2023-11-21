using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animacao : MonoBehaviour
{
    private static Animacao _instance;
    public static Animacao Instance => _instance;
    [SerializeField] private float tempoAnimacaoEscorregar = 1f;
    [SerializeField] private ParticleSystem particulaEscorregarF;
    [SerializeField] private ParticleSystem particulaEscorregarB;
    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);
        particulaEscorregarF.Stop();
        particulaEscorregarB.Stop();
    }

    public void Escorregar()
    {
        transform.DORotate(new Vector3(0,0,360f),tempoAnimacaoEscorregar,RotateMode.FastBeyond360).SetRelative();
         StartCoroutine(SemControle());
    }

    public IEnumerator SemControle()
    {
        GameManager.Instance.SetAnimating(true);
        particulaEscorregarF.Play();
        particulaEscorregarB.Play();
        yield return new WaitForSeconds(tempoAnimacaoEscorregar);
        particulaEscorregarF.Stop();
        particulaEscorregarB.Stop();
        GameManager.Instance.SetAnimating(false);
    }

}
