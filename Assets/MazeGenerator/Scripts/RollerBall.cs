using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO; 
using System.Text;
using UnityEngine.SceneManagement;
using TMPro;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {

	public AudioClip CoinSound = null;
	public TextMeshProUGUI timerText = null;
	public TextMeshProUGUI scoreText = null;
	public string LevelToLoad; //Game scene
	private AudioSource mAudioSource = null;
	private GameObject[] coins = {};
	private int coinsCollect = 0;
	private float time = 0;
	private bool win = false;
	private TextWriter writer;
	public GameObject playerNameMenu; // Assign in inspector
	public Button confirmButton = null;
	public TMP_InputField playerNameInput = null;
	public string level = "0";

	void Start () {
		mAudioSource = GetComponent<AudioSource>();
		win = false;
		coinsCollect = 0;
		coins = new GameObject[] {};
		time = 0;
		playerNameMenu.SetActive(false);
		if (confirmButton != null)
	        confirmButton.onClick.AddListener(_onConfirm);
	}

	void Update()
	{
		if (coins.Length == 0)
		{
			coins = GameObject.FindGameObjectsWithTag("Coin");
			coinsCollect = 0;
	        writer = File.AppendText("./Assets/Score/" + level + ".txt");
		}
		else
		{
			scoreText.text = coinsCollect.ToString() + "/" + coins.Length.ToString();
			if (coinsCollect != coins.Length)
				time += Time.deltaTime;
			else
				win = true;
			timerText.text = (((int)time)/60).ToString("00") + ":" + (((int)time)%60).ToString("00");
		}

		if (win)
		{
			playerNameMenu.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Coin")) {
			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			Destroy(other.gameObject);
			coinsCollect++;
		}
	}

	private void _onConfirm()
	{
		if (playerNameInput.text != "")
		{
			writer.Write(playerNameInput.text + ":" + time.ToString() + "\r\n");
			writer.Close();
			SceneManager.LoadScene(LevelToLoad);
		}
	}
}
