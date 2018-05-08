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
        if (!TutorialManager.inTutorial) {
            if(materialInPlace) {
//				ProgressBar ();
                processing = true;
                timePassed++;
                if (timePassed == factorySettings.productionSpeed) {
                    timePassed = 0;
                    //if (materialInPlace) {
                        ProduceWaste();
                        ProduceMoney();
                        ProduceRecycleWaste();
                        materialInPlace = false;
                        processing = false;
                }
            }
        }
   }

    void ProduceMoney() {
        GameObject money = Instantiate(factorySettings.product);
        money.transform.position = this.transform.position;
        money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);
        MaterialInfoContainer script = money.AddComponent<MaterialInfoContainer>();
        script.moneyGain = factorySettings.moneyFactory;
        script.totalMaterial= factorySettings.production * (factorySettings.efficientcyPercentage/100);


    }
    void ProduceWaste() {
        GameObject nonRecycleWaste = Instantiate(factorySettings.nonRecycleWaste);
        nonRecycleWaste.transform.position = this.transform.position;
        nonRecycleWaste.transform.position = new Vector3(nonRecycleWaste.transform.position.x *1.1f, 2, nonRecycleWaste.transform.position.z);
        nonRecycleWaste.AddComponent<MaterialInfoContainer>().productWaste = factorySettings.wasteProduction;

        // PlayerInfo.totalRawMat = (PlayerInfo.totalRawMat - PlayerInfo.totalRawMatUsed) + PlayerInfo.circularity;
    }

    void ProduceRecycleWaste() {
        GameObject recycleWaste = Instantiate(factorySettings.recycleWaste);
        recycleWaste.transform.position = this.transform.position;
        recycleWaste.transform.position = new Vector3(recycleWaste.transform.position.x  *0.9f, 2, recycleWaste.transform.position.z);
        recycleWaste.AddComponent<MaterialInfoContainer>().productRecycle = factorySettings.recyclableWasteProduction;
    }

    public static void AddValues() {
        PlayerInfo.totalWaste += addedWaste;
        PlayerInfo.totalRecycleWaste += recycleWaste;
        PlayerInfo.totalRawMatUsed += production;
    }

	/*void ProgressBar(){
		Canvas canvas =this.gameObject.AddComponent<Canvas>();
		canvas = progressCanvas;
		GameObject progressBar1 = Instantiate (progressBar,canvas.transform) as GameObject;
		progressBar1.transform.position = this.transform.position;
		progressBar1.transform.position = new Vector3 (progressBar1.transform.position.x, 1, progressBar1.transform.position.z);

	}*/
}
