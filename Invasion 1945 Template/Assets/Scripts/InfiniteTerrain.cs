using UnityEngine;
using System.Collections;

public class InfiniteTerrain : MonoBehaviour
{
	public GameObject PlayerObject;
	public GameObject linkedBg;

	private GameObject[] _bgGrid = new GameObject[3];

	private bool alternateBgFlip = true;

	void Start ()
	{
		
		_bgGrid[0] = (GameObject)Instantiate (Resources.Load("space2"), linkedBg.transform.position, linkedBg.transform.rotation);
		_bgGrid[1] = linkedBg;
		_bgGrid[2] = (GameObject)Instantiate (Resources.Load("space2"), linkedBg.transform.position, linkedBg.transform.rotation);

		UpdateTerrainPositionsAndNeighbors();
	}
	
	private void UpdateTerrainPositionsAndNeighbors()
	{
		_bgGrid[0].transform.position = new Vector3(
			_bgGrid[1].transform.position.x,
			_bgGrid[1].transform.position.y - 2*_bgGrid[1].GetComponent<SpriteRenderer>().bounds.extents.y,
			_bgGrid[1].transform.position.z);



		_bgGrid[2].transform.position = new Vector3(
			_bgGrid[1].transform.position.x,
			_bgGrid[1].transform.position.y + 2*_bgGrid[1].GetComponent<SpriteRenderer>().bounds.extents.y,
			_bgGrid[1].transform.position.z);

		if(alternateBgFlip) {
			Vector3 newScale = _bgGrid[0].transform.localScale;
			newScale.x *= -1;
			_bgGrid[0].transform.localScale = newScale;



			alternateBgFlip = false;
		}

		Vector3 newScale2 = _bgGrid[2].transform.localScale;
		newScale2.x *= -1;
		_bgGrid[2].transform.localScale = newScale2;


		
	}

	void Update ()
	{
		if (PlayerObject != null) {
			Vector3 playerPosition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y, PlayerObject.transform.position.z);
			GameObject playerTerrain = null;

			//Debug.Log (playerPosition.y + " " + _bgGrid[0].transform.position.y + 2*_bgGrid[0].GetComponent<SpriteRenderer>().bounds.extents.y);

			if (playerPosition.y >= (_bgGrid[1].transform.position.y - _bgGrid[1].GetComponent<SpriteRenderer>().bounds.extents.y) && 
				playerPosition.y <=  (_bgGrid[1].transform.position.y + _bgGrid[1].GetComponent<SpriteRenderer>().bounds.extents.y))
			{
				playerTerrain = _bgGrid[1];
			}

			if (playerPosition.y >= (_bgGrid[2].transform.position.y - _bgGrid[2].GetComponent<SpriteRenderer>().bounds.extents.y) && 
				playerPosition.y <=  (_bgGrid[2].transform.position.y + _bgGrid[2].GetComponent<SpriteRenderer>().bounds.extents.y))
			{
				playerTerrain = _bgGrid[2];
			}


			if (playerTerrain == _bgGrid[2])
			{
				GameObject[] newBgGrid = new GameObject[3];

				newBgGrid[0] = _bgGrid[1];
				newBgGrid[1] = _bgGrid[2];
				newBgGrid[2] = _bgGrid[0];
				_bgGrid = newBgGrid;

				UpdateTerrainPositionsAndNeighbors();
			}
		}


	}

}
