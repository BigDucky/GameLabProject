using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollision : MonoBehaviour {

    public bool clickedOn;

    public void OnCollisionEnter (Collision collision) {
        if (this.gameObject.tag == "Factory" && collision.gameObject.tag == "Factory") {
            if (collision.gameObject.GetComponent<ProcessHandle>().processing == false) {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<ProcessHandle>().materialInPlace = true;
                Destroy(this.gameObject);
                
            }
        }
        else if (this.gameObject.tag == "Garbage" && collision.gameObject.tag == "Garbage") {
            if (PlayerInfo.totalWaste < PlayerInfo.totalWasteCap) {
                PlayerInfo.totalWaste += this.gameObject.GetComponent<MaterialInfoContainer>().productWaste;
                Destroy(this.gameObject);
            }
            //else {
            //Indicate it cant happen
            //  }

        }
        else if (this.gameObject.tag == "Recycle" && collision.gameObject.tag == "Recycle") {
            if (collision.gameObject.GetComponent<ProcessHandle>().processing == false) {
                this.GetComponent<Rigidbody>().isKinematic = false;
                //collision.gameObject.GetComponent<RecycleProcess>().totalRecycleMat = this.GetComponent<MaterialInfoContainer>().productRecycle;
                // collision.gameObject.GetComponent<RecycleProcess>().materialInPlace = true;

                collision.gameObject.GetComponent<ProcessHandle>().totalRecycleMat = this.GetComponent<MaterialInfoContainer>().productRecycle;
                collision.gameObject.GetComponent<ProcessHandle>().materialInPlace = true;
                Destroy(this.gameObject);


            }
        }
        else if (this.gameObject.tag == "Product" && collision.gameObject.tag == "Product") {
            if (collision.gameObject.GetComponent<ProcessHandle>().processing == false) {            
                this.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<ProcessHandle>().totalMatToProcess = this.GetComponent<MaterialInfoContainer>().totalMaterial;
                collision.gameObject.GetComponent<ProcessHandle>().moneyFactor = this.GetComponent<MaterialInfoContainer>().moneyGain;
                collision.gameObject.GetComponent<ProcessHandle>().materialInPlace = true;
                Destroy(this.gameObject);
                
            }
        }
        else if (clickedOn) {

        }


    }
}
