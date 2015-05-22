using UnityEngine;
using System.Collections;

public class TeamMember : MonoBehaviour {

	int _teamID = 0;
	public int teamID {
		get { return _teamID; }
	}

	[RPC]
	void SetTeamID(int id) {
		_teamID = id;

		MeshRenderer mySkin = this.transform.GetComponentInChildren<MeshRenderer>();
		
		if(mySkin == null) {
			Debug.LogError("Couldn't find a SkinnedMeshRenderer!");
		}
		
		if(_teamID==1)  // red
			mySkin.material.color = Color.red;
		if(_teamID==2)  //green
			mySkin.material.color = new Color(.5f, 1f, .5f);
	}
}
