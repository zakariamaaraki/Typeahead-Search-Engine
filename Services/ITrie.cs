namespace App.Service;

using App.Model;

/// <summary>
/// ITrie interface
/// </summary>
public interface ITrie
{
    public void Add(string str);

    public Response Find(string str, int limit);
}