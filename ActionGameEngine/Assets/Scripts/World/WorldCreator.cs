using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCreator : MonoBehaviour {

	private Camera IsometricCamera;

	public GameObject TileSpawner;
	private Vector3 _tileSpawnerPosition;
	public GameObject tile;

	//indexing mesh collection, allowing a tile be able to have it's mesh set dynamically
	public MeshFilter[] Meshes;

	//indexing material collection, allowing a tile be able to have it's material set dynamically
	public Material[] Mats;

	//use this in editor to set generated map's size (x for row, z for column)
	public Vector3 MapSize;

	//indexing the tiles to make easier to get a tile info
	private Dictionary<int, TileData> _tileDatas;

	private const float _stepX = 1;
	private const float _stepY = 1;
	private const float _stepZ = 1;

	//array to build
	//legend : {materialIndex, meshIndex, rotation, height, isPassable}
	private int[,] mapData;


	// Use this for initialization
	void Start () {
		mapData = new int[,] {	{ 1,1,0,0,1 }, { 2,2,0,0,1 }, { 2,2,0,1,1 }, { 2,2,0,0,1 } };
		_tileDatas = new Dictionary<int, TileData> ();
		IsometricCamera = Camera.main;
		_tileSpawnerPosition = TileSpawner.transform.position;
		GenerateWorld (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateWorld(){
		int index = 0;
		for (int row = 0; row < MapSize.x; row++) {
			for (int column = 0; column < MapSize.z; column++) {
				GenerateTile (_tileSpawnerPosition, index ); 
				_tileSpawnerPosition.z += _stepZ;
				index++;
			}
			_tileSpawnerPosition.x += _stepX;
			_tileSpawnerPosition.z = 0;
		}

	}

	public void GenerateTile( Vector3 position, int index ){
		 

		GameObject tileGO = Instantiate ( tile, position, Quaternion.identity ) as GameObject;
		TileData data = tileGO.GetComponent<TileData> (); 
		MeshRenderer renderer = tileGO.GetComponent<MeshRenderer> ();
		MeshFilter meshfilter = tileGO.GetComponent<MeshFilter> ();
		Transform transform = tileGO.transform;
 
		Material material = Mats[mapData[index,0]-1];
		Mesh mesh = Meshes[mapData[index,1]-1].sharedMesh;

		data = new TileData ( tileGO, index, renderer, meshfilter, transform, true);

		data.SetMesh (mesh);
		data.SetMaterial (material);
		data.Rotate(mapData[index,2]);
		data.Height = mapData [index,3];

		if (mapData[index,4] == 0) {
			data.IsPassable = false;
		} else {
			data.IsPassable = true;
		}
 
	}
 
}
