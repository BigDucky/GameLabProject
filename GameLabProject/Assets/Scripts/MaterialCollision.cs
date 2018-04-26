using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollision : MonoBehaviour {

    public void OnCollisionEnter (Collision collision) {
        if (this.gameObject.tag == "Factory" && collision.gameObject.tag == "Factory") {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(this.gameObject);
            Debug.Log("asd");
            collision.gameObject.GetComponent<FactoryProduction>().materialInPlace = true;
        }
    }
}
