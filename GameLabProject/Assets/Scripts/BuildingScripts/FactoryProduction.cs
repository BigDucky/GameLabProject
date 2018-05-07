using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryProduction : MonoBehaviour {

    BuildingData factorySettings;
    public static float addedWaste;
    public static float recycleWaste;
    public static float production;

    public bool processing;
 
    private int timePassed;
    public bool materialInPlace;

	public Slider progressBar;
	public Canvas progressCanvas;

	/*public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	*/


    // Use this for initialization
    void Start() {
        factorySettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        addedWaste = factorySettings.wasteProduction;
        recycleWaste = factorySettings.recyclableWasteProduction;
        production = factorySettings.production;
		progressBar.value = 0;
    }

    private void Update() {
		if (Input.GetKey("C")) {
			ProgressBarCalculator ();
			Debug.Log ("pressed C");
		}

		Debug.Log ("FactoryProduction script is running");


        if (!TutorialManager.inTutorial) {
            if(materialInPlace) {
                processing = true;
                timePassed++;
                if (timePassed == factorySettings.productionSpeed) {
                    timePassed = 0;
                    if (materialInPlace) {
                        ProduceWaste();
                        ProduceMoney();
                        ProduceRecycleWaste();
                        materialInPlace = false;
                        processing = false;
						ProgressBarCalculator ();

						// OnGUI ();
						//barDisplay = Time.time*0.05f;
                    }
                }
            }
        }
    }

    void ProduceMoney() {
        GameObject money = Instantiate(factorySettings.product);
        money.transform.position = this.transform.position;
        money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);

    }
    void ProduceWaste() {
        GameObject nonRecycleWaste = Instantiate(factorySettings.nonRecycleWaste);
        nonRecycleWaste.transform.position = this.transform.position;
        nonRecycleWaste.transform.position = new Vector3(nonRecycleWaste.transform.position.x *1.1f, 2, nonRecycleWaste.transform.position.z);
       // PlayerInfo.totalRawMat = (PlayerInfo.totalRawMat - PlayerInfo.totalRawMatUsed) + PlayerInfo.circularity;
    }

    void ProduceRecycleWaste() {
        GameObject recycleWaste = Instantiate(factorySettings.recycleWaste);
        recycleWaste.transform.position = this.transform.position;
        recycleWaste.transform.position = new Vector3(recycleWaste.transform.position.x  *0.9f, 2, recycleWaste.transform.position.z);
    }

    public static void AddValues() {
        PlayerInfo.totalWaste += addedWaste;
        PlayerInfo.totalRecycleWaste += recycleWaste;
        PlayerInfo.totalRawMatUsed += production;
    }

	public void ProgressBarCalculator(){
		progressBar.value += timePassed;

	}


	/*

	public void OnGUI() {
		//draw the background:
		//pos = new Vector2 (this.transform.position.x, this.transform.position.y);


		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	*/
}
