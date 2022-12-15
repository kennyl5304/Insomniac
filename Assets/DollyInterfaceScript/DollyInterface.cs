using UnityEngine;
using System.Collections;

/* ####################################################
 * Dolly Effect Script - 27 of March 2015 - Created by Rob de Jager (www.tinyflame.co.uk)
 * Simple script that can be used with the Oculus Rift to add a Dolly or Vertigo effect to your scene(s)
 * An example of the script in action can be found here: https://www.youtube.com/watch?v=UfhAJR4cjzU
 * 
 * This script works with the Oculus Rift OVR scripts that should come with the Unity Integration package
 * available from the Oculus Rift site.
 * *IMPORTANT* Please note this script does not require the original OVR scripts to be modified in anyway!
 * 				This was done to ensure the Oculus license agreement was adhered to.
 * 				It simply sets the FOV of the eye anchors that the OVRCameraRig uses
 * 				and this is done during runtime.
 * * HOW TO USE* Using the script is pretty straight forward.
 * 				 Attach it to the OVRCameraRig object, then assign a target gameObject to the target field in the inspector
 * 				 That's it! Now you'll have a basic dolly effect applied to the rift using the target gameObject as the point
 * 				 reference.
 *  *DISCLAMER* This script comes in an AS IS form
 * 				I made it for a project and thought it might be useful to others.
 * 				I tested this script with the Oculus Rift (DK2) I don't know how it will work on other Dev kits!
 * 				There is no guarantee this script will keep working with future Oculus SDK releases since I can't tell the future :P
 * 				I don't own the Oculus script that this script attaches to either. Please see their documentation for info and legal stuffs
   #################################################### */
public class DollyInterface : MonoBehaviour {

	//Public variable declarations
	public Transform target;

	//Private variable declarations
	private float intHeightAtDistace;
	private bool dzEnabled;
	private OVRCameraRig getOvrCam;

	// Use this for initialization
	void Start () {

		if(target != null)
		{
			// distance between two points in Vec3
			float distance = Vector3.Distance(transform.position, target.position);
			intHeightAtDistace = FrustumHeightAtDistance(distance);
			dzEnabled = true;
			//get the OVRCameraRig to access its juicy datas!
			getOvrCam = GameObject.Find("OVRCameraRig").gameObject.GetComponent<OVRCameraRig>();
		}else{
			Debug.LogError("Target GameObject Not Assigned! Please assign a GameObject to target.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*The dzEnabled bool is all set up but it's not used in this script
		* It can be used to enable/disable the effect with a bit more work
		* There is also no "reset effect" mechanic since I didn't want to just reset to the original position
		* As this could disorient the player with a "snap to position" effect. */
		if (dzEnabled) {
			// Measure the new distance and readjust the FOV accordingly.
			float currDistance = Vector3.Distance(transform.position, target.position);
			//adjust the FOV of the anchors, this in turn is used by the OVRCameraRig in EnsureGameObjectIntegrity(); to set the
			// eye cameras.
			getOvrCam.leftEyeAnchor.GetComponent<Camera>().fieldOfView = FOVForHeightAndDistance(intHeightAtDistace, currDistance);
			getOvrCam.rightEyeAnchor.GetComponent<Camera>().fieldOfView = FOVForHeightAndDistance(intHeightAtDistace, currDistance);
		}

		// Simple movement control - this can be set to anything or removed for your own movement code
		transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 5);
	}

	// Calculate the frustum height at a given distance from the camera.
	public float FrustumHeightAtDistance(float distance) {
		return 2.0F * distance * Mathf.Tan(GetComponentInChildren<Camera>().fieldOfView * 0.5F * Mathf.Deg2Rad);
	}
	
	// Calculate the FOV needed to get a given frustum height at a given distance.
	public float FOVForHeightAndDistance(float height, float distance){
		return 2 * Mathf.Atan(height * 0.5F / distance) * Mathf.Rad2Deg;
	}
	
	// Turn dolly zoom off.
	public void StopDZ() {
		dzEnabled = false;
	}
}
