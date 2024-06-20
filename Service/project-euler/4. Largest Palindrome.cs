public class Euler4{
    /* 
        A palindromic number reads the same both ways. the largest palindrome from the product of 
        2-digit numbers is 9009 = 91 * 99

        Find the largest palindrome made from the product of two 3-digit numbers
        
        Pseudocode
        1. Establish boundaries
            lower = 000 * 000 = 0
            upper = 999 * 999 = 9980001

        2. Decrement backwards from our upper limit
            a. Check if that is a palindrome
                -  If so, get factors of that number.
                - If those numbers are in the triple digits, return them.

        O(n^2) time complexity
    */

    public bool IsPalindrome(int n){
        var s = n.ToString();
        int len = s.Length;
        // loop through half of the string
        for(int i = 0; i < len / 2; i++){
            //palindrome check
            if(s[i] != s[len-i-1]){
                return false;
            }
        }
        return true;
    }

    public (int, int, int) LargestPalindromeProduct(){
        int largestPalindrome = 0;
        int factor1 = 0;
        int factor2 = 0;

        for (int i = 999; i >= 100; i--){
            for(int j = 999; j >= i; j--){
                int product = i * j;
                if(product <= largestPalindrome){ 
                    break; // skip unnecessary checks since the product of the two numbers only gets smaller.
                }
                if(IsPalindrome(product)){ // check if the product s a palindrome
                    largestPalindrome = product;
                    factor1 = i;
                    factor2 = j;
                }
            }
        }

        return (largestPalindrome, factor1, factor2);
    }
}