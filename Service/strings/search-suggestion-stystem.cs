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

    public List<List<string>> SuggestedProducts(string[] products, string searchedWord){
        List<List<string>> result = new List<List<string>>();
        var orderedProductsList = products.OrderBy(x => x).ToList();
        var prefix = "";

        foreach(var c in searchedWord.ToCharArray()){
            prefix += c;
            var suggestedProducts = new List<string>();
            suggestedProducts.AddRange(products.Where(x => x.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x).Take(3));
            result.Add(suggestedProducts);
        }
        return result;
    }
}