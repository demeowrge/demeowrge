using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public Transform prefabFieldSprite;
	public int fieldWidth;
	public int fieldHeight;
	public int ditchYPosition;
	
	public int pxTileWidth;
	public int pxTileHeight;
	
	// Draw field
	void Start () {
		Transform newTile;
		float TileWidth = pxTileWidth * 0.01f; // pixels to space
		float TileHeight = pxTileHeight * 0.01f;
		
		for (int i = 0; i < fieldWidth; i++){ //Copy-Paste
			for (int j = 0; j < fieldHeight; j++){ 
				if(j!=ditchYPosition){
					newTile = Instantiate(prefabFieldSprite, new Vector3(transform.position.x + i * TileWidth,
					                                                     transform.position.y + j * TileHeight,0), transform.rotation) as Transform;
					newTile.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));

					newTile.parent = transform;
				}
			}
		}


	}
}
