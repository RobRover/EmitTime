using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeriorateSound : MonoBehaviour
{
	public int start_index;
	public int end_index;
	public int start_time;
	public int end_time; 
	
	public AudioClip clip_audio;
	private float next_time_clip;
	private float prev_time;
	private int curr_index;

	private AudioSource au_source;
	private DetriorateAnimationWood anim_manager;


	/**
		The main point it for the sound is to be play with the animation,
		and for that we have to assign a frame to each sound interval,
		via interpolation.
	*/


	// Start is called before the first frame update
	void Start()
	{
		au_source = GetComponent<AudioSource>();

		au_source.clip = clip_audio;
	}

	float LERP(float x, float x1, float x2, float f1, float f2) {
		return f1 + ((f2 - f1) / (x2 - x1 + 0.0001f)) * (x - x1);
	}

	// Update is called once per frame
	void Update()
	{
		
		// Calculate time direction delta
		float time_delta = Manager.Instance.time - prev_time;
		prev_time = Manager.Instance.time;

		if (((au_source.time >= next_time_clip) && time_delta > 0) || ((au_source.time <= next_time_clip) && time_delta < 0)) {
			au_source.Stop();
		}

		// If the is no change, dont change the pitch
		if (time_delta != 0) {
				if (time_delta < 0) {
				au_source.pitch = -1;
			} else {
				au_source.pitch = 1;
			}
		}

		if (Manager.Instance.time >= start_time && Manager.Instance.time <= end_time) {
			// Get the current frame of the animation
			int index = (int) LERP(Manager.Instance.time, start_time, end_time, start_index, end_index);
			
			if (index != curr_index) {
				// Map the current frame of the animation to a clip of mussic
				float clip_position = LERP(index, start_index, end_index, 0, clip_audio.length);
				
				if (time_delta > 0) {
					next_time_clip = LERP(index+1, start_index, end_index, 0, clip_audio.length);
				} else {
					next_time_clip = LERP(index-1, start_index, end_index, 0, clip_audio.length);
				}

				au_source.time = clip_position;
				au_source.Play();

				curr_index = index;
			}
		}
	}
}
