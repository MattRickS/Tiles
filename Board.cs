using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

    public Tile[,] tiles = new Tile[25, 25];

	// Use this for initialization
	void Start () {
        for (int x = 0; x < 5; x++) {
            for (int z = 0; z < 5; z++) {
                GameObject sector = Instantiate(Resources.Load("Sector", typeof(GameObject))) as GameObject;
                sector.transform.position = new Vector3(x * 5 + 2, 0.0f, z * 5 + 2);
                sector.transform.parent = gameObject.transform;
                sector.name = (x * 5 + z).ToString();
                sector.GetComponent<Sector>().Init(this, x, z);
            }
        }
        for (int i = 0; i < 25; i++) {
            for (int j = 0; j < 25; j++) {
                print(tiles[i, j]);
                //tiles[i, j].getNeighbours(i, j);
            }
        }
	}	
}
