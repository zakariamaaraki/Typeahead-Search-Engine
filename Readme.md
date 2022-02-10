# Typeahead Search Engine

A real-time suggestion service, which enable users to search for known and frequently searched terms. It tries to predict the query based on the characters the user has enteredand gives a list of suggestions to complete the query.

## Getting Started

```shell
docker build . -t typeaheadsuggestion
```

```shell
docker container run -p 80:80 typeaheadsuggestion
```

## Algorithm

Since we've got to serve a lot of queries with minimum latency, we need to come up with a scheme that can effeciently store our data such that it can be queried quickly. We can't depend upon some database for this, we need to store our index in memory in a highly efficient data structure.

One of the most appropriate data structures that can serve our purpose is the **Trie** 

![Trie](images/trie.png?raw=true "trie data structure")

### Complexity

* **Space** : O(n)
* **Search** : O(n)
* **Insert** : O(n)
* **Delete** : O(n) 

### Compute most relevant elements

To compute the k most relevant elements, we can use a **Heap** (Priority Queue), to be able to do it during the search in an efficient way **O(nlog(k))**.

## For dev env

For dev env you can use the swagger page accessible using this url : [https://localhost/swagger](https://localhost/swagger)

![Swagger](images/Swagger-page.png?raw=true "ProblemSolvingPlatformSwagger")


## Author

- **Zakaria Maaraki** - _Initial work_ - [zakariamaaraki](https://github.com/zakariamaaraki)
