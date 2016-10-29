using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileData : MonoBehaviour {
	
	private int _tileIndex;
	private int _tileHeight;
	private bool _isPassable;
	private Transform _tileTransform;
	private Vector3 _position;
	private GameObject currentObject;

	private GameObject _ownedObject;	//contains object that currently on it
	private List<GameObject> _stackedTiles;
	public GameObject[] gos;

	private MeshRenderer _renderer;
	private MeshFilter _meshFilter;

	public TileData( GameObject go, int tileIndex, MeshRenderer renderer, MeshFilter meshFilter, Transform transform, bool isPassable){
  
		currentObject = go;
		_tileIndex = tileIndex;
		_renderer = renderer;
		_meshFilter = meshFilter;
		_isPassable = isPassable;
		_tileTransform = transform;

		_position = _tileTransform.position; 

	} 

	public int TileIndex{
		get{ return _tileIndex; }
		set{ _tileIndex = value; }
	}

	public bool IsPassable{
		get{ return _isPassable; }
		set{ _isPassable = value; }
	}

	public Transform TileTransform{
		get { return _tileTransform; }
		set { _tileTransform = value; }
	}

	public Vector3 Position{
		get { return _position; }
		set { _position = value; }
	}

	public GameObject OwnedObject{
		get{ return _ownedObject; }
		set{ _ownedObject = value; }
	}

	public int Height{
		get{ return _tileHeight; }
		set{ 
			_tileHeight = value;  
		}
	}

	//Dynamically set tile mesh
	public void SetMesh(Mesh mesh){	
		_meshFilter.mesh = mesh;
	}

	//Dynamically set tile material
	public void SetMaterial(Material material){
		_renderer.material = material;
	}

	//Editor Functions
	public void Rotate(int angle){
		_tileTransform.Rotate (new Vector3 (0, angle));
	}

	public void AddHeight(GameObject go){

		Vector3 goPosition = go.transform.position;
		goPosition.y++;
		Instantiate (go, goPosition, go.transform.rotation); 
		_tileHeight++;
	}

}
