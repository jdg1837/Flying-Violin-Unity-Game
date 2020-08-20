using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameAI : MonoBehaviour {

	Node[] nodes = new Node[20];

	public Text m;
	public Text n;
	public Text o1;
	public Text o2;

	public GameObject g;
	public GameObject panel;

	public int node;
	public int lost;

	string eggs;

	public int bacon;

	public int next_text = 1;

	public bool is_over = false;

	// Use this for initialization
	void Start () {

		next_text = 1;

		fill ();

		Text main_text = m.GetComponent<Text> ();
		panel.SetActive (false);

		node = Save.Instance.next_node;

		eggs = nodes [node].intro [Save.Instance.lost];
		main_text.text = eggs;

		if (node >= 13 && node <=17 && Save.Instance.lost == 1)
			is_over = true;
	}

	// Update is called once per frame
	public void UpdateText () {

		Text main_text = m.GetComponent<Text> ();

		node = Save.Instance.next_node;

		if (is_over) {exit_game ();}

		if (next_text == 1) {
			eggs = nodes [node].main [0];
			main_text.text = eggs;
			next_text++;
		} 
		else if (next_text == 2) {
			eggs = nodes [node].main [1];
			main_text.text = eggs;
			next_text++;
		} 
		else if (next_text == 3) {
			if (nodes [node].next_node [0] == 20)
				endgame ();
			else
				show_panel ();
		} 
		else if (next_text == 4) {
			eggs = nodes [node].outro [bacon];
			main_text.text = eggs;
			next_text++;
		} 
		else if (next_text == 5) {
			Save.Instance.next_node = nodes [node].next_node [bacon];
			SceneManager.LoadScene (nodes [node].to_play [bacon]);
		}
	}

	void show_panel()
	{
		panel.SetActive (true);
		Text question_text = n.GetComponent<Text> ();

		string spam;

		spam = nodes [node].question;
		question_text.text = spam;

		Text op1 = o1.GetComponent<Text> ();
		Text op2 = o2.GetComponent<Text> ();

		spam = nodes [node].options [0];
		op1.text = spam;

		spam = nodes [node].options [1];
		op2.text = spam;
	}

	public void chose1()
	{
		bacon = 0;
		next_text++;
		panel.SetActive (false);
		UpdateText ();
	}

	public void chose2()
	{
		bacon = 1;
		next_text++;
		panel.SetActive (false);
		UpdateText ();
	}

	void endgame()
	{
		Text main_text = m.GetComponent<Text> ();

		if (node == 13 || node == 14) {
			if (Save.Instance.score >= 200)
				eggs = "With one resolute move, you renounce it. The power is too strong for a mortal to control. You leave the Keep, the Citadel, and the forest forever, burning your notes on your way out, the knowledge of what is in the keeps you have visited lost to man for the time being...";
			else
				eggs = "As the knowledge of horrible things comes to you, you are terrified for your immortal soul. Before you can go back, the power flows in you in all its might, but you are unable to wield it. You close your eyes as the power claims you, sending you to oblivion, another victim of greed and delusion.";
		}

		if (node == 15) {
			if (Save.Instance.score >= 200)
				eggs = "When all seems lost, you find the path and rush towards the town. The guards open the gate and take you to the Keep, where the Lady's healers do their best to help you. After you heal, you burn the notes you had, and vow to not seek that power again. As you get a new horse, you ride away, looking for your next Quest";
			else
				eggs = "Despite your best efforts, you cannot find your way outside of the woods. As another night comes, a storm rages, as you hear the moans of undead specters as they converge on your position. You unsheated your sword and prepare to make your last, futile stand...";
		}

		main_text.text = eggs;

		is_over = true;
	}

	void exit_game()
	{
		Save.Instance.next_node = 1;
		Save.Instance.score = 0;
		Save.Instance.lost = 0;
		SceneManager.LoadScene (0);
	}

	void fill()
	{
		//For Node 1

		Node buffer1 = new Node();

		buffer1.intro[0] = "You reach the edge of the woods at dawn. The land in front of you is just as rumors described it. Vast, rich, bountiful. Orchards on every mile as far as the eye can see, and right ahead, the town of Runswick Pass. You caress your horse's mane and start on your way, a smile on your face as you go. Finally, your quest truly begins";
		buffer1.main [0] = "You reach the town just as the stores are opening and the people go out into the cobbled main street. It is not a very large settlement, but you know where to go for answers. You station your horse right outside the biggest tavern you can find and get a tankard of that fabled cider.";
		buffer1.main[1] = "As you savor the apples of the land, you give an extra piece of copper to the friendly man behind the counter, asking where adventure awaits. He points wests. That is where the abandoned Grimtol Citadel lies, he tells you, lost to time in the middle of the dark forest no man calls home. Land to only sorrow and shadows of the past. He warns you not to go there as you finish the last of the cider and leave";
		buffer1.question = "As you are ready to exit the town on the west gate, you see the lady of the keep trying to organize a caravan to leave. She comes to you and asks for your help. Apparently, some storm caused destruction on the countryside the previous night, and her group is looking for survivors and stragglers. She says she will reward you for your time";
		buffer1.options[0] = "Go with her";
		buffer1.options[1] = "Go West";
		buffer1.outro[0] = "You grunt but nod. Perhaps the thing that caused mayhem in the land came from the woods, or from the abandoned Citadel. At any rate, having the Lady's favor may aid your quest. You leave the town quickly, and before you can complain, you are in charge of the caravan as it searches among the hills and the orchards...";
		buffer1.outro [1] = "This half of the game is still being developed. For that reason, you turn back and decide to help the caravan, after all";
		buffer1.next_node [0] = 2;
		buffer1.next_node [1] = 2;
		buffer1.to_play [0] = 2;
		buffer1.to_play [1] = 2;

		nodes[1] = buffer1;

		//For Node 2

		Node buffer2 = new Node();

		buffer2.intro[0] = "Your excellent guidance makes the search a success. In just a few hours you have rescued a couple dozen peasants. The join your caravan as you make your way to the next closest town, Yellowseed ";
		buffer2.intro[1] = "You lead the caravan in circles and through difficult terrain. A couple of horses and supply carts are lost in the marshes. Despite this, you manage to rescue a good amount of peasants as you make your way to Yellowseed \n";
		buffer2.main[0] = "As the caravan rides, the stories fly to you; they talk of dark beasts, and of a thunderstorm that is a clear harbinger of doom, they say. Whatever storm took place, it is totally cleared now, and the day bright as can be.";
		buffer2.main[1] = "Once you make it to Yellowseed, the Lady invites you to stay the night at the finest inn, on her coin, and gives you a map of the land, before bidding you farewell.\n";
		buffer2.question = "With the map and the coin, you are ready to start making your way to the lost Citadel. However, it is past noon by now, and leaving at this time may not be too wise, with the dark things that strike and night. On the other hand, waiting longer may be a bad idea as well...\n";
		buffer2.options[0] = "Leave on the morrow";
		buffer2.options [1] = "Leave immediately";
		buffer2.outro [0] = "You stay put, and on the morrow ride West.\nYou enter the woods with caution. They are dark, silent, and full of dead, twisted trees. Ahead you see a strange sight. Some gallows, a man is about to hang. You gallop there and are surprised to see three dark elves are the executioners. They offer to spare the man's life, if you play their twisted game of wits...";
		buffer2.outro [1] = "You decide to save the coin for another day, and immediately ride West, looking for the forest. As you enter it, dusk starts, followed by a terrible thunderstorm that makes you lose your path. You end up taking shelter in an abandoned house, and house that is haunted by the specters of its former inhabitants...";
		buffer2.next_node[0] = 4;
		buffer2.next_node[1] = 5;
		buffer2.to_play [0] = 4;
		buffer2.to_play [1] = 1;

		nodes[2] = buffer2;

		//For Node 4

		Node buffer4 = new Node();

		buffer4.intro[0] = "With your sharp wits your beat the elves at their own game. They curse you and promise you the forest will be the end of you, but being bound by their word, they banish into the trees as you rush to bring the man down";
		buffer4.intro[1] = "The elves laugh at you as they kick the log where the man stood. You charge with your sword as they attack back with sticks and stones they pick up. You push them aside and jump to pull the man down, breaking the branch on which he hung. The elves curse at you as they retreat into the woods. You are left hurt and battered, but both you and the man will live";
		buffer4.main [0] = "The man tells you he got captured on the edges of the woods during the storm and warns you to not go any deeper into that godforsaken land, but you send him on his way out and push deeper still.";
		buffer4.main [1] = "As dusk begins, you find the lost Citadel of Grimtol. It is just as described to you. Vast, beautiful, and broken. As the sun sets on the land, you look with awe at the abandoned buildings and the collapsed structures, all ruined by a war forgotten by time. Dead ahead, you see the looming tower of the inner keep";
		buffer4.question = "You look around. Some of these buildings would be good places to set up camp and get some rest. There may also be some things to find in there. However, the keep you have been searching for is right here...";
		buffer4.options[0] = "Search the Citadel and rest there";
		buffer4.options [1] = "Go straight to the keep";
		buffer4.outro [0] = "As you search the abandoned buildings, you find runes and relics, but nothing worth much. It looks like the place was looted clean a long time ago. As you enter a temple, to rest there, you are faced with an apparition, the specter of a wiseman, who challenges you to a game of wits and skill. You agree, sitting accross from him as he unloads a box of matches in front of you...";
		buffer4.outro [1] = "You decide there will be enough time in the morrow to search the Citadel. You go straight to the Keep, over the dried-out moat, past the large oak doors open and into the abandoned stone hall. As you explore the dungeons and crypts beneath the keep, you start hearing dark, inhuman sounds. Before you can say a prayer, four specters rise from the cold ground and charge at you!\n";
		buffer4.next_node[0] = 7;
		buffer4.next_node[1] = 8;
		buffer4.to_play [0] = 5;
		buffer4.to_play [1] = 1;

		nodes[4] = buffer4;

		//For Node 5

		Node buffer5 = new Node();

		buffer5.intro[0] = "You banish the ghosts quickly, and set up protections from any other unexpected visitors.";
		buffer5.intro[1] = "The specters catch you, and start filling your head with visions of things long gone. You cry as their sorrow becomes yours, and once the are done draining your energy, they dissappear, leaving you alone and cold in the dark hall";
		buffer5.main[0] = "You spend the night trying to rest in the abandoned stone house, as the thunderstorm rages outside and your horse makes awful noises. Thankfully, when dawn comes, the skies are cleared and the path to the Citadel is once more revealed";
		buffer5.main [1] = "You ride until you find the Citadel. You approach the ruined city by the broken main gate. You are surprised to see a Knight of the Order of the White Rose there. The wizards of the order were once the guardians of the Citadel, and this one seems to be guarding it still, even in death...";
		buffer5.question = "There does not seem to be another way in for a few miles. The wizard seems to not have noticed you yet...";
		buffer5.options[0] = "Challenge him";
		buffer5.options [1] = "Sneak past him";
		buffer5.outro [0] = "As you approach he looks up at you, smiling a horrible smile. You realize he is but a shadow, a dark being stuck on this mortal plane as he fulfill his duty. You open your palm and say the words, releasing the first ball of blue energy towards him. He stops it midair and sends it back at you...";
		buffer5.outro [1] = "You leave your horse away, and try to climb the wall behind him. He laughs with a terrible, disembodied voice, and uses magical force to push you off. As you get back on your feet, you realize he is but a shadow, a dark being stuck on this mortal plane as he fulfill his duty. Just as you focus your magical energy, he launches a ball of energy at you...";
		buffer5.next_node[0] = 9;
		buffer5.next_node[1] = 9;
		buffer5.to_play [0] = 3;
		buffer5.to_play [1] = 3;

		nodes[5] = buffer5;

		//For Node 7

		Node buffer7 = new Node();

		buffer7.intro[0] = "You smile as you see the man take the last stick. He bows and disappears, going back to his deep slumber, satisfied by your skill. Where he was standing you see a key. You run to the big door behind the altar, and smile to see it work. You open the door and go in";
		buffer7.intro[1] = "The man laughs at you as he vanishes back into oblivion. You are left with a bad taste in your mouth as you explore the temple. Behind the altar, you find a mysterious door, leading to the crypts that run under the Citadel. It takes you a few hours, but you manage to pick it open. Exhausted as you are, you go in";
		buffer7.main[0] = "You walk deep into the crypt, exploring the passages under the temple, and that connect to the Keep, your final destination";
		buffer7.main[1]  = "Once you make it into the Keep passageways, your torch goes out. Lost in the dark, you stumble around in the dark for hours, certain you have met your doom";
		buffer7.question = "Eventually, you start hearing some distant sounds. You try to follow them, until you are lost again";
		buffer7.options[0] = "Try to listen for the sound";
		buffer7.options [1] = "Try to backtrack";
		buffer7.outro [0] = buffer7.outro [1] = "Before you can do anything, you hear a loud moan, you follow it into a dark room. Inside, you see an undead wizard. You have seen heard of him. He used to be the partner of the King's advisor, before the doom came. He lifts a white oak wand and launches a ball of ice magic at you, as you prepare to return it to him...\";";
		buffer7.next_node[0] = 13;
		buffer7.next_node[1] = 13;
		buffer7.to_play [0] = 3;
		buffer7.to_play [1] = 3;

		nodes[7] = buffer7;

		//For Node 8

		Node buffer8 = new Node();

		buffer8.intro[0] = "With one last infernal scream, the specters are destroyed and banished to the cursed realm from whence they came. You take a minute to regain your strength and your sanity before pushing deeper into the dungeon";
		buffer8.intro[1] = "You scream in anguish, terror, and pain as you feel the specter attack you, and drain you of your soul energy. With one painful move you get your talisman, and with your dying breath you say the words that temporarily banish the specters. The process leaves you drained and broken";
		buffer8.main[0] = "You hear the scream of the specters reforming, making you rush deeper into the bowels of the keep";
		buffer8.main[1] = "You keep moving deeper into the darkest part of the dungeon, lost in silence...";
		buffer8.question = "As you reach the bottom level of the keep, you are faced with two doors. The inscriptions are in a lost tongue, but you have seen the symbols before. one rune stands for \"Will\", while the other stands for \"Wisdom\". They are challenges, you know, tests for you to prove you are worthy of that which you seek.\n";
		buffer8.options[0] = "Accept the challenge of Will\n";
		buffer8.options [1] = "Accept the challenge of Wisdom\n";
		buffer8.outro [0] = "You enter the room and see before you a dark, undead sorceress. You have seen her before. She used to be the King's advisor, before his foolhardy quest brought doom to his land. It seems that she remains loyal, even in death, protecting the piece he so treasured. She prepares her staff and launches a ball of death energy at you. You reach into your deepest place and bring out all the magical power you can muster, and prepare to return it to her...";
		buffer8.outro [1] = "Inside the room you find just a stone table and a pair of chairs. Sitting across the table is someone that was once called the wisest of his time, the advisor to King of Grimtol himself. He challenges you to a game, to prove you are worthy of the power that doomed his liege...";
		buffer8.next_node[0] = 13;
		buffer8.next_node[1] = 14;
		buffer8.to_play [0] = 3;
		buffer8.to_play [1] = 5;

		nodes[8] = buffer8;

		//For Node 9

		Node buffer9 = new Node();

		buffer9.intro[0] = "You look at the wizard's undead eyes as he vanishes from existance. You see some gratitude in his eyes, you think. Nevertheless, he shrieks and lounges at you, grabbing you and taking you with him...";
		buffer9.intro[1] = "As the last of the spells hits you, you collapse on the ground, the cold creeping into your heart. The specter stops you from dying and instead sends you another plane of existence, lost between life and death, as a form of penance...";
		buffer9.main[0] = "You find yourself in the twilight realm, lost in shadows in between here an nowhere, in a time that is never and in a world of complete silence";
		buffer9.main[1] = "You try to find your way out but get lost in the dark abbyss. You eventually realize you will need help to exit this world. You have two ideas";
		buffer9.question = "You think about finding the room where the power you seek is held. The specters there are too lost between planes, and they could return you to your world. Or you can go out into the woods, looking for magical creatures that can help you return to the land of the living";
		buffer9.options[0] = "Look for specters";
		buffer9.options [1] = "Exit to woods";
		buffer9.outro [0] = "After a long time of searching in the shadows, you find your way to the deepest level of the keep. Inside a dark room, you find a specter lost between planes too. The advisor to King of Grimtol sits there, guarding the runes. He returns you to the mortal plane, and challenges you to a game, to prove you are worthy of the power that doomed his liege...";
		buffer9.outro [1] = "You exit the Citadel and curse your quest. You traverse the dark world for days, searching the woods, until a group of dark elves happen upon you. They sense you, and bring you back into your world. Before you can thank them, they fashion a noose on a sturdy tree. As they explain in their tongue, they want you to play a game for your life...";
		buffer9.next_node[0] = 14;
		buffer9.next_node[1] = 15;
		buffer9.to_play [0] = 5;
		buffer9.to_play [1] = 4;

		nodes[9] = buffer9;

		//For Node 13

		Node buffer13 = new Node();

		buffer13.intro[0] = "It takes all of your strength, but you manage to succeed. The magician bows before you before opening the last door to the room guarded. With that, the apparition vanishes into oblivion, leaving you once more, alone in the dark...";
		buffer13.intro[1] = "The last ball to hit you is enough to take out the last of your energy, draining you of any life force. You collapse to your knees as a group of wizards approach you, staff in hand. With one last spell, they send you somewhere, somewhere dark, somewhere cold, you close your eyes and the darkness takes you... \nGAME OVER";
		buffer13.main[0] = "You enter the chamber and find it, inscribed on the wall, the words you need to obtain the power you seek. To control life and death, light and darkness, reality and oblivion.";
		buffer13.main [1] = " You reach for it, and begging reciting the words, words that have not been spoken for centuries, words that were last spoken by a king who was corrupted by the power you are about to be granted, words that will change the course of your life\n";
		buffer13.next_node[0] = 20;
		buffer13.to_play [0] = -1;

		nodes[13] = buffer13;

		//For Node 14

		Node buffer14 = new Node();

		buffer14.intro[0] = "You let a sigh of relief as you see the advisor take the last of the pieces. He nods solemnly and stands up, signaling at the door. As you exit the room, he retakes his seat in the darkness";
		buffer14.intro[1] = "He shakes his head, as if dissapointed, as you slowly take the last of the pieces. Before you can bargain for your life, the magical torhces on the wall of the dungeon go out one by one. After that, darkness takes over your world, as you leave this plane of existence...";
		buffer14.main[0] = "You enter the chamber and find it, inscribed on the wall, the words you need to obtain the power you seek. To control life and death, light and darkness, reality and oblivion.";
		buffer14.main [1] = " You reach for it, and begging reciting the words, words that have not been spoken for centuries, words that were last spoken by a king who was corrupted by the power you are about to be granted, words that will change the course of your life\n";
		buffer14.next_node[0] = 20;
		buffer14.to_play [0] = -1;

		nodes[14] = buffer14;

		//For Node 15

		Node buffer15 = new Node();

		buffer15.intro[0] = "You grunt as they cut the rope and let you fall you the ground. They curse at you and leave you alone";
		buffer15.intro[1] = "With one last snicker, they push away the log where you stood, and down you go....\nGAME OVER";
		buffer15.main[0] = "You undo your bindings and look around, trying to figure out the way out of this woods";
		buffer15.main [1] = "Days go by as you try to survive in these good forsaken woods, and as you try to find any sign of the path towards Yellowseed";
		buffer15.next_node[0] = 20;
		buffer15.to_play [0] = -1;

		nodes[15] = buffer15;
	}
}
