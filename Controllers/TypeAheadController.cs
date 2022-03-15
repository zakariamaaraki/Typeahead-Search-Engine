using App.Model;
using App.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Controller;

[ApiController]
[Route("api/[controller]")]
public class TypeAheadController : ControllerBase
{
    private readonly ITrie _trie;

    public TypeAheadController(ITrie trie)
    {
        _trie = trie;
    }

    [HttpPost]
    public void Post(string str)
    {
        _trie.Add(str);
    }

    [HttpGet]
    public ResponseDto Get(string _search, int limit = 10)
    {
        return new ResponseDto(_trie.Find(_search, limit));
    }
}