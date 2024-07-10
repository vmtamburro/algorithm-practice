public class SearchSuggestionsSystem{
    /* 
        - given an array of strings where each string is a product and a searched word
        - return a list of lists where each list contains the top 3 products that contain the searched word
        - if there are less than 3 products that contain the searched word, return all products that contain the searched word
        - the products should be sorted in lexicographical order
        - if there are no products that contain the searched word, return an empty list
        - the searched word is case-insensitive
        - the products are case-insensitive
        - the length of the products array is n
        - the length of each product is m
        - the length of the searched word is k


    */


/************ Solution No 1 **********/
    // Time Complexity O(n logn + n * m * k)
    public List<List<string>> SuggestedProducts(string[] products, string searchedWord){
        List<List<string>> result = new List<List<string>>();
        // sorting could be more optimized probably than OrderBy. 
        // What type of sort does OrderBy use under the hood? - QuickSort
        // initial sorting should also be case insensitive
        var orderedProductsList = products.OrderBy(x => x).ToList();
        var prefix = "";

        foreach(var c in searchedWord.ToCharArray()){
            prefix += c;
            var suggestedProducts = new List<string>();
            // doing an AddRange actually is doing a double sort. We can avoid the sorting here.
            suggestedProducts.AddRange(products.Where(x => x.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x).Take(3));
            result.Add(suggestedProducts);
        }
        return result;
    }

    /************ Solution No 2 **********/

    /*
        - Trie construction time complexity is O(nm)
        - Trie search time complexity is O(k)
        - Space Complexity O(nm)
    */

    public class TrieNode{
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public SortedSet<string> suggestions = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
    }
    public class Trie{
        public TrieNode root;
        public Trie(){
            root = new TrieNode();
        }

        public void Insert(string word){
            var node = root;
            foreach(var c in word){
                if(!node.children.ContainsKey(c)){
                    node.children[c] = new TrieNode();
                }
                node = node.children[c];
                node.suggestions.Add(word);
                if(node.suggestions.Count > 3){
                    node.suggestions.Remove(node.suggestions.Max);
                }
            }
        }
    }
    public List<List<string>> SuggestedProduct2(string[] products, string searchedWord){
        Trie trie = new Trie();
        foreach(var product in products){
            trie.Insert(product);
        }
        List<List<string>> result = new List<List<string>>();
        var prefix = "";
        foreach(var c in searchedWord.ToCharArray()){
            prefix += c;
            var suggestedProducts = new List<string>();
            var node = trie.root;
            foreach(var ch in prefix){
                if(!node.children.ContainsKey(ch)){
                    break;
                }
                node = node.children[ch];
            }
            result.Add(node.suggestions.ToList());
        }
        return result;
    }
}