using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButtonScript : MonoBehaviour {

    public Material hoverMaterial;
    public Material normalMaterial;
    public Material clickMaterial;
    public GameObject attachedGameobject;
    private ProcessHandle processHandle;


    private void Start() {
        normalMaterial = this.GetComponent<MeshRenderer>().materials[0];
        processHandle = attachedGameobject.GetComponent<ProcessHandle>();
    }

    private void OnMouseEnter() {
        this.GetComponent<MeshRenderer>().material = hoverMaterial;
    }

    private void OnMouseExit() {
        this.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    private void OnMouseDown() {
        this.GetComponent<MeshRenderer>().material = clickMaterial;
        processHandle.materialInPlace = true;
        this.gameObject.SetActive(false);

    }

    private void OnMouseUp() {
        this.GetComponent<MeshRenderer>().material = hoverMaterial;
    }
}
