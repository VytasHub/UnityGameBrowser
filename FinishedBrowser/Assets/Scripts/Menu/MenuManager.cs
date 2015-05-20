using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// manages the menu buttons and music
// navigating to: play, character select
// toggling sound on/off
// tweeting your score to your followers

public class MenuManager : MonoBehaviour {
	//public GameObject BGMusic;

	public Text txtBestScore, txtLastScore;
	public Button btnMute;

	private Color32 normCol = new Color32(146,146,146,200);
	private Color32 selCol = new Color32(232, 97, 97, 200);
	
	public void PlayGame (string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}


	// local storage
	int highScore, lastScore;
	
	private int isMuted = 0;

	void OnApplicationPause(bool pauseStatus) {
		isMuted = PlayerPrefs.GetInt ("isMuted");
		if(isMuted == 1){
			AudioListener.pause = true;
		}
		else{
			AudioListener.pause = false;
		}
	}
	
	public void Start(){
		// load storage settings
		highScore = PlayerPrefs.GetInt("highScore");
		lastScore = PlayerPrefs.GetInt("las\ttScore");
		// display scores
		txtBestScore.text = highScore.ToString();
		txtLastScore.text = lastScore.ToString();
		// check if muted
		if (AudioListener.pause == false) {
			btnMute.image.color = normCol;
			btnMute.GetComponentInChildren<Text>().text = "Mute";
		}
		else{
			btnMute.image.color = selCol;
			btnMute.GetComponentInChildren<Text>().text = "Unmute";
		}
	}
	//public void ChangeScene(string chosenScene){
		//DontDestroyOnLoad (BGMusic);
	//	Application.LoadLevel(chosenScene);
	//}

	public void ToggleMute(){
		if (AudioListener.pause == false) {
			btnMute.GetComponentInChildren<Text>().text = "Unmute";
			btnMute.image.color = selCol;
			AudioListener.pause = true;
			isMuted = 1;
			PlayerPrefs.SetInt("isMuted", isMuted);
		}
		else{
			btnMute.GetComponentInChildren<Text>().text = "Mute";
			btnMute.image.color = normCol;
			AudioListener.pause = false;
			isMuted = 0;
			PlayerPrefs.SetInt("isMuted", isMuted);
		}
	}
	// fb share
	public void fbShare(){
		string description;
		if (lastScore == 1) {
			description = "I just collected  " + lastScore + " heart!";
		}
		else{
			description = "I just collected " + lastScore + " hearts!";
		}
		// message info
		string link = "http://ronanconnolly.ie/unity/heartchaser/game.html";
		string pictureLink = "http://ronanconnolly.ie/unity/HartChaseraBacku/epic.png"; // FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
		string name = "Heart Chaser";
		string caption = "Best Score: " + highScore;

		//string description = "Description";
		//string redirectUri = "unity/HartChaseraBacku/epic.png";
		string redirectUri = "http://www.facebook.com/";
		//ShareFB(link, pictureLink, name, caption, description, redirectUri);
		ShareToFacebook(link, name, caption, description, pictureLink, redirectUri);
	}
	// facebook info
	const string AppId = "1550917645174931";
	const string ShareUrl = "http://www.facebook.com/dialog/feed";
	// facebook share
	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{


		Application.OpenURL (ShareUrl + "?app_id=" + AppId +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
	// twitter share
	public void twitterShare(){
		// message info
		string text;
		if (lastScore == 1) {
			text = "I just collected " + lastScore + " heart!\n\n#HeartChaser #GamesFleadh\n@Vytas_Me\n\nTry to beat me:\n";
		}
		else{
			text = "I just collected " + lastScore + " hearts!\n\n#HeartChaser #GamesFleadh\n@Vytas_Me\n\nTry to beat me:\n";
		}
		string url = "http://ronanconnolly.ie/unity/heartchaser/game.html";
		string related = "@Vytas_Me";
		string lang = "en";
		ShareTW(text, url, related, lang);
	}
	// twitter info
	const string Address = "http://twitter.com/intent/tweet";
	// share to twitter method
	public static void ShareTW(string text, string url,string related, string lang)//="en"
	{
		Application.OpenURL(Address +
		                    "?text=" + WWW.EscapeURL(text) +
		                    "&amp;url=" + WWW.EscapeURL(url) +
		                    "&amp;related=" + WWW.EscapeURL(related) +
		                    "&amp;lang=" + WWW.EscapeURL(lang));
	}
}