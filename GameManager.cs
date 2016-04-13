using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player current_player;
    Player[] all_players = new Player[2];
    [SerializeField]
    Material[] player_mats = new Material[2];


	void Start () {
        for (int i = 0; i < 2; i++)
            all_players[i] = new Player(i, "Player_" + i, player_mats[i]);
        current_player = all_players[0];
	}

    void FixedUpdate() {
        if (Input.GetMouseButtonUp(0)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                print(hit.transform.gameObject.name);
                Tile tile = hit.transform.gameObject.GetComponent<Tile>();
                tile.Place();
            }
        }
    }
}
