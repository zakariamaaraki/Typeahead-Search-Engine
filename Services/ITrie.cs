using App.Model;

namespace App.Service;

/// <summary>
///     ITrie interface
/// </summary>
public interface ITrie
{
    public void Add(string str);

    public Response Find(string str, int limit);
}