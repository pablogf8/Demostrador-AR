using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject botonTelaGris;
    public GameObject botonTelaAzul;
    public GameObject botonCuero;
    public GameObject panelAnim;
    public GameObject togglePlanes;
    public GameObject toggleEII;
    public GameObject imageMensaje;

    public ChangeMaterial ChangeMaterial;

    //Estado del Canvas inicialmente
    void Start()
    {
        botonTelaGris.SetActive(false);
        botonTelaAzul.SetActive(false);
        botonCuero.SetActive(false);
        panelAnim.SetActive(false);
        togglePlanes.SetActive(false);
        toggleEII.SetActive(false);

        imageMensaje.SetActive(true);
    }

    //Elementos UI que se activan al instanciarse un objeto
    public void ActivateCanvas()
    {
        botonTelaGris.SetActive(true);
        panelAnim.SetActive(true);
        togglePlanes.SetActive(true);
        toggleEII.SetActive(true);

        imageMensaje.SetActive(false);
    }

    //Activacion-Desactivacion de elementos con el Toggle EII
    public void OnToggleEII(bool toggle)
    {
        botonTelaGris.SetActive(toggle);
        botonTelaAzul.SetActive(toggle);
        botonCuero.SetActive(toggle);
        panelAnim.SetActive(toggle);
        togglePlanes.SetActive(toggle);
    }

    //Funciones para los botones de cambio de material
    public void OnClickTelaGris()
    {
        //Se cambia el material a Tela Azul
        ChangeMaterial.ChangeTelaAzul();
        //Se activa el botón Tela Azul y se desactivan los otros dos
        botonTelaGris.SetActive(false);
        botonTelaAzul.SetActive(true);
        botonCuero.SetActive(false);
    }

    public void OnClickTelaAzul()
    {
        //Se cambia el material a Cuero
        ChangeMaterial.ChangeCuero();
        //Se activa el botón Cuero y se desactivan los otros dos
        botonTelaGris.SetActive(false);
        botonTelaAzul.SetActive(false);
        botonCuero.SetActive(true);
    }

    public void OnClickCuero()
    {
        //Se cambia el material a Tela Gris
        ChangeMaterial.ChangeTelaGris();
        //Se activa el botón Tela Azul y se desactivan los otros dos
        botonTelaGris.SetActive(true);
        botonTelaAzul.SetActive(false);
        botonCuero.SetActive(false);
    }
}

