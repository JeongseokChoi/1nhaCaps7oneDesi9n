/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class CustomTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
	bool firstDetected = false;

	int i=0, j, random_result;
	int[] temp = new int[10]; // 
	bool bool_tmp = false;
	
	public GameObject[] menu_object = new GameObject[10];


    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    
    #endregion // PRIVATE_MEMBER_VARIABLES


    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

		
		// MENU_NUMBER random setting
		for(i=0; i<10; i++){
			bool_tmp = false;
			while( bool_tmp != true ){
				
				random_result = Random.Range (0,10);
				bool_tmp = true;
				for( j=0; j<i; j++){
					if( random_result == temp[j] ){
						bool_tmp = false;
						break;
					}
				}
			}
			
			temp[i] = random_result;
			
		}

		for (i=0; i<10; i++) {	
			float temp_X = menu_object[i].transform.position.x;
			float temp_Y = menu_object[i].transform.position.y;
			float temp_Z = menu_object[i].transform.position.z;

			if( temp[i] == 1 || temp[i] == 4 || temp[i]== 7 ) menu_object[i].transform.position = new Vector3(-180.0f, temp_Y, temp_Z);
			else if( temp[i] == 2 || temp[i] ==  5 || temp[i] == 8 || temp[i] == 0 ) menu_object[i].transform.position = new Vector3(0.0f, temp_Y, temp_Z);
			else if( temp[i] == 3 || temp[i] ==  6 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(180f, temp_Y, temp_Z);

			temp_X = menu_object[i].transform.position.x;
			
			if( temp[i] == 1 || temp[i] == 2 || temp[i] == 3 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 360.0f);
			else if( temp[i] == 4 || temp[i] == 5 || temp[i] == 6 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 180.0f);
			else if( temp[i] == 7 || temp[i] == 8 || temp[i] == 9 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, 0.0f);
			else if( temp[i] == 0 ) menu_object[i].transform.position = new Vector3(temp_X, temp_Y, -180.0f);
		}
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
			if (firstDetected == false)
			{
				OnTrackingLost();
				firstDetected = true;
			}
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}

    #endregion // PRIVATE_METHODS
}
