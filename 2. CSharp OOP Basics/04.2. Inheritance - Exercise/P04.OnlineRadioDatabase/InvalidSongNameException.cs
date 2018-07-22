﻿public class InvalidSongNameException : InvalidSongException
{
    private const int MinLength = 3;
    private const int MaxLength = 30;

    public override string Message => $"Song name should be between {MinLength} and {MaxLength} symbols.";
}