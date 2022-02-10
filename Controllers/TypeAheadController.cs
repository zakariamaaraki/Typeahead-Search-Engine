namespace App.Controller;

using App.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TypeAheadController : ControllerBase
{

    private readonly ITrie trie;

    public TypeAheadController(ITrie trie)
    {
        this.trie = trie;
    }

    [HttpPost]
    public void Post(string str)
    {
        this.trie.Add(str);
    }

    [HttpGet]
    public ResponseDto Get(string _search, int limit = 10)
    {
        return new ResponseDto(this.trie.Find(_search, limit));
    }

}