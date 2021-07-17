# Big O Notation


Summary
- Transferring of Data takes longer depending on how much data there is.
- Constant time beats linear time IF data is sufficiently big. O(N)
    - *Meaning, twice as much data is going to take twice the amount of time.*


## Big O
- Describes how time scales with respect to some input variables.

For Example:

This would be O(N), where n is the size of the array.
```
bool conains(arr[], x){
    for each element in array {
        if element == x{
            return true;
        }
    }
}
```

This would be O(N^2) where N is the size of the array.
```
void printPairs(array){
    fore each x in array{
        for each y in array{
            print x, y
        }
    }
}
```


Real World Example:


Both mean basically the same thing.
```
Run-time of mowing a plot of grass.
O(a) where a = the area of grass.
O(s^2) where s - the length of one side. 
```


Many times - Big O notation does not use "N" It's just a variable. Any var will do.

## Rules

1. If you have two seperate steps, you would add the two steps. This would be O(a + b)

```
function something() {
    doStep1(); // O(a)
    doStep2(); // O(b)
}
```


2. Drop Constants
```
function minMax1(arr){
    min, maxx <= NULL //O(N)
    for each e in array
    min = MIN(e, min)
    for each e in array //O(N)
    max = MAX(e, max)
}

//This would still be O(N), not O(2N). We are dropping the constants.

VS

function minMax2(arr){
    min, max <= NULL
    for each e in array
        min = MIN(e, min)
        max = MAX(e, max)
}
```


3. If you have different inputs, you are usually going to use different variables.

Some may consider this to be O(N^2) , but this is not correct.
```
    int intersectionSize(arr1, arr2){
        int count = 0;
        for a in array1{
            for b in array2{
                if(a == b){
                    count += 2;
                }
            }
        }
        return count;
    }

    O(a * b);
```

4. Drop non-dominant terms.

```
    function whyWouldIDoThis(arr){
        max = null
        foreach a in arr{
            max = MAX (a, max) // O(n)
        }
        print max   

        foreach a in array{
            for each b in array{
                print a, b // O(n^2)
            }
        }
    }

    O(n + n^2)...

    O(n^2) < O(n + n^2) < O(n^2 + n^2)
```

3. Heaps O(log(n)) and average O(1)





