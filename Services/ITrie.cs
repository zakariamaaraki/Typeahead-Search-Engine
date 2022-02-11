namespace App.Service;

using App.Model;

public interface ITrie
{
    public void Add(string str);

    public Response Find(string str, int limit);

}