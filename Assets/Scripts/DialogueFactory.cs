using UnityEngine;
using System.Collections;

public class DialogueFactory : MonoBehaviour {

	public ArrayList dialogueList = new ArrayList{new Dialogue("crowbar",3,Dialogue.Difficulty.Level1,"se","no","Hi this is Gordon F.$@I need to buy a crowbar for... personnal reasons.$@Could you let me talk to one of your salespeople ?",0,0),
		new Dialogue("letsPlay",7,Dialogue.Difficulty.Level2,"se","no","Hello sir.$@I'm building my next gen gaming rig.$@I'm a professional youtube Let's player.$@So I really need the best components you have.$@Like the best grafX card ever ! And the best CPU as well.$@Before I make my purchase,@I need to be sure about what to buy.$@Can you transfer me to your best technician please ?",0,0),
		new Dialogue("fridge",5,Dialogue.Difficulty.Level1,"se","no","Hey, is this Mamazon ?$@I need help from your customer support.$@I'm looking for a specific model of refridgerator@but I can't find it online.$@It was here last time I checked, I swear it.$@I hope it's still available...@Can you patch me through customer service ?",0,0),
		new Dialogue("order",3,Dialogue.Difficulty.Level1,"sh","no","Hi, I'm calling you to complain about an issue I have,@regarding an order I placed 2 weeks ago.$@I still have zero news about the shipment.@When is it supposed to arrive ? I don't know.$@Could you please help me with that ?",0,0),
		new Dialogue("iguana",6,Dialogue.Difficulty.Level3,"sh","no","Good afternoon, I would like to buy an Iguana.$@You see, I want to buy something cool@for my wife's birthday.$@I really want to make her happy. She likes reptilians,@so I figured an iguana would be a perfect gift for her.$@The problem is that we live in a remote place,@far away from any big city.$@So deliveries take ages to get to here.$@Her birthday is next friday. Could you speed up the delivering process@in order to get her present quicker ?",0,0),
		new Dialogue("wrong",5,Dialogue.Difficulty.Level2,"sh","no","Hey, is this Customer support ?$@I'm calling to notify you that my order was sent@to the wrong adress.$@You see, I have moved away,@and I no longer live at the location you shipped my package.$@This is really important to me,@and I need you to send it back to my current adress.$@Will you please let me talk to your manager ?",0,0),
		new Dialogue("canigou",8,Dialogue.Difficulty.Level3,"af","no","Hi, I'm calling because@I'm very unhappy with one of your products.$@I recently bought some Canigou Gold dog food@from one of your retailers.$@It says on the package that it's fat free.@My baby puppy dog is on a diet you see.$@At first he was indeed losing weight.@But he also seemed to like his food a little too much.$@And just last night, I found him in the kitchen, belly up.$@Next to him was an empty bad of Canigou@that he had ripped through.$@And guess what ?! Now he's 3 pounds heavier.@That's just insane. They said it's fat free.$@This is unacceptable@and I want a full refund on my purchase !@Let me talk to your manager !",0,0),
		new Dialogue("note7",5,Dialogue.Difficulty.Level2,"af","no","Hey, is there somebody here ?!$@Guess what ! You suck ! Your products suck !@Everybody sucks at your company !$@I just bought a Sunsung Universe note 7,@and IT JUST EXPLODED IN MY HAND !$@What the fuck are you thinking about,@you fat fucking, ignorant fucks !$@I WANT A REFUND !",0,0),
		new Dialogue("phone",5,Dialogue.Difficulty.Level1,"af","no","Hello, I have a problem with my phone.$@You see, last tuesday I went swimming with my friends.$@It was really hot and sunny. We had a lot of fun.$@Until I dropped my phone in the water.@Now it just won't boot up.$@Will you please send me another one for free ? @This has to be covered in the warranty.",0,0),
		new Dialogue("dildo",8,Dialogue.Difficulty.Level3,"te","no","Huh, hello ?$@I'm calling you for a rather... technical problem.$@You see I recently bought a product from your website.$@It's... a toy... for adults.$@The problem is that my dog.... well how do I put it...$@He kinda swallowed it.$@And now, it's turning on everytime he has a hiccup.$@So... what can I do to get it back ?",0,0),
		new Dialogue("tv",7,Dialogue.Difficulty.Level2,"te","no","Hello mister,$@My grand son recently bought me@one of these news flat televisors.$@He's such a good boy, @but there seems to be just a little problem.$@I can't find a way to switch channels !$@I'm stuck watching Fox News$@This is an urgent matter.@I feel my IQ dropping minute by minute.$@Will you please help a poor lady my dear boy ?",0,0),
		new Dialogue("has2be",6,Dialogue.Difficulty.Level3,"te","no","Hello is there anybody here ?$@I have a problem here, will somebody help me ?$@I can't use your website,@it seems to be broken or something...$@I lost the images, I lost the text, I lost everything.$@It has to be a problem on your side,@my computer is working fine.$@Have you tried switching your website off and on ?",0,0),
		new Dialogue("bossWife",2,Dialogue.Difficulty.Level1,"ma","no","Hello, I'm Stephany, your boss' wife.$@Please transfer this call to him.",0,0),
		new Dialogue("bossMist",4,Dialogue.Difficulty.Level3,"ma","no","Hey, Geralt this is Monica.$@Could you DO ME a favor and come quickly@to my house after your work here is done ?$@I feel really lonely here.$@Geralt ? Are you there ?",0,0),
		new Dialogue("golden",7,Dialogue.Difficulty.Level2,"on","no","Hello.$@Haven't you always dreamed of making a lot of money@while doing nothing ?$@Well, this is now a reality with our new website :@GoldenTards !$@For just a small monhly fee, you can make money@by answering survey calls and watching ads.$@Wich will leave you plenty of time for watching TV@or playing video games.$@So quit your silly job today and join the hundreds@of retarders in our community !$@GoldenTards, made by retards like us, for people like you !",0,0)
	};

	// Use this for initialization
	void Start () {
		/*
			case "sh": depaAssigned = Department.ShippingService; break;
			case "se": depaAssigned = Department.SellingDepartment; break;
			case "te": depaAssigned = Department.TechnicalSupport; break;
			case "ma": depaAssigned = Department.Manager; break;
			case "af": depaAssigned = Department.AfterSaleServices; break;
			case "on": depaAssigned = Department.OnHold; break;
		*/
	}

	// Update is called once per frame
	void Update () {

	}
}
