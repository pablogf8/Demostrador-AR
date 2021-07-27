using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private GameObject cabecero;
    private GameObject lumbares;
    private GameObject asiento;

    public Material[] materials = new Material[3];

    void FindParts()
    {
        cabecero = GameObject.Find("Cabecero");
        lumbares = GameObject.Find("Lumbares");
        asiento = GameObject.Find("Asiento");
    }

    public void ChangeTelaGris()
    {
        FindParts();
        cabecero.GetComponent<MeshRenderer>().material = materials[0];
        lumbares.GetComponent<MeshRenderer>().material = materials[0];
        asiento.GetComponent<MeshRenderer>().material = materials[0];
    }

    public void ChangeTelaAzul()
    {
        FindParts();
        cabecero.GetComponent<MeshRenderer>().material = materials[1];
        lumbares.GetComponent<MeshRenderer>().material = materials[1];
        asiento.GetComponent<MeshRenderer>().material = materials[1];
    }

    public void ChangeCuero()
    {
        FindParts();
        cabecero.GetComponent<MeshRenderer>().material = materials[2];
        lumbares.GetComponent<MeshRenderer>().material = materials[2];
        asiento.GetComponent<MeshRenderer>().material = materials[2];
    }
}
