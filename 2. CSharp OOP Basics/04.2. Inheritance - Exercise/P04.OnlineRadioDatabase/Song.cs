public class Song
{
    private const int ArtistNameMinLength = 3;
    private const int ArtistNameMaxLength = 20;
    private const int SongNameMinLength = 3;
    private const int SongNameMaxLength = 30;
    private const int MinMinutes = 0;
    private const int MaxMinutes = 14;
    private const int MinSeconds = 0;
    private const int MaxSeconds = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    private string ArtistName
    {
        get => artistName;

        set
        {
            if (value.Length < ArtistNameMinLength || value.Length > ArtistNameMaxLength)
            {
                throw new InvalidArtistNameException();
            }

            artistName = value;
        }
    }

    private string SongName
    {
        get => songName;

        set
        {
            if (value.Length < SongNameMinLength || value.Length > SongNameMaxLength)
            {
                throw new InvalidSongNameException();
            }

            songName = value;
        }
    }

    public int Minutes
    {
        get => minutes;

        private set
        {
            if (value < MinMinutes || value > MaxMinutes)
            {
                throw new InvalidSongMinutesException();
            }

            minutes = value;
        }
    }

    public int Seconds
    {
        get => seconds;

        private set
        {
            if (value < MinSeconds || value > MaxSeconds)
            {
                throw new InvalidSongSecondsException();
            }

            seconds = value;
        }
    }
}