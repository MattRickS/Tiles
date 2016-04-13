using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

    public bool disconnected = false;
    public bool structure = false;
    public bool edge = false;

    public int x;
    public int z;
    GameManager gm;
    Player player;
    Board board;
    List<Player> stack = new List<Player>();
    List<Tile> neighbours = new List<Tile>();
    TextMesh text;

    void Awake() {
        text = gameObject.GetComponentInChildren<TextMesh>();
    }

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        board = gameObject.transform.parent.GetComponentInParent<Board>();
        if (x == 0 || x == 24 || z == 0 || z == 24) { edge = true; }
        text.text = string.Format("{0}\n {1}", x, z);
        board.tiles[x, z] = this;
        if (edge)
            Draw();
    }

    //TESTER
    public void Draw() {
        GameObject tile = Instantiate(Resources.Load("Tile", typeof(GameObject))) as GameObject;
        tile.transform.position = new Vector3(x, 0.1f, z);
    }


    // Properties
    public int Height {
        get { return stack.Count; }
    }


    // Member Functions
    public void Init(Board _board, int _x, int _z) {
        board = _board;
        x = _x;
        z = _z;
    }


    public void getNeighbours(int _x, int _z) {
        x = _x;
        z = _z;
        if (x > 0) { neighbours.Add(board.tiles[x - 1, z]); }
        if (x < 24) { neighbours.Add(board.tiles[x + 1, z]); }
        if (z > 0) { neighbours.Add(board.tiles[x, z - 1]); }
        if (z < 24) { neighbours.Add(board.tiles[x, z + 1]); }
    }


    bool heightCheck(Player current_player) {

        foreach (Tile neighbour in neighbours) {
            if (neighbour.Height <= this.Height)
                continue;
            if (neighbour.stack[this.Height] == current_player && neighbour.Height == this.Height + 1)
                return true;
        }

        return false;

    }


    bool valid(Player current_player) {

        if (this.edge) {
            if (this.player == current_player || this.player == null)
                return true;
            else {
                return heightCheck(current_player);
            }
        }

        return heightCheck(current_player);

    }


    public void Place() {

        Player current_player = gm.current_player;

        // TESTER
        string n = "";
        foreach (Tile neighbour in neighbours) {
            n += neighbour.name + " ";
            GameObject tile = Instantiate(Resources.Load("Tile", typeof(GameObject))) as GameObject;
            tile.transform.position = new Vector3(neighbour.x, 0.0f, neighbour.z);
        }
        GameObject tile2 = Instantiate(Resources.Load("Tile", typeof(GameObject))) as GameObject;
        tile2.transform.position = new Vector3(x, 0.0f, z);
        tile2.GetComponent<Renderer>().material = current_player.mat;
        print (n);


        if (this.valid(current_player)) {
            if (this.player == current_player)
                structure = true;
            else
                structure = false;
            stack.Add(current_player);
            player = current_player;

            GameObject tile = Instantiate(Resources.Load("Tile", typeof(GameObject))) as GameObject;
            tile.transform.position = new Vector3(x, 0.2f * this.Height, z);
            tile.transform.parent = gameObject.transform;
            tile.GetComponent<Renderer>().material = player.mat;
        }
    }
}
