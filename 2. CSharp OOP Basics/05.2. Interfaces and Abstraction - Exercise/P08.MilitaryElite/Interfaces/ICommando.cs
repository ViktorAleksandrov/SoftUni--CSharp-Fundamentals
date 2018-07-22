using System.Collections.Generic;

public interface ICommando
{
    List<IMission> Missions { get; }
}