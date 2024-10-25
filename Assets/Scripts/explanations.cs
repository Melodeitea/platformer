using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explanations : MonoBehaviour
{
	/*
	 * Basically quick summary for what I've added, references and stuff
	 * those with // havent been made yet on 25/10 but will i even remember to update this? (i actually did!)
	 * 
	 * collectables : inventory items (btw yes the sun is totally useless but i found the animation n thought it was cute I'm just a girl (rlly hoping you won't check that doc it's a lot of brainrot))
	 *					money counter (see if I've added the buying/selling system i wanted to do cuw idk if i'll remember to update this doc
	 *					the potions and items ig
	 * controller mecanic : dash
	 * random feature : for now I've got the inventory
	 *					Parallax background (fixed w/ 3D camera)
	 *					we also got the animations (hoping they won't break i almost died making them (no joke))
	 *					very simple Level design (that shows background anim + dash mechanic) if I don't die doing the rest of my homework 
	 *						(probs will, why the fuck do i have to do logos when i'm literally in game design and not graphic design 
	 *						(that means you should check on my vitals if there's no level design)
	 *					Health potions that actually work (don't think i'll do this one tho bc then I'd have to code a health bar and so enemies and so attacks unless i do some booby traps?
	 *					//traps???
	 *					rn it's not working (i mean it is but character goes through it)
	 *					health bar
	 *					//need to comment code!!
	 *					
	 *					
	 *  Now for the references
	 *	official debugger : Maxence in third year (hire him) helped me fix my broken physics on my dash (also said my serialized fields and coroutines were cool so yes thank you for the praise i love it) 
	 *	he also fixed some issues i had with animations transitions
	 *	UI was made with videos https://youtu.be/DLAIYSMYy2g?si=GkvgbnVY3I4fUKos and https://youtu.be/OG7vHstkZqM?si=WYujHTNXGTH7gBem
	 *	Also used a video for the base of the health bar, that I later modified to work with the spikes https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=634s
	 *	I also used some of their sprites
	 *	Other art was found here : https://craftpix.net/freebies/free-fantasy-chibi-female-sprites-pixel-art/ (we love female representations that's badass af might code a skin pick menu later)
	 *	And here : https://craftpix.net/freebies/free-crystal-cave-pixel-art-backgrounds/
	 *	also here : https://kairosolo.itch.io/simple-pixel-art-spikes?download
	 *	chat gpt helped with inputs cuz i still don't understand how that shit works
	 *		fixed my lack of brain bc the actual problem was that the script wasnt assigned to the mf button
	 *	what else?
	 *	I forgot
	 *	let's reference the unity doc bc i'm a big RTFM adept
	 *	https://docs.unity.com
	 *	i think i've read like 3/4 of it 
	 *	
	 *	More precision on this, I'll make a list of the specific pages (most from the Unity scripting API doc, the last one is from Microsoft Learn) i've checked out for these scripts:
	 *		Object.ToString
	 *		Time.deltaTime
	 *		Rect
	 *		RawImage
	 *		Coroutine
	 *		Input
	 *		SerializeField
	 *		TextMesh Pro
	 *		IEnumerator Interface
	 *		Some more research on how sliders work (for UI)
	 *		quaternion
	 *
	 *	lacking some sleep and overdosing on coffee rn
	 *	can i use this space to mention i don't like algobox at all?
	 *	I'll do it anyway (double meaning here, i want the bonus point and i love complaining)
	 *	Is that enought commentary?
	 *	Also why are people using // so much when	/* */    /* exist ?
	 *  genuine question
	 *  I do want to mention that Unity migh have given me my will to live back, I'm having lots of fun I can't wait to get better at it (that's cheesy af)
	 *  btw ça m'a pris le sang d'une vierge et trois sacrifices pour que ça fonctionne donc si ça pète au build je me défenêstre
	 *  also im hoping you wont mind the bilingual comments cuz i defo wont redo them
	 */
}
/* ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡟⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡯⣝⠼⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⣱⢮⣙⠾⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⢳⢱⡎⡎⣷⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⡳⢎⡳⢎⣝⡲⢭⣻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢭⡛⡼⣍⠶⣍⡳⣜⣻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡷⣄⡀⠪⣶⣩⠞⣥⠳⣎⢵⣻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⢿⡱⢫⡝⡶⠄⠹⠿⣎⡳⢭⡲⢣⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⢯⢧⣙⢧⣹⢚⡝⢦⠐⣲⢭⠳⣍⡏⣞⣻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠿⣩⠶⣩⢖⣣⢏⡞⡵⣚⠵⣪⢛⡴⡹⢆⡳⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣏⢻⠴⣫⠵⢮⡱⢞⡼⡱⡭⢞⣱⢫⣜⠳⣭⠳⣍⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡳⢎⡝⡮⣕⢫⠮⣕⣫⡶⠟⠷⢯⣜⣣⢞⣹⠲⡝⣎⡳⣻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡱⣍⠯⡼⣱⢎⣏⣳⡞⠁⠀⠀⠀⠀⠙⣾⣜⢲⢫⠵⣎⡵⢣⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⢷⣱⢎⡹⡶⢇⡾⣆⡿⠀⠀⠀⠀⠀⠀⠀ ⠸⣇⡏⣇⠿⡰⣉⠏⣎⣹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣏⡳⡜⢮⠵⣍⡏⢶⣽⠇⠀⠀⠀⠀⠀⠀⠀⠀ ⢿⡜⣎⡳⡕⣤⡈⠊⡵⡻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡗⢮⣱⢫⡝⡺⣜⠼⣣⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⢸⣝⣲⡝⡼⣩⢟⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡻⣜⠳⣬⢓⡞⡵⣪⢝⣲⣿⡤⠀⠀⠀⠀⠀⠀⠀⠀ ⣼⣞⡴⡹⣜⢣⡞⢦⢫⢟⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⢭⠳⣜⢫⢖⣫⣼⡵⠟⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠓⠯⢾⣼⣩⢳⣚⡴⢫⢷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡾⡝⢮⣝⡮⠟⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠓⠷⣮⣏⢮⢽⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣟⡧⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢮⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠼⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀ ⣀⣀⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠀⠀⣠⡀⠀⠀⠀⠀⠀⠀⠀     ⠛⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠻⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⣠⣶⣶⣦⣶⣦⣄⠀⠀⣦⣶⡆⣠⣴⣶⡗⠀⣠⣴⣶⣶⣦⣤⠀⠀ ⣿⣿⡿⣤⣤⣤⣤⣄⡀⠀ ⠀⣿⠀⠀⣰⠀⠀⣠⡀⠀⣠⣤⣤⣄⠀  ⣠⡄⠀⠀⠀⠀⠀ ⢠⡄⠀⣠⡀⠀⠀⠀  ⠀⣀⠀⠀
⠀⣰⡿⠿⠟⠿⢿⣿⣿⡄⠀⣽⣿⣿⣿⣿⠟⠀⣼⣿⣿⣿⣿⣿⣿⣿ ⠀⣿⣿⣿⣿⣿⡿⣿⣿⣿⣇ ⠀⣿⠀⠀⣿⠀⠀⣿⣧⡶⠛⠛⠛⠿⣧⡀ ⣿⡇⠀⠀⠀⠀⠀ ⢸⡇⠀⠻⣧⠀⠀ ⠀⣠⣿⠃⠀
⠀⣰⣶⣿⣿⣷⣶⣼⣿⡇⠀⢿⣿⡿⠁⠀⠀⣾⣿⡟⠁⠀⠀⠈⠛⠁⠀ ⣿⣿⣿⠀⠀⠀⠀⢻⣿⣿⠀⠀⣿⠀⠀⣿⠀⠀⣿⡏⠀⠀⠀⠀ ⣿⡇⠀⣿⡇⠀⠀⠀⠀⠀ ⢸⡇⠀⠀ ⠙⢷⣄⣼⡿⠁⠀⠀
⣿⣿⡿⠋⠉⠉⢻⣿⣿⡇⠀⢿⣿⣗⠀⠀⠀⢻⣿⡄⠀⠀⠀⠀⠀⠀⠀ ⣿⣿⣿⠀⠀⠀⠀⣿⣿⣿⠀⠀⣿⠀⠀⣿⠀⠀⣿⡇⠀⠀⠀⠀ ⣿⡇⠀⣿⡇⠀⠀⠀⠀⠀ ⢸⡇⠀⠀ ⠀⠀⣿⣯⠀⠀⠀⠀
⢿⣿⣷⣀⣀⣀⣼⣿⣿⡇⠀⣾⣿⣯⠀⠀⠀⢿⣿⣷⣄⣀⣀⣀⣴⣆ ⠀⣿⣿⣿⠀⠀⠀⠀⢽⣿⣿⠀⠀⣿⠀⠀⣿⠀⠀⣿⡇⠀⠀⠀  ⣿⡇⠀⣿⡇⠀⠀⠀⠀⠀ ⣾⡇⠀ ⠀⣴⡿⠃⠙⣷⡀⠀⠀
⠀⠻⣿⣿⣿⣿⡿⣫⣿⡇⠀⣿⣿⡷⠀⠀⠀⠀⠻⢿⣿⣿⣿⣿⡿⠋ ⠀⣿⣿⣿⠀⠀⠀ ⣻⣿⣿⠀⠀⣿⠀⠀⣿⠀⠀⣿⡇⠀⠀⠀⠀ ⣿⡇ ⠀⠙⣿⣦⣤⣤⣴⠟⢹⡇ ⣼⡏⠀⠀⠀⠀  ⢿⡆⠀
*/
//Basically