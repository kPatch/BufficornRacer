using System.Collections;
using System.Collections.Generic;
using TS.Generics;
using UnityEngine;

public class GameExtensionManager : MonoBehaviour
{
    public AudioClip impact;
    public AudioSource audioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(impact, 0.7F);
    }

    public void DirectJoinGame()
    {
        InfoRememberMainMenuSelection.instance.playerMainMenuSelection.currentGameMode = 0;
        SelectVehicleArcadeTimeTrial();
        string trackName = GameModeGlobal.instance.currentSelectedTrack;
        LoadScene.instance.LoadSceneWithSceneNameAndSpecificCustomMethodList(trackName);

    }

    public void SelectVehicleArcadeTimeTrial()
    {
        //-> Arcade Mode
        if (InfoRememberMainMenuSelection.instance.playerMainMenuSelection.currentGameMode == 0)
        {
            GameModeGlobal.instance.vehicleIDList.Clear();
            int howManyVehicle = DataRef.instance.arcadeModeData.howManyVehicleByRace;
            int HowManyPlayers = InfoRememberMainMenuSelection.instance.playerMainMenuSelection.HowManyPlayer;

            //-> Add Player vehicle Prefab ID to cars list
            for (var i = 0; i < HowManyPlayers; i++)
            {
                GameModeGlobal.instance.vehicleIDList.Add(InfoVehicle.instance.listSelectedVehicles[i]);
            }

            //-> Add AI vehicle Prefab ID to cars list
            List<int> tmpListVehicleAI = listVehicleAI(howManyVehicle);
            for (var i = 0; i < tmpListVehicleAI.Count; i++)
            {
                GameModeGlobal.instance.vehicleIDList.Add(tmpListVehicleAI[i]);
            }
        }
        //-> Time Trial
        else if (InfoRememberMainMenuSelection.instance.playerMainMenuSelection.currentGameMode == 1)
        {
            GameModeGlobal.instance.vehicleIDList.Clear();
            int HowManyPlayers = InfoRememberMainMenuSelection.instance.playerMainMenuSelection.HowManyPlayer;
            //-> Add Player vehicle Prefab ID to cars list
            for (var i = 0; i < HowManyPlayers; i++)
            {
                GameModeGlobal.instance.vehicleIDList.Add(InfoVehicle.instance.listSelectedVehicles[i]);
            }
        }
    }

    List<int> listVehicleAI(int _howManyVehicle)
    {
        List<int> tmpListVehicleAI = new List<int>();

        int howManyVehicleAvailable = DataRef.instance.vehicleGlobalData.carParametersList.Count;
        int howManyVehicleInTheRace = _howManyVehicle;
        int HowManyPlayers = InfoRememberMainMenuSelection.instance.playerMainMenuSelection.HowManyPlayer;

        //-> Create the AI car list
        for (var i = 0; i < howManyVehicleAvailable; i++)
            tmpListVehicleAI.Add(i);

        //-> Remove from that list player cars
        for (var i = 0; i < HowManyPlayers; i++)
        {
            for (var j = 0; j < tmpListVehicleAI.Count; j++)
            {
                if (tmpListVehicleAI[j] == InfoVehicle.instance.listSelectedVehicles[i])
                {
                    tmpListVehicleAI.RemoveAt(j);
                    break;
                }
            }
        }

        /*string s = "";
        foreach (int value in tmpListVehicleAI)
            s += value + "|";
        Debug.Log("tmpListVehicleAI: " + s);
        */

        //-> Randomize the list
        List<int> listRandomized = new List<int>();
        int listSize = tmpListVehicleAI.Count;

        while (listRandomized.Count < howManyVehicleInTheRace - HowManyPlayers)
        {
            List<int> tmpListVehicleAICopy = new List<int>(tmpListVehicleAI);
            for (var i = 0; i < listSize; i++)
            {
                int rand = UnityEngine.Random.Range(0, tmpListVehicleAICopy.Count);

                listRandomized.Add(tmpListVehicleAICopy[rand]);
                tmpListVehicleAICopy.RemoveAt(rand);

                if (listRandomized.Count == howManyVehicleInTheRace - HowManyPlayers)
                    break;
            }
        }

        /*s = "";
        foreach (int value in listRandomized)
            s += value + "|";

        Debug.Log("listRandomized: " + s);
        */
        return listRandomized;
    }
}
