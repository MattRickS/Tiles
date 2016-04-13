using UnityEngine;
using System.Collections;

public class Sector : MonoBehaviour {

    Board board;
    int x;
    int z;


    void Start() {
        board = GameObject.Find("Board").GetComponent<Board>();
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                GameObject tile = Instantiate(Resources.Load("Tile_Base", typeof(GameObject))) as GameObject;
                tile.transform.position = new Vector3(x * 5 + i, 0.0f, z * 5 + j);
                tile.transform.parent = gameObject.transform;
                tile.name = (i * 5 + j).ToString();
                tile.GetComponent<Tile>().Init(board, x * 5 + i, z * 5 + j);
                //board.tiles[x * 5 + i, z * 5 + j] = tile.GetComponent<Tile>();
            }
        }
    }

    public void Init(Board _board, int _x, int _z) {
        board = _board;
        x = _x;
        z = _z;
    }
    
}
