using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public struct MidiNote
{
    public int Bar;
    public int Beat;
    public int Tick;
    public float Position;
    public float Length;

    public MidiNote(int bar, int beat, int tick, float notePosition, float length)
    {
        Bar = bar;
        Beat = beat;
        Tick = tick;
        Position = notePosition;
        Length = length;
    }
}

// public struct TimeSig
// {
//     public int Num;
//     public int Denom;
//     public float WHOLE;
//     public float HALF;
//     public float QUARTER;
//     public float EIGHTH;
//     public float SIXTEENTH;

//     // Assumes all time signatures use a denom of 4
//     public TimeSig(int num, int denom)
//     {
//         Num = num;
//         // TODO fix denom being 2 sometimes
//         denom = 4;
//         Assert.AreEqual(denom, 4);
//         Denom = denom;
//         WHOLE = num;
//         HALF = 2.0f;
//         QUARTER = 1.0f;
//         EIGHTH = QUARTER / 2.0f;
//         SIXTEENTH = EIGHTH / 2.0f;
//     }
// }

public enum ArrowType
{
    UPARROW,
    DOWNARROW,
    LEFTARROW,
    RIGHTARROW
};

/// <summary> 
/// The Conductor tracks the song position and controls any other synced action.
/// </summary>
public class Conductor : MonoBehaviour
{
    // Conductor instance
    public static Conductor Instance;

    private AudioSource musicSource;

    // Main vars with getters and setters
    public List<MidiNote> downMidiNotes;
    public List<MidiNote> upMidiNotes;
    public List<MidiNote> leftMidiNotes;
    public List<MidiNote> rightMidiNotes;
    private float ticksperQuarterNote;
    // private TimeSig timeSig;
    private float finalBeat;

    // Variables that keep track of song.
    private double previousFrameTime;
    private double lastReportedPlayheadPosition = 0;
    private double songTime;
    private double songPositionInBeats;

    // Variables for properties of the song.
    [SerializeField]
    private double songBpm;
    private double secPerBeat;
    // firstBeatOffset accounts for small silences before the first beat of the song in the audio file.
    [SerializeField]
    private double firstBeatOffset;

    private bool hasStarted = true;

    private float correctThreshold = 1f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // musicSource = GetComponent<AudioSource>();
        // secPerBeat = 60f / songBpm;
    }

    void Update()
    {
        // Debug.Log("in update");
        // if (hasStarted)
        // {
        //     Debug.Log("in hasStarted");
        //     songTime += AudioSettings.dspTime - previousFrameTime - firstBeatOffset; // TODO fix firstbeatoffset
        //     previousFrameTime = AudioSettings.dspTime;
        //     if (musicSource.time != lastReportedPlayheadPosition)
        //     {
        //         songTime = (songTime + musicSource.time) / 2;
        //         lastReportedPlayheadPosition = musicSource.time;
        //     }
        //     songPositionInBeats = songTime / secPerBeat;
        //     Debug.Log(songPositionInBeats);
        // }
    }

    /// <summary>
    /// Start the soing
    /// </summary>
    public void StartSong()
    {
        musicSource.Play();
        //song started
        previousFrameTime = AudioSettings.dspTime;
        songTime = 0;
        hasStarted = true;
    }

    /* DEPRECATED
    public bool IsQuarterBeat()
    {
        float intSongPositionInBeats = (int) Math.Round (songPositionInBeats, 0) + 0.5f;
        if (songPositionInBeats < intSongPositionInBeats + correctThreshold && songPositionInBeats > intSongPositionInBeats - correctThreshold)
        {
            Debug.Log (songPositionInBeats);
            return true;
        }
        return false;
    }*/

    public bool CheckHit(ArrowType type)
    {
        Debug.Log("in checkhit");
        var midiNotes = new List<MidiNote>();
        if (type == ArrowType.UPARROW) {
            // works
            Debug.Log("in if statement for up arrow");
            midiNotes = upMidiNotes;
            // does not work
            Debug.Log("length of midiNotes: " + midiNotes.Count);
        }
        else if (type == ArrowType.DOWNARROW) {
            // works
            Debug.Log("in if statement for down arrow");
            midiNotes = downMidiNotes;
            // does not work
            Debug.Log("length of midiNotes: " + midiNotes.Count);
        }
        else if (type == ArrowType.LEFTARROW) {
            // works
            Debug.Log("in if statement for left arrow");
            midiNotes = leftMidiNotes;
            // does not work
            Debug.Log("length of midiNotes: " + midiNotes.Count);
        }
        else if (type == ArrowType.RIGHTARROW) {
            // works
            Debug.Log("in if statement for right arrow");
            midiNotes = rightMidiNotes;
            // does not work
            Debug.Log("length of midiNotes: " + midiNotes.Count);
        }
        else
            Debug.LogError("Error: Conductor.cs CheckHit() invalid ArrowType");
        double currentBeat = songPositionInBeats;
        // shows up
        Debug.Log("currentBeat: " + currentBeat);
        // it's not going inside the foreach loop
        foreach (MidiNote midiNote in midiNotes)
        {
            // doesn't show up
            Debug.Log("in foreach loop");
            if (currentBeat > midiNote.Position + correctThreshold)
            {
                Debug.Log("not returning true");
                //midiNotes.Remove (midiNote); // TODO figure out a way to remove notes after they have been passed
            }
            if (currentBeat < midiNote.Position + correctThreshold && currentBeat > midiNote.Position - correctThreshold)
            {
                Debug.Log("returning true");
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// GETTERS AND SETTERS
    /// </summary>

    public float GetBpm()
    {
        return (float)songBpm;
    }

    public void SetBpm(float newBpm)
    {
        songBpm = (double)newBpm;
    }

    public double GetAudioSourceTime()
    {
        return musicSource.time;
    }

    public double GetSongTime()
    {
        return songTime;
    }

    public double GetSongBeat()
    {
        return songPositionInBeats;
    }

    public List<MidiNote> GetMidiNotes(ArrowType type)
    {
        if (type == ArrowType.UPARROW)
            return upMidiNotes;
        else if (type == ArrowType.DOWNARROW)
            return downMidiNotes;
        else if (type == ArrowType.RIGHTARROW)
            return rightMidiNotes;
        else if (type == ArrowType.LEFTARROW)
            return leftMidiNotes;
        Debug.LogError("Error: Conductor.cs GetMidiNotes() invalid ArrowTYpe");
        return new List<MidiNote>();
    }

    public void SetMidiNotes(List<MidiNote> newUpList, List<MidiNote> newDownList, List<MidiNote> newRightList, List<MidiNote> newLeftList)
    {
        upMidiNotes = newUpList;
        downMidiNotes = newDownList;
        rightMidiNotes = newRightList;
        leftMidiNotes = newLeftList;
    }

    public float GetTicksPerQuarterNote()
    {
        return ticksperQuarterNote;
    }

    public void SetTicksperQuarterNote(float newTicksperQuarterNote)
    {
        ticksperQuarterNote = newTicksperQuarterNote;
    }

    // public TimeSig GetTimeSig()
    // {
    //     return timeSig;
    // }

    // public void SetTimeSig(TimeSig newTimeSig)
    // {
    //     timeSig = newTimeSig;
    // }

    public float GetFinalBeat()
    {
        return finalBeat;
    }

    public void SetFinalBeat(float newfinalTick)
    {
        finalBeat = newfinalTick;
    }

}
