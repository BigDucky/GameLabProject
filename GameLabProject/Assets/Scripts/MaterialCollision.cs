using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollision : MonoBehaviour {

    public void OnCollisionEnter (Collision collision) {
        if (this.gameObject.tag == "Factory" && collision.gameObject.tag == "Factory") {
            if(collision.gameObject.GetComponent<FactoryProduction>().processing == false) {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Destroy(this.gameObject);
                collision.gameObject.GetComponent<FactoryProduction>().materialInPlace = true;
            }         
        }
        else if (this.gameObject.tag == "Garbage" &&  collision.gameObject.tag == "Garbage") {
            if(PlayerInfo.totalWaste > PlayerInfo.totalWasteCap) {
                PlayerInfo.totalWaste += FactoryProduction.addedWaste;
                Destroy(this.gameObject);
            }
            else {
                //Indicate it cant happen
            }

        }
        else if(this.gameObject.tag == "Recycle" && collision.gameObject.tag == "Recycle") {
            if(collision.gameObject.GetComponent<RecycleProcess>().processing == false) {
                this.GetComponent<Rigidbody>().isKinematic = false;
                Destroy(this.gameObject);
                collision.gameObject.GetComponent<RecycleProcess>().materialInPlace = true;

            }
        }


    }
}
