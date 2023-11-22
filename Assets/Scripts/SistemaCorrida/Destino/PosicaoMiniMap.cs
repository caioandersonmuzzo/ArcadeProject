using System;
using UnityEngine;

public class PosicaoMiniMap : MonoBehaviour
{
    [SerializeField] private float size;
    private float angulo;
    private double xPos;
    private double yPos;

    private Transform ping;
    private Vector2 miniMap; // Mini Mapa
    private Vector2 posPing; // Classe filha
    private Vector2 posItem; // Classe pai

    private void Awake() {
        posItem = new Vector2(transform.position.x,transform.position.y);
    }

    private void Update() {
        //miniMap = ControladorCorrida.Instance.GetMiniMap.position;
        ping = gameObject.GetComponentInChildren<Transform>();

        AttTransform();
    }

    private void AttTransform()
    {

            //diffPontoMiniMap = -(transform.position - minimap.transform.position);
            //angulo = (float)Vector2.SignedAngle(diffPontoMiniMap,new Vector2(20,0));
            Debug.Log(angulo);
            //ping.transform.position = minimap.transform.position + diffPontoMiniMap.normalized * 2;
    }
}
