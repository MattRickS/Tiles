using UnityEngine;
using System.Collections;

public class Player {

    public int id;
    public string name;
    public Material mat;

    public Player(int _id, string _name, Material _mat) {
        id = _id;
        name = _name;
        mat = _mat;
    }
}
