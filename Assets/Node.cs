using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public int o_num;
	public int main_size;

	public string[] intro = new string[2];
	public string[] main = new string[2];
	public string question;
	public string[] options = new string[3];
	public string[] outro = new string[3];

	public int[] next_node = new int[3];
	public int[] to_play = new int[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
